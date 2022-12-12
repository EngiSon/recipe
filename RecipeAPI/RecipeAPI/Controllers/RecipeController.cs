using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeAPI.Dal;
using RecipeAPI.Models;

namespace RecipeAPI.Controllers
{
    [Route("api/recipes")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly RecipeContext ctx;

        public RecipeController(RecipeContext context)
        {
            this.ctx = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipes()
        {
            return await ctx.Recipes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Recipe>> GetRecipe(int id)
        {
            var recipe = await ctx.Recipes.FindAsync(id);

            if (recipe == null)
            {
                return NotFound();
            }

            return recipe;
        }

        [HttpGet("users/{id}")]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetUserRecipes(int id)
        {
            var user = await ctx.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var recipes = await ctx.Recipes.Where(r => r.UserId == id).ToListAsync();
            return recipes;
        }

        [HttpPost]
        public async Task<ActionResult<Recipe>> PostRecipe(RecipeDTO recipe)
        {
            var author = ctx.Users.Find(recipe.UserId);

            if (author == null ||
                recipe.FoodType > 4 ||
                recipe.FoodType < 0
                )
            {
                return BadRequest();
            }

            var newRecipe = DTOtoItem(recipe, recipe.UserId);

            if (author.Recipes == null)
            {
                author.Recipes = new List<Recipe>();
            }

            author.Recipes.Add(newRecipe);
            ctx.Recipes.Add(newRecipe);
            await ctx.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRecipe), new { id = recipe.Id }, recipe);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe(int id)
        {
            var recipe = await ctx.Recipes.FindAsync(id);

            if (recipe == null)
            {
                return NotFound();
            }

            ctx.Recipes.Remove(recipe);
            await ctx.SaveChangesAsync();

            return NoContent();
        }


        private static Recipe DTOtoItem(RecipeDTO dto, int userId)
        {
            return new Recipe(userId, dto.Name, (FoodType) dto.FoodType, dto.Ingredients, dto.Description);
        }
    }
}
