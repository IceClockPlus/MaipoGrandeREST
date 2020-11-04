using DatoMaipo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaMaipo.Modelo
{
    public class Subasta
    {
        public int IdSubasta { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaTermino { get; set; }
        public EstadoSubasta EstadoSubasta { get; set; }
        public Pedido Pedido { get; set; }
        public List<OfertaSubasta> OfertaSubasta { get; set; }

        public Subasta()
        {
            this.InitClass();
        }

        private void InitClass()
        {
            this.IdSubasta = 0;
            this.FechaInicio = DateTime.Today;
            this.FechaTermino = DateTime.Today;
            this.EstadoSubasta = new EstadoSubasta();
            this.Pedido = new Pedido();
            this.OfertaSubasta = new List<OfertaSubasta>();
        }


        public bool Agregar()
        {
            try
            {
                using (var db = new DBEntities())
                {
                    db.SP_INSERT_SUBASTA(this.FechaInicio, this.FechaTermino, this.EstadoSubasta.IdEstadoSubasta, this.Pedido.IdPedido);
                    return true;

                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }

        public bool Update()
        {
            try
            {
                using (var db = new DBEntities())
                {
                    db.SP_ACTUALIZAR_SUBASTA(this.IdSubasta, this.FechaInicio, this.FechaTermino, this.Pedido.IdPedido, this.EstadoSubasta.IdEstadoSubasta);
                    return true;

                }

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Delete()
        {
            try
            {
                using (var db = new DBEntities())
                {
                    db.SP_ELIMINAR_SUBASTA(this.IdSubasta);
                    return true;
                }

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Obtener la subasta de acuerdo a la id asignada a la instancia
        /// </summary>
        /// <returns></returns>
        public void Read()
        {
            try
            {
                using (var db = new DBEntities())
                {
                    SUBASTA subasta = db.SUBASTA.Where(sb => sb.IDSUBASTA == this.IdSubasta).FirstOrDefault();



                }

            }catch(Exception ex)
            {

            }

        }


    }
}
