namespace RecipeAPI.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User Author { get; set; }
        public string Name { get; set; }
        public FoodType FoodType { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public string Description { get; set; }
        public Recipe()
        {

        }

        public Recipe(User author, string name, string foodType, List<Ingredient> ingredients, string description)
        {
            UserId = author.Id;
            Author = author;
            Name = name;
            FoodType = (FoodType) Enum.Parse(typeof(FoodType), foodType, true);
            Ingredients = ingredients;
            Description = description;
        }
    }

}
