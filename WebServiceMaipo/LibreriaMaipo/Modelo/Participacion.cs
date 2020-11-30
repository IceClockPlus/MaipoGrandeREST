using DatoMaipo;
using LibreriaMaipo.TiposUsuario;
using LibreriaMaipo.UsuarioFactory;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaMaipo.Modelo
{
    public class Participacion
    {
        public int IdParticipacion { get; set; }
        public int IdPedido { get; set; }
        public Productor Productor { get; set; }
        public string EstadoParticipacion { get; set; }
        public Pedido Pedido { get; set; }

        public Participacion()
        {
            this.InitClass();
        }

        private void InitClass()
        {
            this.IdParticipacion = 0;
            this.IdPedido = 0;
            this.Productor = new Productor();
            this.Pedido = new Pedido();
            this.EstadoParticipacion = string.Empty;
        }

        /// <summary>
        /// Agregar participacion del productor en el pedido
        /// </summary>
        /// <returns></returns>
        public bool Agregar()
        {
            try
            {
                using (var db = new DBEntities())
                {
                    db.SP_INSERT_PARTICIPACION(this.Productor.Id,this.IdPedido);
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
                    db.SP_UPDATE_PARTICIPACION(this.IdParticipacion, this.Productor.Id, this.IdPedido, this.EstadoParticipacion);
                    return true;

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }


        public List<Participacion> ReadAll()
        {
            try
            {
                TipoUsuarioFactory factory = new ProductorFactory();

                List<Participacion> list = new List<Participacion>();
                using (var db = new DBEntities())
                {
                    var listado = db.PARTICIPACION.ToList();
                    if(listado.Count > 0)
                    {
                        foreach(var par in listado)
                        {
                            Participacion participacion = new Participacion();
                            participacion.IdParticipacion = (int)par.IDPARTICIPACION;
                            participacion.IdPedido = (int)par.PEDIDO.IDPEDIDO;
                            participacion.EstadoParticipacion = par.ESTADOPARTICIPACION;

                            TipoUsuario productor = factory.createTipoUsuario();
                            int idProductor = (int)par.IDPRODUCTOR;
                            productor.ObtenerDatosPorId(idProductor);
                            participacion.Productor = (Productor)productor;




                            list.Add(participacion);

                        }

                    }
                    return list;


                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Participacion>();
            }
        }

        /// <summary>
        /// Listar todas las participaciones de un pedido
        /// </summary>
        /// <returns></returns>
        public List<Participacion> ReadByIdPedido()
        {
            try
            {
                List<Participacion> participaciones = new List<Participacion>();
                //Llama todos las participaciones
                participaciones = this.ReadAll();

                List<Participacion> participacionPedido = participaciones.Where(p => p.Pedido.IdPedido == this.Pedido.IdPedido).ToList();
                return participacionPedido;

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Participacion>();
            }

        }


    }
}
