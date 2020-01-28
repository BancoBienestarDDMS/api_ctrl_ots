using api_ctrl_ots.clases;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace api_ctrl_ots
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service1 : IService1
    {
        public List<c_DA> getDAs()
        {
            List<c_DA> lista = new List<c_DA>();
            string qry       = "select * from dbo.DireccionAdjunta";
            try {
                using (SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cc))
                {
                    conexion.Open();
                    using (SqlCommand select  = new SqlCommand(qry, conexion))
                    {
                        SqlDataReader Dr      = select.ExecuteReader();
                        while (Dr.Read())
                        {
                            c_DA dd   = new c_DA();
                            dd.id     = Convert.ToInt16(Dr["idDA"].ToString());
                            dd.nombre = Dr["nomDA"].ToString();
                            dd.abrev  = Dr["abrevDA"].ToString();
                            lista.Add(dd);
                        }
                    }
                    conexion.Close();
                }
            } catch (Exception ex) {
                string error = "Error al obtener lista de Direcciones Adjuntas.   Error: " + ex.Message;
                lista.Add(new c_DA() { nombre = error });
                Console.WriteLine(error);
            }
            return lista;
        }

        public List<c_Dir> getDirecciones()
        {
            List<c_Dir> lista = new List<c_Dir>();
            string qry        = "select * from dbo.Direcciones";
            try
            {
                using (SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cc))
                {
                    conexion.Open();
                    using (SqlCommand select  = new SqlCommand(qry, conexion))
                    {
                        SqlDataReader Dr      = select.ExecuteReader();
                        while (Dr.Read())
                        {
                            c_Dir dd  = new c_Dir();
                            dd.id     = Convert.ToInt16(Dr["idDireccion"].ToString());
                            dd.idDA   = Convert.ToInt16(Dr["iddireccionAdjunta"].ToString());
                            dd.nombre = Dr["nomDireccion"].ToString();
                            dd.abrev  = Dr["abrevDireccion"].ToString();
                            lista.Add(dd);
                        }
                    }
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                string error = "Error al obtener lista de Direcciones.   Error: " + ex.Message;
                lista.Add(new c_Dir() { nombre = error });
                Console.WriteLine(error);
            }
            return lista;
        }

        public List<c_SubDir> getSubdireccion()
        {
            List<c_SubDir> lista = new List<c_SubDir>();
            string qry           = "select * from dbo.Subdireccion";
            try
            {
                using (SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cc))
                {
                    conexion.Open();
                    using (SqlCommand select  = new SqlCommand(qry, conexion))
                    {
                        SqlDataReader Dr      = select.ExecuteReader();
                        while (Dr.Read())
                        {
                            c_SubDir dd = new c_SubDir();
                            dd.id       = Convert.ToInt16(Dr["idSubdireccion"].ToString());
                            dd.idDir    = Convert.ToInt16(Dr["idDireccion"].ToString());
                            dd.nombre   = Dr["nomSubdireccion"].ToString();
                            dd.abrev    = Dr["abrevSubdireccion"].ToString();
                            lista.Add(dd);
                        }
                    }
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                string error = "Error al obtener lista de SubDirecciones.   Error: " + ex.Message;
                lista.Add(new c_SubDir() { nombre = error });
                Console.WriteLine(error);
            }
            return lista;
        }

        public List<c_Ger> getGerencias()
        {
            List<c_Ger> lista = new List<c_Ger>();
            string qry        = "select * from dbo.Gerencias";
            try
            {
                using (SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cc))
                {
                    conexion.Open();
                    using (SqlCommand select  = new SqlCommand(qry, conexion))
                    {
                        SqlDataReader Dr      = select.ExecuteReader();
                        while (Dr.Read())
                        {
                            c_Ger dd    = new c_Ger();
                            dd.id       = Convert.ToInt16(Dr["idGerencia"].ToString());
                            dd.idSubDir = Convert.ToInt16(Dr["idSubdireccion"].ToString());
                            dd.nombre   = Dr["nomGerencia"].ToString();
                            dd.abrev    = Dr["abrevGerencia"].ToString();
                            lista.Add(dd);
                        }
                    }
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                string error = "Error al obtener lista de Gerencias.   Error: " + ex.Message;
                lista.Add(new c_Ger() { nombre = error });
                Console.WriteLine(error);
            }
            return lista;
        }

        public List<c_Programa> getPrograma()
        {
            List<c_Programa> lista = new List<c_Programa>();
            string qry             = "select * from dbo.cat_programa";
            try
            {
                using (SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cc))
                {
                    conexion.Open();
                    using (SqlCommand select  = new SqlCommand(qry, conexion))
                    {
                        SqlDataReader Dr      = select.ExecuteReader();
                        while (Dr.Read())
                        {
                            c_Programa dd = new c_Programa();
                            dd.id         = Convert.ToInt16(Dr["idPrograma"].ToString());
                            dd.nombre     = Dr["NombrePrograma"].ToString();
                            lista.Add(dd);
                        }
                    }
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                string error = "Error al obtener lista de Programas.   Error: " + ex.Message;
                lista.Add(new c_Programa() { nombre = error });
                Console.WriteLine(error);
            }
            return lista;
        }

        public List<c_SubPrograma> getSubPrograma()
        {
            List<c_SubPrograma> lista = new List<c_SubPrograma>();
            string qry                = "select * from dbo.cat_subprograma";
            try
            {
                using (SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cc))
                {
                    conexion.Open();
                    using (SqlCommand select  = new SqlCommand(qry, conexion))
                    {
                        SqlDataReader Dr      = select.ExecuteReader();
                        while (Dr.Read())
                        {
                            c_SubPrograma dd = new c_SubPrograma();
                            dd.id            = Convert.ToInt16(Dr["idSubPrograma"].ToString());
                            dd.nombre        = Dr["NombreSubPrograma"].ToString();
                            lista.Add(dd);
                        }
                    }
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                string error = "Error al obtener lista de SubProgramas.   Error: " + ex.Message;
                lista.Add(new c_SubPrograma() { nombre = error });
                Console.WriteLine(error);
            }
            return lista;
        }

        public List<c_TipoServicio> getTipoServicio()
        {
            List<c_TipoServicio> lista = new List<c_TipoServicio>();
            string qry                 = "select * from dbo.cat_tiposervicio";
            try
            {
                using (SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cc))
                {
                    conexion.Open();
                    using (SqlCommand select  = new SqlCommand(qry, conexion))
                    {
                        SqlDataReader Dr      = select.ExecuteReader();
                        while (Dr.Read())
                        {
                            c_TipoServicio dd = new c_TipoServicio();
                            dd.id             = Convert.ToInt16(Dr["idTS"].ToString());
                            dd.nombre         = Dr["NombreTS"].ToString();
                            lista.Add(dd);
                        }
                    }
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                string error = "Error al obtener lista de SubProgramas.   Error: " + ex.Message;
                lista.Add(new c_TipoServicio() { nombre = error });
                Console.WriteLine(error);
            }
            return lista;
        }

        public List<c_Urgencia> getUrgencia()
        {
            List<c_Urgencia> lista = new List<c_Urgencia>();
            string qry             = "select * from dbo.urgencia";
            try
            {
                using (SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cc))
                {
                    conexion.Open();
                    using (SqlCommand select  = new SqlCommand(qry, conexion))
                    {
                        SqlDataReader Dr      = select.ExecuteReader();
                        while (Dr.Read())
                        {
                            c_Urgencia dd = new c_Urgencia();
                            dd.id         = Convert.ToInt16(Dr["idUrgencia"].ToString());
                            dd.nombre     = Dr["nomUrgencia"].ToString();
                            lista.Add(dd);
                        }
                    }
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                string error = "Error al obtener lista de Urgencias.   Error: " + ex.Message;
                lista.Add(new c_Urgencia() { nombre = error });
                Console.WriteLine(error);
            }
            return lista;
        }

        public List<c_Complejidad> getComplejidad()
        {
            List<c_Complejidad> lista = new List<c_Complejidad>();
            string qry                = "select * from dbo.Complejidad";
            try
            {
                using (SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cc))
                {
                    conexion.Open();
                    using (SqlCommand select  = new SqlCommand(qry, conexion))
                    {
                        SqlDataReader Dr      = select.ExecuteReader();
                        while (Dr.Read())
                        {
                            c_Complejidad dd = new c_Complejidad();
                            dd.id            = Convert.ToInt16(Dr["idComplejidad"].ToString());
                            dd.nombre        = Dr["nomComplejidad"].ToString();
                            lista.Add(dd);
                        }
                    }
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                string error = "Error al obtener lista de Complejidad.   Error: " + ex.Message;
                lista.Add(new c_Complejidad() { nombre = error });
                Console.WriteLine(error);
            }
            return lista;
        }

        public List<c_StatusOT> getStatusOT()
        {
            List<c_StatusOT> lista = new List<c_StatusOT>();
            string qry             = "select * from dbo.statusOT";
            try
            {
                using (SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cc))
                {
                    conexion.Open();
                    using (SqlCommand select  = new SqlCommand(qry, conexion))
                    {
                        SqlDataReader Dr      = select.ExecuteReader();
                        while (Dr.Read())
                        {
                            c_StatusOT dd = new c_StatusOT();
                            dd.id         = Convert.ToInt16(Dr["idStatus"].ToString());
                            dd.nombre     = Dr["nomStatus"].ToString();
                            lista.Add(dd);
                        }
                    }
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                string error = "Error al obtener lista de Estatus de OT.   Error: " + ex.Message;
                lista.Add(new c_StatusOT() { nombre = error });
                Console.WriteLine(error);
            }
            return lista;
        }

        public List<c_AA> getAreaAsig()
        {
            List<c_AA> lista = new List<c_AA>();
            string qry       = "select * from dbo.areaAsignacion";
            try
            {
                using (SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cc))
                {
                    conexion.Open();
                    using (SqlCommand select  = new SqlCommand(qry, conexion))
                    {
                        SqlDataReader Dr      = select.ExecuteReader();
                        while (Dr.Read())
                        {
                            c_AA dd   = new c_AA();
                            dd.id     = Convert.ToInt16(Dr["idAA"].ToString());
                            dd.nombre = Dr["nomAA"].ToString();
                            lista.Add(dd);
                        }
                    }
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                string error = "Error al obtener lista de Areas de Asignación.   Error: " + ex.Message;
                lista.Add(new c_AA() { nombre = error });
                Console.WriteLine(error);
            }
            return lista;
        }

        public List<c_Usr> getUsuario()
        {
            List<c_Usr> lista = new List<c_Usr>();
            string qry        = "select * from dbo.usuarios";
            try
            {
                using (SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cc))
                {
                    conexion.Open();
                    using (SqlCommand select  = new SqlCommand(qry, conexion))
                    {
                        SqlDataReader Dr      = select.ExecuteReader();
                        while (Dr.Read())
                        {
                            c_Usr dd  = new c_Usr();
                            dd.id     = Convert.ToInt16(Dr["idusr"].ToString());
                            dd.usr    = Dr["usr"].ToString();
                            dd.pass   = Dr["pass"].ToString();
                            dd.nombre = Dr["nomUsr"].ToString();
                            dd.ap     = Dr["apUsr"].ToString();
                            dd.am     = Dr["amUsr"].ToString();
                            dd.email  = Dr["emailUsr"].ToString();
                            dd.perfil = Convert.ToInt16(Dr["perfil"].ToString());
                            dd.status = Convert.ToBoolean(Dr["status"].ToString());
                            lista.Add(dd);
                        }
                    }
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                string error = "Error al obtener lista de Usuarios.   Error: " + ex.Message;
                lista.Add(new c_Usr() { nombre = error });
                Console.WriteLine(error);
            }
            return lista;
        }

        public List<c_Persona> getPersonas()
        {
            List<c_Persona> lista = new List<c_Persona>();
            string qry = "select * from dbo.Personas";
            try
            {
                using (SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cc))
                {
                    conexion.Open();
                    using (SqlCommand select = new SqlCommand(qry, conexion))
                    {
                        SqlDataReader Dr = select.ExecuteReader();
                        while (Dr.Read())
                        {
                            c_Persona dd = new c_Persona();
                            dd.id        = Convert.ToInt16(Dr["idPersona"].ToString());
                            dd.nombre    = Dr["nomPersona"].ToString();
                            dd.ap        = Dr["apPersona"].ToString();
                            dd.am        = Dr["amPersona"].ToString();
                            dd.email     = Dr["email"].ToString();
                            dd.ext       = Dr["extension"].ToString();
                            lista.Add(dd);
                        }
                    }
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                string error = "Error al obtener lista de Personas.   Error: " + ex.Message;
                lista.Add(new c_Persona() { nombre = error });
                Console.WriteLine(error);
            }
            return lista;
        }

        public List<c_RelPP> getRelPuesPer()
        {
            List<c_RelPP> lista = new List<c_RelPP>();
            string qry = "select * from dbo.relPuestoPersona";
            try
            {
                using (SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cc))
                {
                    conexion.Open();
                    using (SqlCommand select = new SqlCommand(qry, conexion))
                    {
                        SqlDataReader Dr = select.ExecuteReader();
                        while (Dr.Read())
                        {
                            c_RelPP dd    = new c_RelPP();
                            dd.id         = Convert.ToInt16(Dr["idRP"].ToString());
                            dd.idDA       = Convert.ToInt16(Dr["idDA"].ToString());
                            dd.idDir      = Convert.ToInt16(Dr["idDireccion"].ToString());
                            dd.idSubDir   = Convert.ToInt16(Dr["idSubdireccion"].ToString());
                            dd.idGerencia = Convert.ToInt16(Dr["idGerencia"].ToString());
                            dd.idPersona  = Convert.ToInt16(Dr["idPersona"].ToString());
                            dd.f_inicio   = Convert.ToDateTime(Dr["f_inicio"].ToString());
                            dd.f_fin      = Convert.ToDateTime(Dr["f_fin"].ToString());
                            dd.status     = Convert.ToBoolean(Dr["status"].ToString());
                            lista.Add(dd);
                        }
                    }
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                string error = "Error al obtener lista de Personas.   Error: " + ex.Message;
                //lista.Add(new c_RelPP() { nombre = error });
                Console.WriteLine(error);
            }
            return lista;
        }

    }
}
