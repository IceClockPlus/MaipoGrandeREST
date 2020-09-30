using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceMaipo.Models.WS
{
    /// <summary>
    /// Modelo con el que se van a entregar las respuestas a los clientes
    /// </summary>
    public class Reply
    {
        public int result { get; set; }
        public object data { get; set; }
        public String message { get; set; }
    }
}