namespace RecipeAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public List<Recipe> Recipes { get; set; }
        public List<User> FavoritedUsers { get; set; }
        public List<User> UsersFavorited { get; set; }


        public User()
        {

        }

        public User(string username, string password, string email)
        {
            Username = username;
            Password = password;
            Email = email;
            Recipes = new List<Recipe>();
            FavoritedUsers= new List<User>();
            UsersFavorited= new List<User>();
        }
    }
}
