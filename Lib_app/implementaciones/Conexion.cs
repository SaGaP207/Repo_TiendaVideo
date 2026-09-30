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
    }
}
