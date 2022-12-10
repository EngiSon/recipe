namespace RecipeAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public List<Recipe>? Recipes { get; set; }
        public List<User>? FavoritedUsers { get; set; }
        public List<User>? UsersFavorited { get; set; }
    }
}
