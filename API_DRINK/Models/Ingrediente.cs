using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_DRINK.Models
{
    public class Ingrediente
    {
        //Aqui abaixo foi adicionado pelo GM 2508
        public Ingrediente()
        {

        }

        public Ingrediente(int idIngredient, string strIngredient)
        {
            IdIngredient = idIngredient;
            StrIngredient = strIngredient;
        }
        //Aqui acima foi adicionado pelo GM 2508

        public int IdIngredient { get; set; }

        public string StrIngredient { get; set; }

    }
}