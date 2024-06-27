using System;
using System.Collections.Generic;

namespace Test.Models;

public partial class Difunto
{
    public int IdDifunto { get; set; }

    public string NombreDifunto { get; set; } = null!;

    public int IdTipoIdentificacion { get; set; }

    public string Identificacion { get; set; } = null!;

    public string Representante { get; set; } = null!;

    public string? RepresentanteTelefono { get; set; }

    public DateOnly FechaFallecimiento { get; set; }

    public TimeOnly HorarioEntrada { get; set; }

    public TimeOnly HorarioSalida { get; set; }

    public byte[] CertificacionDefuncion { get; set; } = null!;

    public int IdSala { get; set; }

    public virtual TipoIdentificacione IdDifuntoNavigation { get; set; } = null!;

    public virtual Sala IdSalaNavigation { get; set; } = null!;

    public virtual ICollection<LibroFirma> LibroFirmas { get; set; } = new List<LibroFirma>();
}
