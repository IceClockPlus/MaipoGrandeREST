using LibreriaMaipo.Modelo;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebServiceMaipo.Controllers
{
    public class RolController : ApiController
    {
        // GET: api/Rol
        public IEnumerable<Rol> Get()
        {

            try
            {
                List<Rol> roles = new List<Rol>();
                Rol rol = new Rol();
                roles = rol.ReadAll();
                return roles;

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return (IEnumerable<Rol>)NotFound();
            }

        }

        // GET: api/Rol/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                Rol rol = new Rol();
                rol.IdRol = id;
                //Buscar el rol con la id anteriormente asignada
                if(rol.Read() == true)
                {
                    return Ok(rol);
                }
                else
                {
                    return NotFound();
                }
                

            }catch(Exception ex)
            {
                return BadRequest();
            }

        }

        // POST: api/Rol
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Rol/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Rol/5
        public void Delete(int id)
        {
        }
    }
}
