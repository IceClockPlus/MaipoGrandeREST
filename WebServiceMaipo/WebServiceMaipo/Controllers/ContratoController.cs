using LibreriaMaipo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebServiceMaipo.Controllers
{
    public class ContratoController : ApiController
    {
        // GET: api/Contrato
        [HttpGet]
        public IEnumerable<Contrato> ObtenerContratos()
        {
            try
            {
                List<Contrato> contratos = new List<Contrato>();
                Contrato contrato = new Contrato();
                contratos = contrato.ReadAll();
                return contratos;


            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return (IEnumerable<Contrato>)NotFound();

            }

        }

        // GET: api/Contrato/5
        [HttpGet]
        public IHttpActionResult ObtenerContrato(int id)
        {
            try
            {
                Contrato contrato = new Contrato();
                contrato.Id = id;
                if (contrato.Read())
                {
                    return Ok(contrato);
                }
                else
                {
                    return NotFound();
                }

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        // POST: api/Contrato
        [HttpPost]
        public IHttpActionResult RegistrarContrato([FromBody]Contrato contrato)
        {
            try
            {
                if (contrato.Agregar())
                {
                    return Ok();
                }
                return BadRequest();

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return InternalServerError();
            }
            

        }

        // PUT: api/Contrato/
        public IHttpActionResult ActualizarContrato([FromBody]Contrato contrato)
        {
            try
            {
                if (contrato.Update())
                {
                    return Ok(contrato);
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

        // DELETE: api/Contrato/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                Contrato contrato = new Contrato();
                contrato.Id = id;
                if (contrato.Delete())
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }


            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }

        }
    }
}
