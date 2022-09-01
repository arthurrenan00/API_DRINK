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
        List<Bebida> bebidas = new List<Bebida>(new Bebida[] {
        new Bebida(1, 1, 1, "Água com limão", "Misture o limão com água", "https://gooutside.com.br/wp-content/uploads/sites/3/2020/03/agua-com-limao-realmente-limpa-o-organismo.jpg"),
        new Bebida(2, 2, 2, "Chá com leite", "Misture leite em pó com chá", "https://www.iguaria.com/wp-content/uploads/2022/02/Iguaria-Receita-de-Leite-com-Cha-Preto.jpg")
        }); 
            
            
            
        // GET: api/Bebida
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }



        // GET: api/Bebida/5
        [HttpGet]
        [ActionName("getBebida")]
        public Bebida Get(int id)
        {
            var bebida = bebidas.FirstOrDefault((p) => p.IdDrink == id);
            if (bebida == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound);
                throw new HttpResponseException(resp);
            }
            return bebida;  
        }



        //GET: api/Bebida/getAll

        [HttpGet]
        [ActionName("getAll")]
        public IEnumerable<Bebida> GetAllBebidas()
        {
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
        }

        //Modifiquei acima GM 2508

        // POST: api/Bebida
        [HttpPost]
        [ActionName("addItens")]
        public HttpResponseMessage Post([FromBody] List<Bebida> itens)
        {
            if (itens == null)
            {
                return new HttpResponseMessage(HttpStatusCode.NotModified);
            }
            bebidas.AddRange(itens);
            var response = new HttpResponseMessage(HttpStatusCode.Created);
            return response;
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

            int index = bebidas.IndexOf((Bebida)bebidas.Where((p) => p.IdDrink == id).FirstOrDefault());
            bebidas[index] = item;

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
        [ActionName("delete")]
        public HttpResponseMessage Delete(int id)
        {
            Bebida beb = (Bebida)bebidas.Where((p) => p.IdDrink == id);
            int index = bebidas.IndexOf(beb);
            bebidas.RemoveAt(index);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
