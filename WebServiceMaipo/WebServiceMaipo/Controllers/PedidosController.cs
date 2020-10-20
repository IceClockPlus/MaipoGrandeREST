using LibreriaMaipo;
using LibreriaMaipo.Modelo;
using LibreriaMaipo.Proceso;
using LibreriaMaipo.TiposUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebServiceMaipo.Models.WS;

namespace WebServiceMaipo.Controllers
{
    public class PedidosController : ApiController
    {
        public IHttpActionResult PostPedido([FromBody]PedidoViewModel modelPedido)
        {
            try
            {

                Usuario user = RepositorioUsuario.GetUsuarioByToken(modelPedido.Token);
                //Negar ejecucion si el usuario no es cliente o el token no existe
                if (!(user.TipoUsuario is Cliente) || user == null)
                {
                    return Unauthorized();
                }
                Pedido pedido = new Pedido();
                pedido.Cliente = (Cliente)user.TipoUsuario;
                pedido.Ciudad = modelPedido.Ciudad;
                pedido.Direccion = modelPedido.DireccionPedido;
                pedido.Pais = modelPedido.Pais;
                pedido.FechaPedido = modelPedido.FechaPedido;
                pedido.FechaEntrega = modelPedido.FechaEntrega;
                pedido.DetallePedido = modelPedido.DetallePedido;

                ProcesoPedido proceso = new ProcesoPedido();
                proceso.Pedido = pedido;
                proceso.RegistrarNuevoPedido();

                return Ok();
                
            }
            catch (Exception)
            {

                throw;
            }

        }
        public IHttpActionResult GetPedido(int id)
        {
            try
            {
                Pedido pedido = new Pedido();
                pedido = RepositorioPedido.ObtenerPedidoPorId(id);
                if(pedido == null)
                {
                    return NotFound();
                }
                return Ok(pedido);

            }
            catch(Exception ex)
            {
                return InternalServerError();
            }

        }


    }
}
