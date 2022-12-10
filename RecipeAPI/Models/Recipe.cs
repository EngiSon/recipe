namespace RecipeAPI.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User Author { get; set; }
        public string? Name { get; set; }
        public List<FoodType>? FoodType { get; set; }
        public List<string>? Ingredients { get; set; }
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
