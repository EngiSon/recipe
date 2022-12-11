﻿namespace RecipeAPI.Models
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

        public Recipe(int userId, string name, string foodType, String ingredients, string description)
        {
            UserId = userId;
            Name = name;
            FoodType = (FoodType) Enum.Parse(typeof(FoodType), foodType, true);
            Ingredients = ingredients;
            Description = description;
        }
    }

}