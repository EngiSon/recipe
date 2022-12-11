namespace RecipeAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public List<Recipe> Recipes { get; set; }
        public List<User> OutgoingFavorites { get; set; }
        public List<User> IncomingFavorites { get; set; }


        public User()
        {

        }

        public User(string username, string password, string email)
        {
            Username = username;
            Password = password;
            Email = email;
            Recipes = new List<Recipe>();
            OutgoingFavorites = new List<User>();
            IncomingFavorites = new List<User>();
        }
    }
}
