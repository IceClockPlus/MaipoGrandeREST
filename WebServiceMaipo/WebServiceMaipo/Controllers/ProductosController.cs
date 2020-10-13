using LibreriaMaipo;
using LibreriaMaipo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;

namespace WebServiceMaipo.Controllers
{
    public class ProductosController : ApiController
    {
        [HttpGet]
        public IEnumerable<Producto> GetAllProductos()
        {
            IEnumerable<Producto> listProducto;
            try
            {
                listProducto= MantenedorProducto.ListarTodos();
                return listProducto;
            }
            catch(Exception ex)
            {
                return null;
            }
            
        }

        [Route("productoCreado")]
        public IHttpActionResult GetById(int id)
        {
            try
            {
                var producto = MantenedorProducto.BuscarPorId(id);
                if (producto == null)
                {
                    return NotFound();
                }
                return Ok(producto);
            }
            catch (Exception ex)
            {

                return InternalServerError(); 
            }

        } 

        [HttpPost]
        public IHttpActionResult Post([FromBody]Producto producto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(MantenedorProducto.Agregar(producto)==true)
                    {
                        return Ok();
                    }



                }
                return BadRequest();


            }
            catch (Exception ex)
            {

                return InternalServerError();
            }

        }

    }
}
