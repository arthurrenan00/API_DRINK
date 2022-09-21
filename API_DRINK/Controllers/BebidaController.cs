using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API_DRINK.Models;

namespace API_DRINK.Controllers
{
    public class BebidaController : ApiController
    {   //Modifiquei daqui para baixo GM 2508
        public List<Bebida> bebida = new List<Bebida>();
        





        // GET: api/Bebida/5
        //[HttpGet]
        //[ActionName("getBebida")]
        //public Bebida Get(int id)
        //{
        //    var bebida = bebidas.FirstOrDefault((p) => p.IdDrink == id);
        //    if (bebida == null)
        //    {
        //        var resp = new HttpResponseMessage(HttpStatusCode.NotFound);
        //        throw new HttpResponseException(resp);
        //    }
        //    return bebida;  
        //}



        //GET: api/Bebida/getAll

        [HttpGet]
        [ActionName("getAll")]
        public IEnumerable<Bebida> GetAllBebidas()
        {
            DBConnection db = new DBConnection();
            var itens = db.MostraTodos();
            return itens;
            /*
            try
            {
                DBConnection db = new DBConnection();
                var registro = db.MostraTodos();
                db.Fechar();
                return registro;
            }
            catch(Exception e)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                throw new HttpResponseException(resp);
            }
            */
        }

        //Modifiquei acima GM 2508

        // POST: api/Bebida
        [HttpPost]
        [ActionName("addItens")]
        public void Post([FromBody] Bebida itens)
        {
            if (itens == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }

            DBConnection db = new DBConnection();
            db.AddBebida(itens);
        }


        // PUT: api/Livro/5
        [HttpPut]
        [ActionName("updateItem")]
        public HttpResponseMessage Put(int id, [FromBody] Bebida item)
        {

            if (item == null)
            {
                return new HttpResponseMessage(HttpStatusCode.NotModified);
            }

            DBConnection db = new DBConnection();
            db.UpdateBebida(item);
            db.Fechar();

            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }

        //[HttpGet]
        //[ActionName("getByCategoria")]
        //public IEnumerable GetBebidasByCategory(string categoria)
        //{
        //    return bebidas.Where(
        //        (p) => string.Equals(p.Ca, categoria,
        //            StringComparison.OrdinalIgnoreCase));
        //}


        [HttpDelete]
        [ActionName("deleteItem")]
        public HttpResponseMessage Delete(int idDrink)
        {
            DBConnection db = new DBConnection();
            db.DeleteBebida(idDrink);
            db.Fechar();

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
