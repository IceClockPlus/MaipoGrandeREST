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
        public int Result { get; set; }
        public object Data { get; set; }
        public String Message { get; set; }
    }
}