using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_DRINK.Models
{
    public class Bebida
    {
        //Classe de molde para que possa receber os dados de Bebida
        public Bebida()
        {

        }

        public Bebida(int idDrink, string strDrink, string strCategory, string strIngredient ,string strInstructions, string strDrinkThumb)
        {
            IdDrink = idDrink;
            StrCategory = strCategory;
            StrIngredient = strIngredient;
            StrInstructions = strInstructions;
            StrDrink = strDrink;
            StrInstructions = strInstructions;
            StrDrinkThumb = strDrinkThumb;
        }
        //AQUI acima adicionado pelo GM 25/08

        public int IdDrink { get; set; }

        public string StrCategory { get; set; }

        public string StrIngredient { get; set; }

        //public int IdCat { get; set; }

        //public int IdIngredient { get; set; }

        public string StrDrink { get; set; }

        public string StrInstructions { get; set; }

        public string StrDrinkThumb { get; set; }
    }
}