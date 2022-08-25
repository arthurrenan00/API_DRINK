using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_DRINK.Models
{
    public class Bebida
    {
        //AQUI abaixo adicionado pelo GM 25/08
        public Bebida()
        {

        }

        public Bebida(int idDrink, int idCat, int idIngredient, string strDrink, string strInstructions, string strDrinkThumb)
        {
            IdDrink = idDrink;
            IdCat = idCat;
            IdIngredient = idIngredient;
            StrDrink = strDrink;
            StrInstructions = strInstructions;
            StrDrinkThumb = strDrinkThumb;
        }
        //AQUI acima adicionado pelo GM 25/08

        public int IdDrink { get; set; }

        public int IdCat { get; set; }

        public int IdIngredient { get; set; }

        public string StrDrink { get; set; }

        public string StrInstructions { get; set; }

        public string StrDrinkThumb { get; set; }
    }
}