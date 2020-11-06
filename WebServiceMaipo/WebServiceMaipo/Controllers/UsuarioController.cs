using LibreriaMaipo;
using LibreriaMaipo.Modelo;
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
    public class UsuarioController : ApiController
    {
        [HttpGet]
        [Route("api/Usuario/{idUsuario}")]
        public IHttpActionResult Get(int idUsuario)
        {
            try
            {
                Usuario user = new Usuario();
                user = RepositorioUsuario.Read(idUsuario);
                if(user != null)
                {
                    return Ok(user);

                }
                return NotFound();

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();

            }

        }


        public IHttpActionResult GetByToken([FromBody] SecurityViewModel model)
        {
            Usuario user;
            try
            {
                user = RepositorioUsuario.GetUsuarioByToken(model.Token);
                if (user == null)
                {
                    return NotFound();
                }
                
                return Ok(user);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IHttpActionResult RegistrarUsuario([FromBody] Usuario modelUser)
        {
            try
            {
                RepositorioUsuario.Agregar(modelUser);
                return Ok();


            }catch(Exception ex)
            {
                ex.Message.ToString();
                return BadRequest();
            }


        }


    }
}
