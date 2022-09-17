using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;

namespace API_DRINK.Models
{
    internal interface IProductRepository
    {
        IEnumerable<Bebida> GetAll();
        Bebida Get(int id);
        Bebida Add(Bebida registro);
        void Remove(int id);
        bool Update(Bebida registro);
    }
}