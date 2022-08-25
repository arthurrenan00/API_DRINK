using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_DRINK.Models
{
    public class Categoria
    {
        //Aqui abaixo adicionado pelo GM 2508
        public Categoria() { 
        }

        public Categoria(int idCat, string strCategory)
        {
            IdCat = idCat;
            StrCategory = strCategory;
        }   
        //Aqui acima adicionado pelo GM 2508

        public int IdCat { get; set; }

        public string StrCategory { get; set; }
    }
}