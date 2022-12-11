namespace RecipeAPI.Models
{
    public class RecipeDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string FoodType { get; set; }
        public string Ingredients { get; set; }
        public string Description { get; set; }

    }
}
