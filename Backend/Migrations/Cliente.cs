using System;
using System.Collections.Generic;

namespace Backend.Migrations;

public partial class Cliente
{
    public int Id { get; set; }

    public string? NombreCliente { get; set; }

    public int? Celular { get; set; }

    public string? Direccion { get; set; }

    public virtual ICollection<Item> Items { get; } = new List<Item>();
}
