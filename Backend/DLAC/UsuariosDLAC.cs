using Microsoft.Data.SqlClient;
using System.Data;
using Backend.Models;

namespace web_api_es.DLAC
{
    public class UsuariosDLAC
    {
        public IEnumerable<Usuario> listaUsuarios()
        {
            List<Usuario> seller = new List<Usuario>();
            using (SqlConnection cn = new conexionDLAC().getcn)
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("lista_usuarios", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    seller.Add(new Usuario()
                    {
                        Id = dr.GetInt32(0),
                        usuario = dr.GetString(1),
                        password = dr.GetString(2),
                        estado = dr.GetInt32(3),
                        salt = dr.GetString(4)
                    });
                }
            }
            return seller;
        }

        public IEnumerable<Usuario> usuarioPorId(int id)
        {
            List<Usuario> seller = new List<Usuario>();
            using (SqlConnection cn = new conexionDLAC().getcn)
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("usuario_Por_Id", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id", id));
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    seller.Add(new Usuario()
                    {
                        Id = dr.GetInt32(0),
                        usuario = dr.GetString(1),
                        password = dr.GetString(2),
                        estado = dr.GetInt32(3),
                        salt = dr.GetString(4)
                    });
                }
            }
            return seller;
        }

        public Task<Usuario> usuarioPorusuario(string usuario)
        {
            List<Usuario> seller = new List<Usuario>();
            using (SqlConnection cn = new conexionDLAC().getcn)
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("usuario_Por_usuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@usuario", usuario));
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    seller.Add(new Usuario()
                    {
                        Id = dr.GetInt32(0),
                        usuario = dr.GetString(1),
                        password = dr.GetString(2),
                        estado = dr.GetInt32(3),
                        salt = dr.GetString(4)
                    });
                }
            }
            return Task.FromResult(seller.FirstOrDefault());
        }

        public string guardarUsuario(Usuario Usuario)
        {
            string mensaje = "";
            using (SqlConnection cn = new conexionDLAC().getcn)
            {
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("registrar_usuario", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@usuario", Usuario.usuario));
                    cmd.Parameters.Add(new SqlParameter("@password", Usuario.password));
                    cmd.Parameters.Add(new SqlParameter("@estado", Usuario.estado));
                    cmd.Parameters.Add(new SqlParameter("@salt", Usuario.salt));
                    cmd.ExecuteNonQuery();
                    mensaje = "Usuario Registrado";
                }
                catch (Exception ex) { mensaje = ex.Message; }
                finally { cn.Close(); }
            }
            return mensaje;
        }
        public string actualizarUsuario(Usuario Usuario)
        {
            string mensaje = "";
            using (SqlConnection cn = new conexionDLAC().getcn)
            {
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("actualizar_usuario", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id", Usuario.Id));
                    cmd.Parameters.Add(new SqlParameter("@usuario", Usuario.usuario));
                    cmd.Parameters.Add(new SqlParameter("@password", Usuario.password));
                    cmd.Parameters.Add(new SqlParameter("@estado", Usuario.estado));
                    cmd.Parameters.Add(new SqlParameter("@salt", Usuario.salt));
                    cmd.ExecuteNonQuery();
                    mensaje = "usuario Actualizado";
                }
                catch (Exception ex) { mensaje = ex.Message; }
                finally { cn.Close(); }
            }
            return mensaje;
        }

        public string eliminarUsuario(int id)
        {
            string mensaje = "";
            using (SqlConnection cn = new conexionDLAC().getcn)
            {
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("eliminar_usuario", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id", id));
                    cmd.ExecuteNonQuery();
                    mensaje = "Usuario Eliminado";
                }
                catch (Exception ex) { mensaje = ex.Message; }
                finally { cn.Close(); }
            }
            return mensaje;
        }
    }
}
