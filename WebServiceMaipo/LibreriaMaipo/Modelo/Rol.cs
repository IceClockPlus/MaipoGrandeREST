using DatoMaipo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaMaipo.Modelo
{
    public class Rol
    {
        private int _idRol;

        private String _nombreRol;

        public int IdRol
        {
            get
            {
                return _idRol;
            }
            set
            {
                _idRol = value;
            }
        }

        public String NombreRol
        {
            get
            {
                return _nombreRol;
            }
            set
            {
                _nombreRol = value;
            }
        }

        public Rol()
        {
            this.InitClass();
        }

        private void InitClass()
        {
            this.IdRol = 0;
            this.NombreRol = String.Empty;
        }

        /// <summary>
        /// Buscar el rol por su id
        /// </summary>
        /// <returns></returns>
        public bool Read()
        {
            try
            {
                using (var db = new DBEntities())
                {
                    ROL rol = db.ROL.Where(r => r.ID_ROL == this.IdRol).FirstOrDefault();
                    if (rol != null)
                    {
                        this.NombreRol = rol.NOMBRE_ROL;
                        return true;
                    }
                    return false;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;

            }

        }  
        /// <summary>
        /// Listar todos los roles disponibles
        /// </summary>
        /// <returns></returns>
        public List<Rol> ReadAll()
            {
                try
                {
                    List<Rol> list = new List<Rol>();
                    using (var db = new DBEntities())
                    {
                        var listadoRoles = db.ROL.ToList();
                        if(listadoRoles.Count > 0)
                        {
                            foreach(var r in listadoRoles)
                            {
                                Rol rol = new Rol();
                                rol.IdRol = (int)r.ID_ROL;
                                rol.NombreRol = r.NOMBRE_ROL;
                                list.Add(rol);

                            }

                        }
                        return list;

                    }
                }catch(Exception ex)
                {
                    return new List<Rol>();
                }

            }



        }


}

