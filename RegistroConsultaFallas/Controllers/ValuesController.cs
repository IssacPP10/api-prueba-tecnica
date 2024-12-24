using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistroConsultaFallas.Models;

namespace RegistroConsultaFallas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly PtRegistroFallasEquiposContext _baseDatos;

        public ValuesController(PtRegistroFallasEquiposContext baseDatos)
        {
            _baseDatos = baseDatos;
        }

        [HttpGet]
        [Route("Registros")]
        public async Task<IActionResult> Registros(
        [FromQuery] string descripcionFalla = null,
        [FromQuery] DateTime? fechaFalla = null,
        [FromQuery] string nombrePropietario = null)
        {
            var query = _baseDatos.Fallas
                .Include(f => f.IdEquipoNavigation)
                    .ThenInclude(e => e.IdPropietarioNavigation)
                .AsQueryable();

            // Aplicar filtros opcionales
            if (!string.IsNullOrEmpty(descripcionFalla))
            {
                query = query.Where(f => f.DescripcionFalla.Contains(descripcionFalla));
            }

            if (fechaFalla.HasValue)
            {
                query = query.Where(f => f.FechaFalla.Date == fechaFalla.Value.Date);
            }

            if (!string.IsNullOrEmpty(nombrePropietario))
            {
                query = query.Where(f => f.IdEquipoNavigation.IdPropietarioNavigation.NombrePropietario.Contains(nombrePropietario));
            }

            var registros = await query
                .Select(f => new
                {
                    f.IdFalla,
                    f.DescripcionFalla,
                    f.FechaFalla,
                    EquipoNombre = f.IdEquipoNavigation.NombreEquipo,
                    PropietarioNombre = f.IdEquipoNavigation.IdPropietarioNavigation.NombrePropietario,
                    PropietarioEmail = f.IdEquipoNavigation.IdPropietarioNavigation.Email
                })
                .ToListAsync();

            return Ok(registros);
        }

        [HttpPost]
        [Route("RegistrarFalla")]
        public async Task<IActionResult> RegistrarFalla([FromBody] FallaCreateDto fallaCreateDto)
        {
            // Crear el nuevo propietario
            var propietario = new Propietario
            {
                NombrePropietario = fallaCreateDto.NombrePropietario,
                Email = fallaCreateDto.Email
            };
            _baseDatos.Propietarios.Add(propietario);
            await _baseDatos.SaveChangesAsync();

            // Crear el nuevo equipo
            var equipo = new Equipo
            {
                NombreEquipo = fallaCreateDto.NombreEquipo,
                Descripcion = fallaCreateDto.DescripcionFalla,
                IdPropietario = propietario.IdPropietario
            };
            _baseDatos.Equipos.Add(equipo);
            await _baseDatos.SaveChangesAsync();

            // Crear la nueva falla
            var falla = new Falla
            {
                IdEquipo = equipo.IdEquipo,
                DescripcionFalla = fallaCreateDto.DescripcionFalla,
                FechaFalla = fallaCreateDto.FechaFalla
            };
            _baseDatos.Fallas.Add(falla);
            await _baseDatos.SaveChangesAsync();

            return Ok(new
            {
                IdFalla = falla.IdFalla,
                Mensaje = "Falla registrada exitosamente."
            });
        }
    }
}
