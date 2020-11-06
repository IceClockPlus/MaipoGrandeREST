using DatoMaipo;
using LibreriaMaipo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaMaipo
{
    public class RepositorioSubasta
    {
        public static void Agregar(Subasta subasta)
        {
            using(var db = new DBEntities())
            {
                try
                {
                    SUBASTA s = new SUBASTA();
                    s.FECHAINICIO = subasta.FechaInicio;
                    s.FECHATERMINO = subasta.FechaTermino;
                    s.IDPEDIDO = subasta.Pedido.IdPedido;
                    s.IDESTADOSUBASTA = 1;

                    db.SUBASTA.Add(s);
                    db.SaveChanges();

                    subasta.IdSubasta = (int)s.IDSUBASTA;

                }catch(Exception ex)
                {
                    ex.Message.ToString();
                }


            }

        }

        public static List<Subasta> ListarSubastaPorEstado(int idEstado)
        {
            List<Subasta> subastas = new List<Subasta>();
            using (var db = new DBEntities())
            {
                try
                {
                    var querySubastas = db.SUBASTA.Include("ESTADOSUBASTA").Where(sub => sub.IDESTADOSUBASTA==idEstado).ToList();

                    foreach (var dbSubasta in querySubastas)
                    {
                        Subasta subasta = new Subasta();
                        subasta.IdSubasta = (int)dbSubasta.IDSUBASTA;
                        subasta.FechaInicio = dbSubasta.FECHAINICIO;
                        subasta.FechaTermino = dbSubasta.FECHATERMINO;
                        EstadoSubasta estadoSubasta = new EstadoSubasta
                        {
                            IdEstadoSubasta = (int)dbSubasta.IDESTADOSUBASTA,
                            Descripcion = dbSubasta.ESTADOSUBASTA.DESCRIPCION
                        };
                        subasta.EstadoSubasta = estadoSubasta;
                        subasta.OfertasSubasta = RepositorioOfertaSubasta.ListarOfertaPorIdSubasta(subasta.IdSubasta);
                        subasta.Pedido = RepositorioPedido.ObtenerPedidoPorId((int)dbSubasta.IDPEDIDO);
                        subastas.Add(subasta);
                    }
                    return subastas;

                }
                catch (Exception ex)
                {
                    ex.InnerException.ToString();
                    return null;
                }

            }

        }

        public static List<Subasta> ListarSubastas()
        {
            List<Subasta> subastas = new List<Subasta>();
            using (var db = new DBEntities())
            {
                try
                {
                    var querySubastas = db.SUBASTA.Include("ESTADOSUBASTA").ToList();

                    foreach(var dbSubasta in querySubastas)
                    {
                        Subasta subasta = new Subasta();
                        subasta.IdSubasta = (int)dbSubasta.IDSUBASTA;
                        subasta.FechaInicio = dbSubasta.FECHAINICIO;
                        subasta.FechaTermino = dbSubasta.FECHATERMINO;
                        EstadoSubasta estadoSubasta = new EstadoSubasta
                        {
                            IdEstadoSubasta = (int)dbSubasta.IDESTADOSUBASTA,
                            Descripcion = dbSubasta.ESTADOSUBASTA.DESCRIPCION
                        };

                        subasta.EstadoSubasta = estadoSubasta;
                        subasta.Pedido = RepositorioPedido.ObtenerPedidoPorId((int)dbSubasta.IDPEDIDO);
                        subastas.Add(subasta);
                    }
                    return subastas;

                }catch(Exception ex)
                {
                    ex.InnerException.ToString();
                    return null;
                }

            }



        }


    }
}
