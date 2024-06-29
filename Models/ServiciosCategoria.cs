using System;
using System.Collections.Generic;

namespace Test.Models;

public partial class ServiciosCategoria
{
    public int IdServicio { get; set; }

    public int IdCategoria { get; set; }

    public decimal Costo { get; set; }

    public virtual TipoIdentificacione IdCategoriaNavigation { get; set; } = null!;

    public virtual Servicio IdServicioNavigation { get; set; } = null!;
}
