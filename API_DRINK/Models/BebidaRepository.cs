using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API_DRINK.Models;

namespace API_DRINK.Models
{
    public class BebidaRepository : IProductRepository
    {
        private List<Bebida> bebidas = new List<Bebida>();
        private int nextId = 1;


        //Adiconndo dados a api
        public BebidaRepository()
        {
            //o ideal que seja um banco de dados
            Add(new Bebida { StrDrink  = "Água com limão" });
           
        }
        public Bebida Add(Bebida bebida)
        {
            if (bebida == null)
            {
                throw new ArgumentNullException("bebida");
            }

            bebida.IdDrink= nextId++;
            bebidas.Add(bebida);
            return bebida;
        }

        public Bebida Get(int id)
        {
            return bebidas.Find(p => p.IdDrink == id);
        }

        public IEnumerable<Bebida> GetAll()
        {
            return bebidas;
        }

        public void Remove(int id)
        {
            bebidas.RemoveAll(p => p.IdDrink == id);
        }

        public bool Update(Bebida registro)
        {
            if (registro == null)
            {
                throw new ArgumentNullException("registro");
            }

            int index = bebidas.FindIndex(p => p.IdDrink == registro.IdDrink);
            if (index == -1)
            {
                return false;
            }
            bebidas.RemoveAt(index);
            bebidas.Add(registro);
            return true;
        }
    }
}