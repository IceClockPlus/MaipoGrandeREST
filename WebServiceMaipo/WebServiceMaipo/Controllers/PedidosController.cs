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
                if (!(user.TipoUsuario is Cliente ) || user == null)
                {
                    return Unauthorized();
                }

                //Generar el prdido
                Pedido pedido = new Pedido();
                pedido.Cliente = (Cliente)user.TipoUsuario;
                pedido.Ciudad = modelPedido.Ciudad;
                pedido.Direccion = modelPedido.DireccionPedido;
                pedido.Pais = modelPedido.Pais;
                pedido.FechaPedido = modelPedido.FechaPedido;
                pedido.FechaEntrega = modelPedido.FechaEntrega;

                //Obtener los detalles 
                foreach(var det in modelPedido.DetallePedido)
                {
                    ItemPedido item = new ItemPedido();
                    item.Cantidad = det.Cantidad;
                    item.Calidad = det.Calidad;
                    item.Producto.IdProducto = det.Producto.IdProducto;
                    pedido.DetallePedido.Add(item);
                }

                ProcesoPedido proceso = new ProcesoPedido();
                proceso.Pedido = pedido;
                proceso.RegistrarNuevoPedido();

                return Ok();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }

        }
        public IHttpActionResult GetPedido(int id)
        {
            try
            {
                Pedido pedido = new Pedido();
                //Obtener pedido por su id
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

        [HttpPut]
        public HttpResponseMessage Put([FromBody] Pedido pedido)
        {
            try
            {

                if (pedido.Update())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, pedido);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, pedido);
                }

            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut]
        [Route("api/PedidoPutEstado")]
        public HttpResponseMessage PutPedidoEstado([FromBody] Pedido pedido)
        {
            try
            {

                if (pedido.UpdateEstado())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, pedido);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, pedido);
                }

            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }


        [HttpGet]
        public IEnumerable<Pedido> GetAll()
        {

            try
            {
                List<Pedido> pedidos = new List<Pedido>();
                pedidos = RepositorioPedido.ReadAll();
                return pedidos;


            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Pedido>();
            }
            

        }

        [HttpGet]
        [Route("api/PedidosCliente")]
        public IEnumerable<Pedido>GetPedidosCliente([FromBody] SecurityViewModel model)
        {
            try
            {
                List<Pedido> pedidos = new List<Pedido>();

                Usuario user = this.Validate(model.Token);
                if(user != null)
                {
                    pedidos = RepositorioPedido.ObtenerPedidoPorIdCliente(user.TipoUsuario.Id);
                }
                pedidos = pedidos.OrderByDescending(p => p.IdPedido).ToList();

                return pedidos;


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Pedido>();
            }


        }

        public Usuario Validate(string token)
        {
            try
            {
                Usuario usuario = new Usuario();
                usuario = RepositorioUsuario.GetUsuarioByToken(token);

                return usuario;

            }
            catch (Exception ex)
            {
                return new Usuario();
            }
        }


    }
}
