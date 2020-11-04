using DatoMaipo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaMaipo.Modelo
{
    [DataContract]
    public class EstadoSubasta
    {
        [DataMember]
        public int IdEstadoSubasta { get; set; }
        [DataMember]
        public string Descripcion { get; set; }


        public EstadoSubasta()
        {
            this.InitClass();
        }

        private void InitClass()
        {
            this.IdEstadoSubasta = 0;
            this.Descripcion = string.Empty;
        }

        /// <summary>
        /// Obtener el estado de la subasta de acuerdo a la id de la instancia
        /// </summary>
        /// <returns></returns>
        public bool Read()
        {
            try
            {
                using (var db = new DBEntities())
                {
                    ESTADOSUBASTA estado = db.ESTADOSUBASTA.Where(est => est.IDESTADO == this.IdEstadoSubasta).FirstOrDefault();
                    if (estado != null)
                    {
                        this.Descripcion = estado.DESCRIPCION;
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
        /// Entrega un listado de los estados que puede estar una subasta
        /// </summary>
        /// <returns></returns>
        public List<EstadoSubasta> ReadAll()
        {
            try
            {
                List<EstadoSubasta> list = new List<EstadoSubasta>();
                using (var db = new DBEntities())
                {
                    var listadoEstados = db.ESTADOSUBASTA.ToList();
                    if (listadoEstados.Count > 0)
                    {
                        foreach (var est in listadoEstados)
                        {
                            EstadoSubasta estado = new EstadoSubasta();
                            estado.IdEstadoSubasta = (int)est.IDESTADO;
                            estado.Descripcion = est.DESCRIPCION;
                            list.Add(estado);

                        }
                    }
                    return list;

                }

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<EstadoSubasta>();
            }

        }



    }
}
