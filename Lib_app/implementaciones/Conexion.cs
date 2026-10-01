
using Lib_app.entidades;
using Lib_app.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lib_app.implementaciones
{
    public class Conexion : DbContext, IConexion
    {
        public string? StringConexion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        public DbSet<Sucursales>? Sucursales { get; set; }
        public DbSet<Cargos>? Cargos { get; set; }
        public DbSet<Empleados>? Empleados { get; set; }
        public DbSet<Categorias>? Categorias { get; set; }
        public DbSet<Clientes>? Clientes { get; set; }
        public DbSet<Ventas>? Ventas { get; set; }
        public DbSet<Metodo_Pagos>? Metodo_Pagos { get; set; }
        public DbSet<Inventarios>? Inventarios { get; set; }
        public DbSet<Proveedores>? Proveedores { get; set; }
        public DbSet<Pedidos>? Pedidos { get; set; }
        public DbSet<Videojuegos>? Videojuegos { get; set; }
        public DbSet<Detalle_Ventas>? Detalle_Ventas { get; set; }
        public DbSet<Detalle_Pedidos>? Detalle_Pedidos { get; set; }
        public DbSet<Plataformas>? Plataformas { get; set; }
        public DbSet<VJ_Plataformas>? VJ_Plataformas { get; set; }
        public DbSet<Resenas>? Resenas { get; set; }
        public DbSet<Promociones>? Promociones { get; set; }
        public DbSet<VJ_Promociones>? VJ_Promociones { get; set; }
        public DbSet<Desarrolladores>? Desarrolladores { get; set; }
        public DbSet<Desarr_Videoj>? Desarr_Videoj { get; set; }

    }
}
