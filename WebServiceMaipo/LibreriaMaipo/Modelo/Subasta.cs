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
        public List<OfertaSubasta> OfertasSubasta { get; set; }

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
            this.OfertasSubasta = new List<OfertaSubasta>();
        }

        /// <summary>
        /// Metodo para agregar subastas a la base de datos
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Metodo para actualizar una subasta registrada
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Metodo para eliminar una subasta
        /// </summary>
        /// <returns></returns>
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
        public bool Read()
        {
            try
            {
                using (var db = new DBEntities())
                {
                    SUBASTA subasta = db.SUBASTA.Where(sb => sb.IDSUBASTA == this.IdSubasta).FirstOrDefault();
                    if(subasta != null)
                    {
                        this.FechaInicio = subasta.FECHAINICIO;
                        this.FechaTermino = subasta.FECHATERMINO;

                        //Obtener Estado subasta
                        EstadoSubasta estado = new EstadoSubasta();
                        estado.IdEstadoSubasta = (int)subasta.IDESTADOSUBASTA;
                        estado.Read();
                        this.EstadoSubasta = estado;

                        //Obtener el pedido asociada a la subasta
                        Pedido pedido = new Pedido();
                        pedido.IdPedido = (int)subasta.IDPEDIDO;
                        pedido.Read();
                        this.Pedido = pedido;
                        this.OfertasSubasta = OfertaSubasta.ReadByIdSubasta(this.IdSubasta);

                        return true;
                    }

                    return false;
                }

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }

        /// <summary>
        /// Metodo que entrega un listado con todas las subastas registradas
        /// </summary>
        /// <returns></returns>
        public List<Subasta> ReadAll()
        {
            List<Subasta> list = new List<Subasta>();
            try
            {
                using (var db = new DBEntities())
                {
                    var listadoSubastas = db.SUBASTA.ToList();
                    if (listadoSubastas.Count() > 0)
                    {
                        foreach(var s in listadoSubastas)
                        {
                            Subasta subasta = new Subasta();
                            subasta.IdSubasta = (int)s.IDSUBASTA;
                            subasta.FechaInicio = s.FECHAINICIO;
                            subasta.FechaTermino = s.FECHATERMINO;

                            //Obtener Estado subasta
                            EstadoSubasta estado = new EstadoSubasta();
                            estado.IdEstadoSubasta = (int)s.IDESTADOSUBASTA;
                            estado.Read();
                            subasta.EstadoSubasta = estado;

                            //Obtener el pedido asociada a la subasta
                            Pedido pedido = new Pedido();
                            pedido.IdPedido = (int)s.IDPEDIDO;
                            pedido.Read();
                            subasta.Pedido = pedido;
                            subasta.OfertasSubasta = OfertaSubasta.ReadByIdSubasta(this.IdSubasta);
                            list.Add(subasta);
                        }
                    }

                    return list;
                }

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Subasta>();
            }
        }


        public bool ReadByIdPedido()
        {
            try
            {
                List<Subasta> subastas = new List<Subasta>();
                subastas = this.ReadAll();
                var subasta = subastas.Where(s => s.Pedido.IdPedido == this.Pedido.IdPedido).FirstOrDefault();
                if(subasta != null)
                {
                    this.IdSubasta = subasta.IdSubasta;
                    this.FechaInicio = subasta.FechaInicio;
                    this.FechaTermino = subasta.FechaTermino;
                    this.EstadoSubasta = subasta.EstadoSubasta;
                    this.OfertasSubasta = OfertaSubasta.ReadByIdSubasta(this.IdSubasta);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }


    }
}
