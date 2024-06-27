using System;
using System.Windows;

namespace Final_POE
{
    public partial class InsertSteps : Window
    {
        public InsertSteps()
        {
            InitializeComponent();
        }

        private void btnAddSteps_Click(object sender, RoutedEventArgs e)
        {
            if (InsertRecipe.RecipeName != null) // Ensure InsertRecipe.RecipeName is properly set
            {
                RecipeSteps rs = new RecipeSteps(InsertRecipe.RecipeName, tbSteps.Text);
                ListUtils.StepsList.Add(rs);
                tbSteps.Text = "";
            }
            else
            {
                MessageBox.Show("Recipe name not set.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnComplete_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Close the current InsertSteps window
        }
    }
}
