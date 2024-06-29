using System;
using System.Collections.Generic;

namespace Test.Models;

public partial class TipoIdentificacione
{
    public int IdCategoria { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal TotalCobertura { get; set; }

    public virtual ICollection<Sala> Salas { get; set; } = new List<Sala>();

    public virtual ICollection<ServiciosCategoria> ServiciosCategoria { get; set; } = new List<ServiciosCategoria>();

    public virtual ICollection<Atributo> IdAtributos { get; set; } = new List<Atributo>();
}
