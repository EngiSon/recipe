namespace RecipeAPI.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Name { get; set; }
        public FoodType[]? FoodType { get; set; }
        public string[]? Ingredients { get; set; }
        public string? Description { get; set; }
    }

    public enum FoodType
    {
        Vegan,
        Vegetarian,
        Pescitarian,
        Glutenfree
    }
}
