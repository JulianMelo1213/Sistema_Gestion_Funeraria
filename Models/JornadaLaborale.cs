using System;
using System.Collections.Generic;

namespace Test.Models;

public partial class JornadaLaborale
{
    public int IdJornadaLaboral { get; set; }

    public DateOnly FechaEntrada { get; set; }

    public DateOnly FechaSalida { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
