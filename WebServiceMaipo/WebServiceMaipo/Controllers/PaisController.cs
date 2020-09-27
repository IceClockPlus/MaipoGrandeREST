using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LibreriaMaipo;

namespace WebServiceMaipo.Controllers
{
    public class PaisController : ApiController
    {
        public IEnumerable<Pais> Get()
        {
            var lista = RepositorioPaises.listarPaises();
            return lista;
        }
    }
}
