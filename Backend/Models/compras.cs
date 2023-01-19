namespace Backend.Models
{
    public class compras
    {
        public int Id { get; set; }
        public string ordenCompra { get; set; }
        public DateTime fechaCompra { get; set; }
        public int valorCompra { get; set; }
        public string medioPago { get; set; }

    }
}
