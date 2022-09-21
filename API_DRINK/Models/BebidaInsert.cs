using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_DRINK.Models
{
    public class BebidaInsert
    {
        public BebidaInsert()
        {

        }

        public BebidaInsert(string strIngredient, string strCategory, int idDrink, string strDrink, string strInstructions, string strDrinkThumb)
        {
            StrInstructions = strInstructions;
            StrCategory = strCategory;
            IdDrink = idDrink;
            StrDrink = strDrink;
            StrInstructions = strInstructions;
            StrDrinkThumb = strDrinkThumb;
        }
        //AQUI acima adicionado pelo GM 25/08

        public int IdDrink { get; set; }

        public string StrCategory { get; set; }

        //public int IdCat { get; set; }

        //public int IdIngredient { get; set; }

        public string StrDrink { get; set; }

        public string StrInstructions { get; set; }

        public string StrDrinkThumb { get; set; }
    }
}