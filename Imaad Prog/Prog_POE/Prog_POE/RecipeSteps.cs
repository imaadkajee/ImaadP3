using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_POE
{
    public class RecipeSteps
    {
        public string RecipeName { get; set; }
        public string Step { get; set; }

        // Default constructor
        public RecipeSteps()
        {
        }

        // Constructor with parameters
        public RecipeSteps(string recipeName, string step)
        {
            RecipeName = recipeName;
            Step = step;
        }
    }
}
