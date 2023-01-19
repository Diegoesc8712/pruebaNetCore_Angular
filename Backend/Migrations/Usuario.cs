using System;
using System.Collections.Generic;

namespace Backend.Migrations;

public partial class Usuario
{
    public int Id { get; set; }

    public string? Usuario1 { get; set; }

    public string? Password { get; set; }

    public int Estado { get; set; }

    public string? Salt { get; set; }
}
