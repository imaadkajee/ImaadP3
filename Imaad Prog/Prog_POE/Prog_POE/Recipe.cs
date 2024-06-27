using System;

namespace Final_POE
{
    public class Recipe
    {
        // Properties with PascalCase naming convention
        public string RecipeName { get; set; }
        public string Ingredients { get; set; }
        public double Quantities { get; set; }
        public string UnitOfMeasurement { get; set; }
        public double Calories { get; set; }
        public string FoodGroup { get; set; }
        public double OriginalQuantities { get; set; }

        // Default constructor
        public Recipe()
        {
        }

        // Constructor with parameters
        public Recipe(string recipeName, string ingredients, double quantities, string unitOfMeasurement, double calories, string foodGroup)
        {
            RecipeName = recipeName;
            Ingredients = ingredients;
            Quantities = quantities;
            UnitOfMeasurement = unitOfMeasurement;
            Calories = calories;
            FoodGroup = foodGroup;
            OriginalQuantities = quantities; // Store original quantities for scaling/resetting
        }
    }
}
