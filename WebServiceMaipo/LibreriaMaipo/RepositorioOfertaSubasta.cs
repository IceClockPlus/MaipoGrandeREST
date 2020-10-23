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
        public static List<OfertaSubasta> ListarOfertaPorIdSubasta(int idSubasta)
        {
            //Creacion de una factory de Cliente
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
                        ofertaSubasta.Transportista = (TiposUsuario.Transportista)factory.createTipoUsuario();
                        ofertaSubasta.Transportista.ObtenerDatosPorId((int)oferta.IDTRANSPORTISTA);

                        TipoTransporte tipo = new TipoTransporte();
                        tipo.ObtenerTipoTransportepPorId((int)oferta.IDTIPOTRANSPORTE);
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

    }
}
