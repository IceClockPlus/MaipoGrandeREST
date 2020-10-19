using DatoMaipo;
using LibreriaMaipo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaMaipo
{
    public class RepositorioEstadoPedido
    {
        public static EstadoPedido ObtenerEstadoPedidoById(int id)
        {
            using (var db = new DBEntities())
            {
                try
                {
                    var query = db.ESTADOPEDIDO.Where(estado => estado.IDESTADOPEDIDO == id).FirstOrDefault();
                    EstadoPedido estadoPedido = new EstadoPedido();
                    estadoPedido.IdEstado = (int)query.IDESTADOPEDIDO;
                    estadoPedido.DescripcionEstado = query.DESCRIPCIONESTADO;

                    return estadoPedido;
                    
                }catch(Exception ex)
                {
                    return null;
                }


            }
        }

    }
}
