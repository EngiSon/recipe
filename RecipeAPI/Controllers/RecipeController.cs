using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeAPI.Dal;
using RecipeAPI.Models;

namespace RecipeAPI.Controllers
{
    [Route("api/Recipes")]
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

        [HttpPost]
        public async Task<ActionResult<Recipe>> PostRecipe(RecipeDTO recipe)
        {
            var author = ctx.Users.Find(recipe.UserId);

            if (author == null ||
                !checkEnum(recipe.FoodType)
                )
            {
                return BadRequest();
            }

            var newRecipe = DTOtoItem(recipe, author);

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


        private static Recipe DTOtoItem(RecipeDTO dto, User author)
        {
            return new Recipe(author, dto.Name, dto.FoodType, dto.Ingredients, dto.Description);
        }

        private static Boolean checkEnum(String foodType)
        {
            try
            {
                Enum.Parse(typeof(FoodType), foodType, true);
            } catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
