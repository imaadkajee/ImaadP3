using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Final_POE
{
    public partial class RecipeView : Window
    {
        private string selectedRecipe; // Stores the currently selected recipe name

        public RecipeView()
        {
            InitializeComponent();
            LoadRecipes(); // Load recipes when the window initializes
        }

        // Load recipes into the lbRecipes ListBox
        private void LoadRecipes()
        {
            // Get distinct recipe names from StepsList and populate lbRecipes
            IEnumerable<string> recipes = ListUtils.StepsList
                .OrderBy(x => x.RecipeName)
                .Select(x => x.RecipeName)
                .Distinct();

            foreach (string recipeName in recipes)
            {
                lbRecipes.Items.Add(recipeName);
            }
        }

        // Handle selection change in lbRecipes ListBox
        private void lbRecipes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbRecipes.SelectedItem == null)
                return;

            selectedRecipe = lbRecipes.SelectedItem.ToString(); // Update selectedRecipe
            lbSelectedRecipe.Content = $"Details for Recipe: {selectedRecipe}";

            DisplayRecipeIngredients(); // Display ingredients of the selected recipe
            DisplayRecipeSteps(); // Display steps of the selected recipe
            DisplayTotalCalories(); // Display total calories of the selected recipe
        }

        // Display ingredients of the selected recipe in lbOutput ListBox
        private void DisplayRecipeIngredients()
        {
            lbOutput.Items.Clear();

            foreach (Recipe item in ListUtils.IngList.Where(x => x.RecipeName == selectedRecipe))
            {
                // Format and display each ingredient's details
                lbOutput.Items.Add($"{item.Ingredients,-40} {item.Quantities} {item.UnitOfMeasurement,-10} Calories(Per Unit): {item.Calories,-10} Food Group: {item.FoodGroup}");
            }
        }

        // Display steps of the selected recipe in stepListBox
        private void DisplayRecipeSteps()
        {
            stepListBox.Items.Clear();

            foreach (RecipeSteps step in ListUtils.StepsList.Where(x => x.RecipeName == selectedRecipe))
            {
                stepListBox.Items.Add(step.Step);
            }
        }

        // Calculate and display total calories of the selected recipe
        private void DisplayTotalCalories()
        {
            double totalCalories = CalculateTotalCalories(ListUtils.IngList, selectedRecipe);
            lbCalories.Visibility = Visibility.Visible;
            lbCalories.Content = $"This recipe contains a total of {totalCalories} calories";
        }

        // Calculate total calories of a recipe based on its ingredients
        private double CalculateTotalCalories(List<Recipe> recipebook, string recipeName)
        {
            return recipebook.Where(x => x.RecipeName == recipeName).Sum(x => x.Calories * x.Quantities);
        }

        // Button click event handler to scale down recipe ingredients
        private void btnScale_Click(object sender, RoutedEventArgs e)
        {
            ScaleRecipeIngredients(0.5);
        }

        // Button click event handler to scale up recipe ingredients
        private void btnScale2_Click(object sender, RoutedEventArgs e)
        {
            ScaleRecipeIngredients(2);
        }

        // Button click event handler to scale up recipe ingredients further
        private void btnScale3_Click(object sender, RoutedEventArgs e)
        {
            ScaleRecipeIngredients(3);
        }

        // Scale recipe ingredients by a given factor
        private void ScaleRecipeIngredients(double factor)
        {
            lbOutput.Items.Clear();

            foreach (Recipe item in ListUtils.IngList.Where(x => x.RecipeName == selectedRecipe))
            {
                item.Quantities *= factor; // Scale the quantity of each ingredient
                lbOutput.Items.Add($"{item.Ingredients,-40} {item.Quantities} {item.UnitOfMeasurement,-10} Calories(Per Unit): {item.Calories,-10} Food Group: {item.FoodGroup}");
            }

            DisplayTotalCalories(); // Update total calories after scaling
        }

        // Button click event handler to filter recipes by ingredient
        private void btnFilterIngredients_Click(object sender, RoutedEventArgs e)
        {
            string filter = txtFilter.Text.Trim().ToLower();

            lbRecipes.Items.Clear();

            foreach (Recipe item in ListUtils.IngList.Where(x => x.Ingredients.ToLower() == filter))
            {
                lbRecipes.Items.Add(item.RecipeName);
            }
        }

        // Button click event handler to filter recipes by food group
        private void btnFilterFoodGroup_Click(object sender, RoutedEventArgs e)
        {
            string filter = txtFilter.Text.Trim().ToLower();

            lbRecipes.Items.Clear();

            foreach (Recipe item in ListUtils.IngList.Where(x => x.FoodGroup.ToLower().Contains(filter)))
            {
                if (!lbRecipes.Items.Contains(item.RecipeName))
                {
                    lbRecipes.Items.Add(item.RecipeName);
                }
            }

            if (lbRecipes.Items.Count == 0)
            {
                MessageBox.Show($"There were no recipes matching food group '{filter}'. Please reset the filter.", "Error!");
            }
        }

        // Button click event handler to filter recipes by maximum calories
        private void btnFilterCalories_Click(object sender, RoutedEventArgs e)
        {
            lbRecipes.Items.Clear();
            int maxCalories;

            if (!int.TryParse(txtFilter.Text, out maxCalories))
            {
                MessageBox.Show("Please insert a valid integer input for maximum calories.", "Error!");
                return;
            }

            // Filter recipes by maximum total calories
            IEnumerable<string> filteredRecipes = ListUtils.StepsList
                .GroupBy(x => x.RecipeName)
                .Where(group => CalculateTotalCalories(ListUtils.IngList, group.Key) <= maxCalories)
                .Select(group => group.Key);

            foreach (string recipeName in filteredRecipes)
            {
                lbRecipes.Items.Add(recipeName);
            }

            if (filteredRecipes.Count() == 0)
            {
                MessageBox.Show($"There were no recipes with total calories less than or equal to {maxCalories}. Please reset the filter.", "Notice");
            }
        }

        // Button click event handler to reset ingredient scaling
        private void btnResetScale_Click(object sender, RoutedEventArgs e)
        {
            lbOutput.Items.Clear();

            foreach (Recipe item in ListUtils.IngList.Where(x => x.RecipeName == selectedRecipe))
            {
                item.Quantities = item.OriginalQuantities; // Reset quantities to original values
                lbOutput.Items.Add($"{item.Ingredients,-40} {item.Quantities} {item.UnitOfMeasurement,-10} Calories(Per Unit): {item.Calories,-10} Food Group: {item.FoodGroup}");
            }

            DisplayTotalCalories(); // Update total calories after resetting scaling


        }
    }
}
