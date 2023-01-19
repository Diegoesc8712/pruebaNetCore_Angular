using Microsoft.Data.SqlClient;
using System.Data;
using Backend.Models;

namespace web_api_es.DLAC
{
    public class itemDLAC
    {
        public IEnumerable<Item> listaItem()
        {
            List<Item> seller = new List<Item>();
            using (SqlConnection cn = new conexionDLAC().getcn)
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("lista_Item", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    seller.Add(new Item()
                    {
                        Id = dr.GetInt32(0),
                        ItemId = dr.GetInt32(1),
                        Descripcion = dr.GetString(2),
                        CompraId = dr.GetInt32(3),
                        ClienteId = dr.GetInt32(4)
                    });
                }
            }
            return seller;
        }
        public IEnumerable<Item> ItemPorId(int id)
        {
            List<Item> seller = new List<Item>();
            using (SqlConnection cn = new conexionDLAC().getcn)
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("Item_Por_Id", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id", id));
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    seller.Add(new Item()
                    {
                        Id = dr.GetInt32(0),
                        ItemId = dr.GetInt32(1),
                        Descripcion = dr.GetString(2),
                        CompraId = dr.GetInt32(3),
                        ClienteId = dr.GetInt32(4)
                    });
                }
            }
            return seller;
        }
        
        public string guardarItem(Item Item)
        {
            string mensaje = "";
            using (SqlConnection cn = new conexionDLAC().getcn)
            {
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("registrar_Item", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ItemId", Item.ItemId));
                    cmd.Parameters.Add(new SqlParameter("@Descripcion", Item.Descripcion));
                    cmd.Parameters.Add(new SqlParameter("@CompraId", Item.CompraId));
                    cmd.Parameters.Add(new SqlParameter("@ClienteId", Item.ClienteId));
                    cmd.ExecuteNonQuery();
                    mensaje = "Item Registrado";
                }
                catch (Exception ex) { mensaje = ex.Message; }
                finally { cn.Close(); }
            }
            return mensaje;
        }
        public string actualizarItem(Item Item)
        {
            string mensaje = "";
            using (SqlConnection cn = new conexionDLAC().getcn)
            {
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("actualizar_Item", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id", Item.Id));
                    cmd.Parameters.Add(new SqlParameter("@ItemId", Item.ItemId));
                    cmd.Parameters.Add(new SqlParameter("@Descripcion", Item.Descripcion));
                    cmd.Parameters.Add(new SqlParameter("@CompraId", Item.CompraId));
                    cmd.Parameters.Add(new SqlParameter("@ClienteId", Item.ClienteId));
                    cmd.ExecuteNonQuery();
                    mensaje = "Item Actualizado";
                }
                catch (Exception ex) { mensaje = ex.Message; }
                finally { cn.Close(); }
            }
            return mensaje;
        }

        public string eliminarItem(int id)
        {
            string mensaje = "";
            using (SqlConnection cn = new conexionDLAC().getcn)
            {
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("eliminar_Item", cn);
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
