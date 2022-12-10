namespace RecipeAPI.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string IngredientName { get; set; }

        public Ingredient(string ingredientName)
        {
            IngredientName = ingredientName;
        }
    }
}
