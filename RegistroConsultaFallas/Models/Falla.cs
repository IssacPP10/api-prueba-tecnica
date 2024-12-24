using System;
using System.Collections.Generic;

namespace RegistroConsultaFallas.Models;

public partial class Falla
{
    public int IdFalla { get; set; }

    public int IdEquipo { get; set; }

    public string DescripcionFalla { get; set; } = null!;

    public DateTime FechaFalla { get; set; }

    public virtual Equipo IdEquipoNavigation { get; set; } = null!;
}
