namespace RecipeAPI.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public FoodType FoodType { get; set; }
        public string Ingredients { get; set; }
        public string Description { get; set; }
        public Recipe()
        {

        }

        public Recipe(int userId, string name, FoodType foodType, String ingredients, string description)
        {
            UserId = userId;
            Name = name;
            FoodType = foodType;
            Ingredients = ingredients;
            Description = description;
        }
    }

}
