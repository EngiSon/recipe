using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeAPI.Dal;
using RecipeAPI.Models;

namespace RecipeAPI.Controllers
{
    [Route("api/Users")]
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

        [HttpGet]
        public async Task<ActionResult<User>> ValidateUser(ValidationDTO dto)
        {
            var foundUser = await ctx.Users.Where(u => (u.Username == dto.Username) && (u.Password == dto.Password)).FirstAsync();

            if (foundUser == null)
            {
                return BadRequest();
            }

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

            return CreatedAtAction(nameof(GetUser), new {id = user.Id}, user);
        }

        [HttpPut("{favoritingUserId}/{favoritedUserId}")]
        public async Task<ActionResult> HandleFavorite(int favoritingUserId, int favoritedUserId)
        {
            var favoritingUser = await ctx.Users.FindAsync(favoritingUserId);
            var favoritedUser = await ctx.Users.FindAsync(favoritedUserId);

            if (favoritingUser == null ||
                favoritedUser == null)
            {
                return BadRequest();
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
