using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Final_POE
{
    
    public partial class InsertRecipe : Window
    {
        public static string RecipeName;
        public InsertRecipe()
        {
            InitializeComponent();
        }

        private void btnNameComplete_Click(object sender, RoutedEventArgs e)
        {
            RecipeName = txtRecipeName.Text;
            this.Close();
            InsertIng InsertIng = new InsertIng();
            InsertIng.Show();
        }
    }
}
