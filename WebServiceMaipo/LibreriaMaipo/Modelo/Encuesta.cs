using DatoMaipo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaMaipo.Modelo
{
    public class Encuesta
    {
        public int IdEncuesta { get; set; }
        public string NombreReal { get; set; }
        public string Correo { get; set; }
        public int Telefono { get; set; }
        public string VariedadCatalogo { get; set; }
        public string ProcesoSolicitud { get; set; }
        public string TiempoEnvio { get; set; }
        public string SatisfaccionProducto { get; set; }
        public string ProcesoPago { get; set; }
        public int IdPedido { get; set; }

        public Encuesta()
        {
            this.InitClass();
        }

        public void InitClass()
        {
            this.IdEncuesta = 0;
            this.NombreReal = string.Empty;
            this.Correo = string.Empty;
            this.Telefono = 0;
            this.VariedadCatalogo = string.Empty;
            this.ProcesoSolicitud = string.Empty;
            this.TiempoEnvio = string.Empty;
            this.SatisfaccionProducto = string.Empty;
            this.ProcesoPago = string.Empty;
            this.IdPedido = 0;
        }


        public bool Insert()
        {
            try
            {
                using (var db = new DBEntities())
                {
                    db.SP_INSERT_ENCUESTA(
                        this.NombreReal,
                        this.Correo,
                        this.Telefono,
                        this.VariedadCatalogo,
                        this.ProcesoSolicitud,
                        this.TiempoEnvio,
                        this.SatisfaccionProducto,
                        this.ProcesoPago,
                        this.IdPedido
                        );
                    return true;

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }

        public List<Encuesta> ReadAll()
        {
            try
            {
                List<Encuesta> list = new List<Encuesta>();
                using (var db = new DBEntities())
                {
                    var encuestasdb = db.ENCUESTA.ToList();
                    if(encuestasdb.Count() > 0)
                    {
                        foreach(var e in encuestasdb)
                        {
                            Encuesta encuesta = new Encuesta();
                            encuesta.IdEncuesta = (int)e.IDENCUESTA;
                            encuesta.NombreReal = e.NOMBREREAL;
                            encuesta.Correo = e.CORREO;
                            encuesta.Telefono = (int)e.TELEFONO;
                            encuesta.VariedadCatalogo = e.VARIEDADCATALOGO;
                            encuesta.ProcesoSolicitud = e.PROCESOSOLICITUD;
                            encuesta.TiempoEnvio = e.TIEMPOENVIO;
                            encuesta.SatisfaccionProducto = e.SATISFACCIONPRODUCTO;
                            encuesta.ProcesoPago = e.PROCESOPAGO;
                            encuesta.IdPedido = (int)e.IDPEDIDO;

                            list.Add(encuesta);

                        }

                    }
                    return list;

                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Encuesta>();
            }
        }



    }
}
