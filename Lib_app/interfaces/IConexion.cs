using Lib_app.entidades;
using Microsoft.EntityFrameworkCore;

namespace Lib_app.interfaces
{
    public interface IConexion
    {
        string? StringConexion { get; set; }

        DbSet<Sucursales>? Sucursales { get; set; }
        DbSet<Cargos>? Cargos { get; set; }
        DbSet<Empleados>? Empleados { get; set; }
        DbSet<Categorias>? Categorias { get; set; }
        DbSet<Clientes>? Clientes { get; set; }
        DbSet<Ventas>? Ventas { get; set; }
    }
}
