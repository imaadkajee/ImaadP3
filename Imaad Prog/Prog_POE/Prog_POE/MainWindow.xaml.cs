
using System.Windows;



namespace Final_POE
{
   
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnEnterRecipe_Click(object sender, RoutedEventArgs e)
        {
            InsertRecipe InsertRecipe = new InsertRecipe();
            InsertRecipe.ShowDialog();
        }

        private void btnViewRecipes_Click(object sender, RoutedEventArgs e)
        {
            RecipeView RecipeView = new RecipeView();
            RecipeView.ShowDialog();
        }
    }
}