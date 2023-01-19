using Microsoft.Data.SqlClient;
using System.Data;
using Backend.Models;

namespace web_api_es.DLAC
{
    public class comprasDLAC
    {
        public IEnumerable<compras> listaCompras()
        {
            List<compras> seller = new List<compras>();
            using (SqlConnection cn = new conexionDLAC().getcn)
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("lista_compras", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    seller.Add(new compras()
                    {
                        Id = dr.GetInt32(0),
                        ordenCompra = dr.GetString(1),
                        fechaCompra = dr.GetDateTime(2),
                        valorCompra = dr.GetInt32(3),
                        medioPago = dr.GetString(4)
                    });
                }
            }
            return seller;
        }

        public IEnumerable<compras> idUltimaCompra()
        {
            List<compras> seller = new List<compras>();
            using (SqlConnection cn = new conexionDLAC().getcn)
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("id_ultimaCompra", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    seller.Add(new compras()
                    {
                        Id = dr.GetInt32(0),
                    });
                }
            }
            return seller;
        }

        public IEnumerable<compras> ComprasPorId(int id)
        {
            List<compras> seller = new List<compras>();
            using (SqlConnection cn = new conexionDLAC().getcn)
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("compras_Por_Id", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id", id));
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    seller.Add(new compras()
                    {
                        Id = dr.GetInt32(0),
                        ordenCompra = dr.GetString(1),
                        fechaCompra = dr.GetDateTime(2),
                        valorCompra = dr.GetInt32(3),
                        medioPago = dr.GetString(4)
                    });
                }
            }
            return seller;
        }
        
        public string guardarCompra(compras compras)
        {
            string mensaje = "";
            using (SqlConnection cn = new conexionDLAC().getcn)
            {
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("registrar_compras", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ordenCompra", compras.ordenCompra));
                    cmd.Parameters.Add(new SqlParameter("@fechaCompra", compras.fechaCompra));
                    cmd.Parameters.Add(new SqlParameter("@valorCompra", compras.valorCompra));
                    cmd.Parameters.Add(new SqlParameter("@medioPago", compras.medioPago));
                    cmd.ExecuteNonQuery();
                    mensaje = "Compra Registrada";
                }
                catch (Exception ex) { mensaje = ex.Message; }
                finally { cn.Close(); }
            }
            return mensaje;
        }
        public string actualizarCompra(compras compras)
        {
            string mensaje = "";
            using (SqlConnection cn = new conexionDLAC().getcn)
            {
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("actualizar_compras", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id", compras.Id));
                    cmd.Parameters.Add(new SqlParameter("@ordenCompra", compras.ordenCompra));
                    cmd.Parameters.Add(new SqlParameter("@fechaCompra", compras.fechaCompra));
                    cmd.Parameters.Add(new SqlParameter("@valorCompra", compras.valorCompra));
                    cmd.Parameters.Add(new SqlParameter("@medioPago", compras.medioPago));
                    cmd.ExecuteNonQuery();
                    mensaje = "Compra Actualizada";
                }
                catch (Exception ex) { mensaje = ex.Message; }
                finally { cn.Close(); }
            }
            return mensaje;
        }

        public string eliminarCompra(int id)
        {
            string mensaje = "";
            using (SqlConnection cn = new conexionDLAC().getcn)
            {
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("eliminar_compras", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id", id));
                    cmd.ExecuteNonQuery();
                    mensaje = "Compra Eliminada";
                }
                catch (Exception ex) { mensaje = ex.Message; }
                finally { cn.Close(); }
            }
            return mensaje;
        }
    }
}
