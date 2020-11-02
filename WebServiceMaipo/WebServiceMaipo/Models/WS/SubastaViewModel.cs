using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceMaipo.Models.WS
{
    public class SubastaViewModel : SecurityViewModel
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaTermino { get; set; }
        public int IdPedido { get; set; }


    }
}