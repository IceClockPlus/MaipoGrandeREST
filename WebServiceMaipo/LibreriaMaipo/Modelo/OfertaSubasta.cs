using DatoMaipo;
using LibreriaMaipo.TiposUsuario;
using LibreriaMaipo.UsuarioFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaMaipo.Modelo
{
    public class OfertaSubasta
    {
        public int IdOferta { get; set; }
        public float PrecioOferta { get; set; }
        public string Seleccionado { get; set; }
        public DateTime FechaOferta { get; set; }
        public Transportista Transportista { get; set; }
        public TipoTransporte TipoTransporte { get; set; }

        public OfertaSubasta()
        {
            this.InitClass();
        }

        private void InitClass()
        {
            this.IdOferta = 0;
            this.PrecioOferta = 0;
            this.Seleccionado = "0";
            this.FechaOferta = DateTime.Today;
            this.Transportista = new Transportista();
            this.TipoTransporte = new TipoTransporte();
        }



        /// <summary>
        /// Obtener las ofertas por la id de subasta
        /// </summary>
        /// <param name="idSubasta"></param>
        /// <returns></returns>
        public static List<OfertaSubasta> ReadByIdSubasta(int idSubasta)
        {
            //Creacion de una factory de Transportista
            TipoUsuarioFactory factory = new TransportistaFactory();
            List<OfertaSubasta> list = new List<OfertaSubasta>();

            try
            {
                using (var db = new DBEntities())
                {
                    var listadoOfertas = db.OFERTASUBASTA.Where(of => of.IDSUBASTA == idSubasta).ToList();
                    if(listadoOfertas.Count() > 0)
                    {
                        foreach(var ofe in listadoOfertas)
                        {
                            OfertaSubasta oferta = new OfertaSubasta();
                            oferta.IdOferta = (int)ofe.IDOFERTA;
                            oferta.FechaOferta = ofe.FECHAOFERTA;
                            oferta.Seleccionado = ofe.SELECCIONADO;
                            oferta.PrecioOferta = (float)ofe.PRECIOOFERTA;
                            oferta.Transportista = (TiposUsuario.Transportista)factory.createTipoUsuario();
                            oferta.Transportista.ObtenerDatosPorId((int)ofe.IDTRANSPORTISTA);

                            TipoTransporte tipo = new TipoTransporte();
                            tipo.IdTipo = (int)ofe.IDTIPOTRANSPORTE;
                            tipo.GetById();
                            oferta.TipoTransporte = tipo;

                            list.Add(oferta);
                        }
                    }
                    return list;

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<OfertaSubasta>();
            }


        }

    }
}
