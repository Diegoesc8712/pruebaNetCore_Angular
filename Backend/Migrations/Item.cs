using System;
using System.Collections.Generic;

namespace Backend.Migrations;

public partial class Item
{
    public int Id { get; set; }

    public int? ItemId { get; set; }

    public string? Descripcion { get; set; }

    public int? CompraId { get; set; }

    public int? ClienteId { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual Compra? Compra { get; set; }
}
