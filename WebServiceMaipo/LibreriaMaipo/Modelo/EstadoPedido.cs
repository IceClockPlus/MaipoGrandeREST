using DatoMaipo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaMaipo.Modelo
{
    /// <summary>
    /// Clase que indica el estado en el que se encuentra el pedido de los clientes
    /// </summary>
    public class EstadoPedido
    {
        /// <summary>
        /// Campo que indica la identificacion del estado del pedido
        /// </summary>
        public int IdEstado { get; set; }
        /// <summary>
        /// Campo que muestra la descripcion del estado del pedido
        /// </summary>
        public string DescripcionEstado { get; set; }

        public EstadoPedido()
        {
            this.InitClass();
        }

        private void InitClass()
        {
            this.IdEstado = 0;
            this.DescripcionEstado = string.Empty;
        }

        public List<EstadoPedido> ReadAll()
        {
            try
            {
                List<EstadoPedido> list = new List<EstadoPedido>();
                using (var db = new DBEntities())
                {
                    var listadoEstados = db.ESTADOPEDIDO.ToList();
                    if(listadoEstados.Count > 0)
                    {
                        foreach(var es in listadoEstados)
                        {
                            EstadoPedido estado = new EstadoPedido();
                            estado.IdEstado = (int)es.IDESTADOPEDIDO;
                            estado.DescripcionEstado = es.DESCRIPCIONESTADO;
                            list.Add(estado);
                        }
                    }

                    return list;

                }


            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<EstadoPedido>();

            }

        }


    }
}
