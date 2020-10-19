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


    }
}
