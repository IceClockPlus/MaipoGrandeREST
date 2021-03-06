﻿using LibreriaMaipo;
using LibreriaMaipo.TiposUsuario;
using LibreriaMaipo.UsuarioFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebServiceMaipo.Controllers
{
    public class ProductorController : ApiController
    {
        // GET: api/Productor
        [HttpGet]
        public IEnumerable<TipoUsuario> ObtenerProductores()
        {
            try
            {
                TipoUsuarioFactory factory = new ProductorFactory();
                TipoUsuario prod = factory.createTipoUsuario();
                List<TipoUsuario> listado = prod.ReadAll();
                return listado;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        // GET: api/Productor/5
        public string ObtenerProductor(int id)
        {
            return "value";
        }

        // POST: api/Productor
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Productor/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Productor/5
        public void Delete(int id)
        {
        }
    }
}
