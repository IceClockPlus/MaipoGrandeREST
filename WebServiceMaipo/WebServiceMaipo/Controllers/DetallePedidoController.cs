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
                detalles = detalles.Where(det => det.Estado == "Pendiente").ToList();
                return detalles;

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }

        }

        [HttpGet]
        [Route("api/DetallePedidoHistorico")]
        public IEnumerable<ItemPedido> DetallesHistoricos([FromBody] SecurityViewModel model)
        {
            try
            {
                Usuario user = this.Validate(model.Token);
                List<ItemPedido> detalles = RepositorioDetallePedido.ListarPorIdProductor(user.TipoUsuario.Id);
                detalles = detalles.Where(det => det.Estado != "Pendiente").OrderByDescending(det => det.IdItemPedido).ToList();
                
                return detalles;

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return new List<ItemPedido>();
            }

        }

        [HttpGet]
        [Route("api/DetallePedidos/")]
        public IEnumerable<ItemPedido> ObtenerDetalles()
        {
            try
            {
                List<ItemPedido> detalles = new List<ItemPedido>();
                ItemPedido item = new ItemPedido();
                detalles = item.ReadAll();
                return detalles;

            }catch(Exception ex)
            {
                return new List<ItemPedido>();
            }


        }


        [HttpGet]
        [Route("api/DetallePedidos/{idPedido}")]
        public IEnumerable<ItemPedido> Get(int idPedido)
        {
            try
            {
                List<ItemPedido> detalles = new List<ItemPedido>();
                detalles = RepositorioDetallePedido.ObtenerDetallePedido(idPedido);
                return detalles;

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<ItemPedido>();
            }


        }

        // POST: api/DetallePedido
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/DetallePedido/
        public IHttpActionResult Put([FromBody]ItemPedido model)
        {
            try
            {
                if (model.Update())
                {
                    return Ok();
                }

                return NotFound();

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }


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
