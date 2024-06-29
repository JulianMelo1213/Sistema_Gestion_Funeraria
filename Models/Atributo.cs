using System;
using System.Collections.Generic;

namespace Test.Models;

public partial class Atributo
{
    public int IdAtributo { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<TipoIdentificacione> IdCategoria { get; set; } = new List<TipoIdentificacione>();
}
