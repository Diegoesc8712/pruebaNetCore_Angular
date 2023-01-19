using Microsoft.Data.SqlClient;
using System.Data;
using Backend.Models;

namespace web_api_es.DLAC
{
    public class inventarioDLAC
    {
        public IEnumerable<inventario> listainventario()
        {
            List<inventario> seller = new List<inventario>();
            using (SqlConnection cn = new conexionDLAC().getcn)
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("lista_inventario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    seller.Add(new inventario()
                    {
                        Id = dr.GetInt32(0),
                        FechaIngreso = dr.GetDateTime(1),
                        Cantidad = dr.GetInt32(2),
                        ValorUnitario = dr.GetInt32(3),
                        Descripcion = dr.GetString(4)
                    });
                }
            }
            return seller;
        }

        public IEnumerable<inventario> listainventarioExistentes()
        {
            List<inventario> seller = new List<inventario>();
            using (SqlConnection cn = new conexionDLAC().getcn)
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("lista_inventario_existentes", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    seller.Add(new inventario()
                    {
                        Id = dr.GetInt32(0),
                        FechaIngreso = dr.GetDateTime(1),
                        Cantidad = dr.GetInt32(2),
                        ValorUnitario = dr.GetInt32(3),
                        Descripcion = dr.GetString(4)
                    });
                }
            }
            return seller;
        }

        public IEnumerable<inventario> inventarioPorId(int id)
        {
            List<inventario> seller = new List<inventario>();
            using (SqlConnection cn = new conexionDLAC().getcn)
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("inventario_Por_Id", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id", id));
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    seller.Add(new inventario()
                    {
                        Id = dr.GetInt32(0),
                        FechaIngreso = dr.GetDateTime(1),
                        Cantidad = dr.GetInt32(2),
                        ValorUnitario = dr.GetInt32(3),
                        Descripcion = dr.GetString(4)
                    });
                }
            }
            return seller;
        }
        
        public string guardarinventario(inventario inventario)
        {
            string mensaje = "";
            using (SqlConnection cn = new conexionDLAC().getcn)
            {
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("registrar_inventario", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@FechaIngreso", inventario.FechaIngreso));
                    cmd.Parameters.Add(new SqlParameter("@Cantidad", inventario.Cantidad));
                    cmd.Parameters.Add(new SqlParameter("@ValorUnitario", inventario.ValorUnitario));
                    cmd.Parameters.Add(new SqlParameter("@Descripcion", inventario.Descripcion));
                    cmd.ExecuteNonQuery();
                    mensaje = "Inventario Registrado";
                }
                catch (Exception ex) { mensaje = ex.Message; }
                finally { cn.Close(); }
            }
            return mensaje;
        }
        public string actualizarinventario(inventario inventario)
        {
            string mensaje = "";
            using (SqlConnection cn = new conexionDLAC().getcn)
            {
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("actualizar_inventario", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id", inventario.Id));
                    cmd.Parameters.Add(new SqlParameter("@FechaIngreso", inventario.FechaIngreso));
                    cmd.Parameters.Add(new SqlParameter("@Cantidad", inventario.Cantidad));
                    cmd.Parameters.Add(new SqlParameter("@ValorUnitario", inventario.ValorUnitario));
                    cmd.Parameters.Add(new SqlParameter("@Descripcion", inventario.Descripcion));
                    cmd.ExecuteNonQuery();
                    mensaje = "Inventario Actualizado";
                }
                catch (Exception ex) { mensaje = ex.Message; }
                finally { cn.Close(); }
            }
            return mensaje;
        }

        public string eliminarInventario(int id)
        {
            string mensaje = "";
            using (SqlConnection cn = new conexionDLAC().getcn)
            {
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("eliminar_inventario", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id", id));
                    cmd.ExecuteNonQuery();
                    mensaje = "Inventario Eliminado";
                }
                catch (Exception ex) { mensaje = ex.Message; }
                finally { cn.Close(); }
            }
            return mensaje;
        }
    }
}
