using LibreriaMaipo;
using LibreriaMaipo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebServiceMaipo.Models.WS;

namespace WebServiceMaipo.Controllers
{
    public class DetallePedidoController : ApiController
    {
        // GET: api/DetallePedido
        public IEnumerable<ItemPedido> GetDetallesAsignados([FromBody] SecurityViewModel model)
        {
            try
            {
                Usuario user = this.Validate(model.Token);
                List<ItemPedido> detalles = RepositorioDetallePedido.ListarPorIdProductor(user.TipoUsuario.Id);
                return detalles;

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }

        }

        // GET: api/DetallePedido/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/DetallePedido
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/DetallePedido/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/DetallePedido/5
        public void Delete(int id)
        {
        }

        public Usuario Validate(string token)
        {
            Usuario user = RepositorioUsuario.GetUsuarioByToken(token);
            return user;
        }
    }
}
