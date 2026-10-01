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
        DbSet<Metodo_Pagos>? Metodo_Pagos { get; set; }
        DbSet<Inventarios>? Inventarios { get; set; }
        DbSet<Proveedores>? Proveedores { get; set; }
        DbSet<Pedidos>? Pedidos { get; set; }
        DbSet<Videojuegos>? Videojuegos { get; set; }
        DbSet<Detalle_Ventas>? Detalle_Ventas { get; set; }
        DbSet<Detalle_Pedidos>? Detalle_Pedidos { get; set; }
        DbSet<Plataformas>? Plataformas { get; set; }
        DbSet<VJ_Plataformas>? VJ_Plataformas { get; set; }
        DbSet<Resenas>? Resenas { get; set; }
        DbSet<Promociones>? Promociones { get; set; }
        DbSet<VJ_Promociones>? VJ_Promociones { get; set; }
        DbSet<Desarrolladores>? Desarrolladores { get; set; }
        DbSet<Desarr_Videoj>? Desarr_Videoj { get; set; }
    }
}
