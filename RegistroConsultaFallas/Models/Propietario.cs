using System;
using System.Collections.Generic;

namespace RegistroConsultaFallas.Models;

public partial class Propietario
{
    public int IdPropietario { get; set; }

    public string NombrePropietario { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Equipo> Equipos { get; set; } = new List<Equipo>();
}
