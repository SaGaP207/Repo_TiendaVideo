using System.ComponentModel.DataAnnotations.Schema;

namespace Lib_app.entidades
{
    public class Pedidos
    {
        public int Id { get; set; }
        public int Proveedor { get; set; }
        public int Empleado { get; set; }
        public DateTime Fecha_Pedido { get; set; }
        public bool Estado { get; set; }
        public decimal Total { get; set; }

        [ForeignKey("Proveedor")] public Proveedores? _Proveedor { get; set; }
        [ForeignKey("Empleado")] public Empleados? _Empleado { get; set; }
        //public List<Detalle_Pedidos> Detalle_Pedidos { get; set; } = new List<Detalle_Pedidos>();
    }
}
