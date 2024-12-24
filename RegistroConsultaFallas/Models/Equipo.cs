using System;
using System.Collections.Generic;

namespace RegistroConsultaFallas.Models;

public partial class Equipo
{
    public int IdEquipo { get; set; }

    public int IdPropietario { get; set; }

    public string NombreEquipo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<Falla> Fallas { get; set; } = new List<Falla>();

    public virtual Propietario IdPropietarioNavigation { get; set; } = null!;
}
