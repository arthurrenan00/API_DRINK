using System;
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

        /*

        // GET: api/Bebida/5
        public string Get(int id)
        {
            return "value";
        }
        */

        //GET: api/Bebida/getAll

        [HttpGet]
        [ActionName("getAll")]
        public IEnumerable GetAllBebidas()
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
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Bebida/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Bebida/5
        public void Delete(int id)
        {
        }
    }
}
