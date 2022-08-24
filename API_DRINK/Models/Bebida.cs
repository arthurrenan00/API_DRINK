using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_DRINK.Models
{
    public class Bebida
    {

        public int IdDrink { get; set; }

        public int IdCat { get; set; }

        public int IdIngredient { get; set; }

        public string StrDrink { get; set; }

        public string StrInstructions { get; set; }

        public string StrDrinkThumb { get; set; }
    }
}