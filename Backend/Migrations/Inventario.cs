using System;
using System.Collections.Generic;

namespace Backend.Migrations;

public partial class Inventario
{
    public int Id { get; set; }

    public DateTime? FechaIngreso { get; set; }

    public int? Cantidad { get; set; }

    public int ValorUnitario { get; set; }

    public string? Descripcion { get; set; }
}
