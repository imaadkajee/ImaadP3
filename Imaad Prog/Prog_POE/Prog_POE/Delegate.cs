using System;
using System.Collections.Generic;
using System.Windows;

namespace Final_POE
{
    internal class Delegate
    {
        public double CalorieAlert(List<Recipe> recipebook, string Recipe)
        {
            double Calories = 0;
            foreach (Recipe recipe in recipebook)
            {
                if (Recipe == recipe.RecipeName)
                {
                    Calories += recipe.Calories * recipe.Quantities;
                }
            }
            if (Calories > 300)
            {
                MessageBox.Show("Recipe " + Recipe + " exceeds 300 calories", "Calorie Alert!");
            }
            return Calories;
        }

        public double TotalCals(List<Recipe> recipebook, string Recipe)
        {
            double Calories = 0;
            foreach (Recipe recipe in recipebook)
            {
                if (Recipe == recipe.RecipeName)
                {
                    Calories += recipe.Calories * recipe.Quantities;
                }
            }
            return Calories;
        }
    }
}
