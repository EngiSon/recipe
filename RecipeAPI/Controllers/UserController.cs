using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeAPI.Dal;
using RecipeAPI.Models;

namespace RecipeAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly RecipeContext ctx;

        public UserController(RecipeContext context)
        {
            ctx = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await ctx.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await ctx.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        [HttpPost("validate")]
        public async Task<ActionResult<User>> ValidateUser(ValidationDTO dto)
        {
            var isFindUser = ctx.Users.Where(u => (u.Username == dto.Username) && (u.Password == dto.Password)).Any();

            if (!isFindUser)
            {
                return BadRequest();
            }

            var foundUser = await ctx.Users.Where(u => (u.Username == dto.Username) && (u.Password == dto.Password)).FirstAsync();
            return foundUser;

        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(UserDTO user)
        {
            if (ctx.Users.Where(u => u.Username == user.Username).Any()) 
            { 
                return BadRequest();
            }

            var newUser = DTOtoItem(user);

            ctx.Users.Add(newUser);
            await ctx.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new {id = newUser.Id}, user);
        }

        [HttpPut("{favoritingUserId}/{favoritedUserId}")]
        public async Task<ActionResult> HandleFavorite(int favoritingUserId, int favoritedUserId)
        {
            if (favoritedUserId == favoritedUserId)
            { 
                return BadRequest(); 
            }
            var favoritingUser = await ctx.Users.FindAsync(favoritingUserId);
            var favoritedUser = await ctx.Users.FindAsync(favoritedUserId);

            if (favoritingUser == null ||
                favoritedUser == null)
            {
                return NotFound();
            }
            if (favoritingUser.OutgoingFavorites == null)
            {
                favoritingUser.OutgoingFavorites = new List<User>();
            }
            if (favoritedUser.IncomingFavorites == null)
            {
                favoritedUser.IncomingFavorites = new List<User>();
            }

            favoritingUser.OutgoingFavorites.Add(favoritedUser);
            favoritedUser.IncomingFavorites.Add(favoritingUser);

           await ctx.SaveChangesAsync();

           return NoContent();
        }

        private static User DTOtoItem(UserDTO dto)
        {
            return new User(dto.Username, dto.Password, dto.Email);
        }
    }
}
