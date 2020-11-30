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
    public class Contrato
    {
        public int Id { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaTermino { get; set; }
        public float PorcComision { get; set; }
        public string Vigente { get; set; }
        public Productor Productor { get; set; }

        public Contrato()
        {
            this.InitClass();
        }

        private void InitClass()
        {
            this.Id =0;
            this.FechaCreacion = DateTime.Now;
            this.FechaTermino = DateTime.Now;
            this.PorcComision = 0;
            this.Vigente = string.Empty;
            this.Productor = new Productor();
        }


        public bool Agregar()
        {
            try
            {
                using (var db = new DBEntities())
                {
                    db.SP_INSERTAR_CONTRATO(this.FechaCreacion, this.FechaTermino, (decimal?)this.PorcComision, this.Vigente, this.Productor.Id);
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
                using(var db = new DBEntities())
                {
                    db.SP_ACTUALIZAR_CONTRATO(this.Id, this.FechaCreacion, this.FechaTermino, (decimal?)this.PorcComision, this.Vigente, this.Productor.Id);
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
                    db.SP_ELIMINAR_CONTRATO(this.Id);
                    return true;

                }

            }catch(Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Obtener todos los contratos de los productores
        /// </summary>
        /// <returns></returns>
        public List<Contrato> ReadAll()
        {
            try
            {
                TipoUsuarioFactory factory = new ProductorFactory();

                List<Contrato> list = new List<Contrato>();
                using (var db = new DBEntities())
                {
                    var listaContrato = db.CONTRATO.ToList();
                    if(listaContrato.Count > 0)
                    {
                        foreach(var c in listaContrato)
                        {
                            Contrato contrato = new Contrato();
                            contrato.Id = (int)c.IDCONTRATO;
                            contrato.FechaCreacion = c.FECHACREACION;
                            contrato.FechaTermino = c.FECHATERMINO;
                            contrato.PorcComision = (float)c.PORCCOMISION;
                            contrato.Vigente = c.VIGENTE.ToString();
                            TipoUsuario prod = factory.createTipoUsuario();
                            //Recuperar datos del cliente por su id
                            prod.ObtenerDatosPorId((int)c.IDPRODUCTOR);
                            contrato.Productor = (Productor)prod;

                            list.Add(contrato);
                        }


                    }

                    return list;

                }


            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Contrato>();
            }
        }


        /// <summary>
        /// Buscar contrato por la id asignada a la actual instancia
        /// </summary>
        /// <returns></returns>
        public bool Read()
        {
            try
            {
                bool obtenido = false;

                TipoUsuarioFactory factory = new ProductorFactory();
                using (var db = new DBEntities())
                {
                    CONTRATO contrato = db.CONTRATO.Where(c => c.IDCONTRATO == this.Id).FirstOrDefault();
                    if(contrato != null)
                    {
                        this.FechaCreacion = contrato.FECHACREACION;
                        this.FechaTermino = contrato.FECHATERMINO;
                        this.PorcComision = (float)contrato.PORCCOMISION;
                        this.Vigente = contrato.VIGENTE.ToString();
                        TipoUsuario prod = factory.createTipoUsuario();
                        //Recuperar datos del cliente por su id
                        prod.ObtenerDatosPorId((int)contrato.IDPRODUCTOR);
                        this.Productor = (Productor)prod;

                        obtenido = true;

                    }

                    return obtenido;

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }


    }
}
