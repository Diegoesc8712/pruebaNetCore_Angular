using System;
using System.Collections.Generic;

namespace Backend.Migrations;

public partial class Compra
{
    public int Id { get; set; }

    public string? OrdenCompra { get; set; }

    public DateTime? FechaCompra { get; set; }

    public int ValorCompra { get; set; }

    public string? MedioPago { get; set; }

    public virtual ICollection<Item> Items { get; } = new List<Item>();
}
