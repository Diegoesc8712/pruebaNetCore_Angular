namespace Backend.Models
{
    public class Item
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string Descripcion { get; set; }
        public int CompraId { get; set; }
        public int ClienteId { get; set; }
    }
}
