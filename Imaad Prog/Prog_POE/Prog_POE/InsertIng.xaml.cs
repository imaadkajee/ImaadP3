using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Final_POE
{
    /// <summary>
    /// Interaction logic for InsertIng.xaml
    /// </summary>
    public partial class InsertIng : Window
    {
        public delegate double CalorieDelegate(List<Recipe> recipebook, string recipe);

        public InsertIng()
        {
            InitializeComponent();
        }

        private void BtnAddNewIng_Click(object sender, RoutedEventArgs e)
        {
            string ingName = txtIngName.Text;

            // Handle parsing errors for quantity and calories
            if (!double.TryParse(txtIngQuantity.Text, out double ingQuantity))
            {
                MessageBox.Show("Please enter a valid number for Quantity.", "Error");
                return;
            }

            double originalQuantities = ingQuantity; // Assuming this should be assigned from ingQuantity

            string ingUOM = cmbUnitOfMeasurement.Text;

            if (!double.TryParse(txtCalories.Text, out double ingCalories))
            {
                MessageBox.Show("Please enter a valid number for Calories.", "Error");
                return;
            }

            string ingFoodGroup = cmbFoodGroup.Text;

            Recipe ingInfo = new Recipe(InsertRecipe.RecipeName, ingName, ingQuantity, ingUOM, ingCalories, ingFoodGroup);
            ListUtils.IngList.Add(ingInfo);
        }

        private void TxtCalories_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Optional: Add any specific handling logic for text changed event
        }

        private void BtnProceed_Click(object sender, RoutedEventArgs e)
        {
            // Ensure the delegate usage is correct
            Delegate del = new Delegate(); // Consider a more descriptive name for the delegate class
            CalorieDelegate calorieDelegate = new CalorieDelegate(del.CalorieAlert);
            calorieDelegate(ListUtils.IngList, InsertRecipe.RecipeName);

            this.Close();

            InsertSteps insertSteps = new InsertSteps();
            insertSteps.Show();
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            // Clear the text of text boxes
            txtIngName.Text = string.Empty;
            txtIngQuantity.Text = string.Empty;
            cmbUnitOfMeasurement.Text = string.Empty;
            txtCalories.Text = string.Empty;

            // Clear the selection of the combo box
            cmbFoodGroup.SelectedIndex = -1;
        }
    }
}
