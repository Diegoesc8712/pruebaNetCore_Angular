using Microsoft.Data.SqlClient;
using System.Data;
using Backend.Models;

namespace web_api_es.DLAC
{
    public class clientesDLAC
    {
        public IEnumerable<clientes> listaclientes()
        {
            List<clientes> seller = new List<clientes>();
            using (SqlConnection cn = new conexionDLAC().getcn)
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("lista_clientes", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    seller.Add(new clientes()
                    {
                        Id = dr.GetInt32(0),
                        NombreCliente = dr.GetString(1),
                        Celular = dr.GetInt32(2),
                        Direccion = dr.GetString(3)
                    });
                }
            }
            return seller;
        }
        public IEnumerable<clientes> clientesPorId(int id)
        {
            List<clientes> seller = new List<clientes>();
            using (SqlConnection cn = new conexionDLAC().getcn)
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("cliente_Por_Id", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id", id));
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    seller.Add(new clientes()
                    {
                        Id = dr.GetInt32(0),
                        NombreCliente = dr.GetString(1),
                        Celular = dr.GetInt32(2),
                        Direccion = dr.GetString(3)
                    });
                }
            }
            return seller;
        }

        public IEnumerable<clientes> clientesPorCelular(int cel)
        {
            List<clientes> seller = new List<clientes>();
            using (SqlConnection cn = new conexionDLAC().getcn)
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("cliente_Por_celular", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Celular", cel));
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    seller.Add(new clientes()
                    {
                        Id = dr.GetInt32(0),
                        NombreCliente = dr.GetString(1),
                        Celular = dr.GetInt32(2),
                        Direccion = dr.GetString(3)
                    });
                }
            }
            return seller;
        }

        public string guardarclientes(clientes clientes)
        {
            string mensaje = "";
            using (SqlConnection cn = new conexionDLAC().getcn)
            {
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("registrar_clientes", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@NombreCliente", clientes.NombreCliente));
                    cmd.Parameters.Add(new SqlParameter("@Celular", clientes.Celular));
                    cmd.Parameters.Add(new SqlParameter("@Direccion", clientes.Direccion));
                    cmd.ExecuteNonQuery();
                    mensaje = "Cliente Registrado";
                }
                catch (Exception ex) { mensaje = ex.Message; }
                finally { cn.Close(); }
            }
            return mensaje;
        }
        public string actualizarcliente(clientes clientes)
        {
            string mensaje = "";
            using (SqlConnection cn = new conexionDLAC().getcn)
            {
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("actualizar_clientes", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id", clientes.Id));
                    cmd.Parameters.Add(new SqlParameter("@NombreCliente", clientes.NombreCliente));
                    cmd.Parameters.Add(new SqlParameter("@Celular", clientes.Celular));
                    cmd.Parameters.Add(new SqlParameter("@Direccion", clientes.Direccion));
                    cmd.ExecuteNonQuery();
                    mensaje = "Cliente Actualizado";
                }
                catch (Exception ex) { mensaje = ex.Message; }
                finally { cn.Close(); }
            }
            return mensaje;
        }

        public string eliminarCliente(int id)
        {
            string mensaje = "";
            using (SqlConnection cn = new conexionDLAC().getcn)
            {
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("eliminar_clientes", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id", id));
                    cmd.ExecuteNonQuery();
                    mensaje = "Cliente Eliminado";
                }
                catch (Exception ex) { mensaje = ex.Message; }
                finally { cn.Close(); }
            }
            return mensaje;
        }
    }
}
