using DatoMaipo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaMaipo.Modelo
{
    public class TipoTransporte
    {
        public int IdTipo { get; set; }
        public string Descripcion { get; set; }

        public TipoTransporte()
        {
            this.InitClass();
        }

        private void InitClass()
        {
            this.IdTipo = 0;
            this.Descripcion = string.Empty;
        }

        /// <summary>
        /// Obtener el tipo de transporte de acuerdo a su id
        /// </summary>
        /// <returns></returns>
        public bool GetById()
        {
            try
            {
                using (var db = new DBEntities())
                {
                    TIPOTRANSPORTE t = db.TIPOTRANSPORTE.Where(tipo => tipo.IDTIPO == this.IdTipo).FirstOrDefault();
                    if(t != null)
                    {
                        this.Descripcion = t.DESCRIPCION;
                        return true;
                    }
                    return false;

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }
        /// <summary>
        /// Listar todos los tipos de transportes disponibles
        /// </summary>
        /// <returns></returns>
        public List<TipoTransporte> ReadAll()
        {
            try
            {
                List<TipoTransporte> list = new List<TipoTransporte>();
                using (var db = new DBEntities())
                {
                    var listadoTransportes = db.TIPOTRANSPORTE.ToList();
                    if (listadoTransportes.Count > 0)
                    {
                        foreach(var t in listadoTransportes)
                        {
                            TipoTransporte tipo = new TipoTransporte();
                            tipo.IdTipo = (int)t.IDTIPO;
                            tipo.Descripcion = t.DESCRIPCION;
                            list.Add(tipo);

                        }

                    }
                    return list;

                }

            }catch(Exception ex)
            {
                return new List<TipoTransporte>();
            }
        }


    }
}
