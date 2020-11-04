using DatoMaipo;
using LibreriaMaipo.Modelo;
using LibreriaMaipo.UsuarioFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaMaipo
{
    public class RepositorioOfertaSubasta
    {
        /// <summary>
        /// Agregar una oferta de transporte en una subasta
        /// </summary>
        /// <param name="oferta"></param>
        /// <param name="idSubasta"></param>
        public static void AgregarOfertaSubasta(OfertaSubasta oferta, int idSubasta)
        {
            using (var db = new DBEntities())
            {
                try
                {
                    //Asignar valores a la entidad a agregar
                    OFERTASUBASTA dbOferta = new OFERTASUBASTA();
                    dbOferta.IDSUBASTA = idSubasta;
                    dbOferta.SELECCIONADO = oferta.Seleccionado;
                    dbOferta.IDTRANSPORTISTA = oferta.Transportista.Id;
                    dbOferta.IDTIPOTRANSPORTE = oferta.TipoTransporte.IdTipo;
                    dbOferta.PRECIOOFERTA = (decimal)oferta.PrecioOferta;
                    dbOferta.FECHAOFERTA = oferta.FechaOferta;
                    //Agregar entidad a la base de datos y confirmar el cambio
                    db.OFERTASUBASTA.Add(dbOferta);
                    db.SaveChanges();
                }
                catch (Exception ex) 
                {
                    ex.InnerException.ToString();
                }

            }
        }

        /// <summary>
        /// Buscar las ofertas de subastas segun la id del transportista
        /// </summary>
        /// <param name="idTransportista"></param>
        /// <returns></returns>
        public static List<OfertaSubasta> ListarPorIdTransportista(int idTransportista)
        {
            //Creacion de una factory de Transportista
            TipoUsuarioFactory factory = new TransportistaFactory();
            using (var db = new DBEntities())
            {
                try
                {
                    List<OfertaSubasta> listado = new List<OfertaSubasta>();
                    var queryOfertas = db.OFERTASUBASTA.Where(ofer => ofer.IDTRANSPORTISTA == idTransportista).ToList();

                    foreach (var oferta in queryOfertas)
                    {
                        OfertaSubasta ofertaSubasta = new OfertaSubasta();
                        ofertaSubasta.IdOferta = (int)oferta.IDOFERTA;
                        ofertaSubasta.FechaOferta = oferta.FECHAOFERTA;
                        ofertaSubasta.Seleccionado = oferta.SELECCIONADO;
                        ofertaSubasta.PrecioOferta = (float)oferta.PRECIOOFERTA;
                        ofertaSubasta.Transportista = (TiposUsuario.Transportista)factory.createTipoUsuario();
                        ofertaSubasta.Transportista.ObtenerDatosPorId(idTransportista);

                        TipoTransporte tipo = new TipoTransporte();
                        tipo.IdTipo = (int)oferta.IDTIPOTRANSPORTE;
                        tipo.GetById();
                        ofertaSubasta.TipoTransporte = tipo;
                        listado.Add(ofertaSubasta);
                    }
                    return listado;

                }
                catch (Exception ex)
                {
                    return null;
                }

            }


        }

        /// <summary>
        /// Buscar las ofertas de las subastas segun la id de esta
        /// </summary>
        /// <param name="idSubasta"></param>
        /// <returns></returns>
        public static List<OfertaSubasta> ListarOfertaPorIdSubasta(int idSubasta)
        {
            //Creacion de una factory de Transportista
            TipoUsuarioFactory factory = new TransportistaFactory();
            using (var db = new DBEntities())
            {
                try
                {
                    List<OfertaSubasta> listado = new List<OfertaSubasta>();

                    var queryOfertas = db.OFERTASUBASTA.Where(ofer => ofer.IDSUBASTA == idSubasta).ToList();
                    foreach(var oferta in queryOfertas)
                    {
                        OfertaSubasta ofertaSubasta = new OfertaSubasta();
                        ofertaSubasta.IdOferta = (int)oferta.IDOFERTA;
                        ofertaSubasta.FechaOferta = oferta.FECHAOFERTA;
                        ofertaSubasta.Seleccionado = oferta.SELECCIONADO;
                        ofertaSubasta.PrecioOferta = (float)oferta.PRECIOOFERTA;
                        ofertaSubasta.Transportista = (TiposUsuario.Transportista)factory.createTipoUsuario();
                        ofertaSubasta.Transportista.ObtenerDatosPorId((int)oferta.IDTRANSPORTISTA);

                        TipoTransporte tipo = new TipoTransporte();
                        tipo.IdTipo = (int)oferta.IDTIPOTRANSPORTE;
                        tipo.GetById();
                        ofertaSubasta.TipoTransporte = tipo;
                        listado.Add(ofertaSubasta);
                    }
                    return listado;

                }catch(Exception ex)
                {
                    ex.InnerException.ToString();
                    return null;
                }


            }

        }

        /// <summary>
        /// Eliminar oferta de subasta 
        /// </summary>
        /// <param name="idOferta"></param>
        /// <returns></returns>
        public static bool EliminarOfertaSubasta(int idOferta)
        {
            using (var db = new DBEntities())
            {
                try
                {
                    //Buscar entidad con la id 
                    var oferta = db.OFERTASUBASTA.Where(of => of.IDOFERTA == idOferta).FirstOrDefault();
                    if (oferta == null)
                    {
                        return false;
                    }

                    db.OFERTASUBASTA.Remove(oferta);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    ex.InnerException.ToString();
                    return false;
                }



            }

        }

    }
}
