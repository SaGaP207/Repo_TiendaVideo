using System.ComponentModel.DataAnnotations.Schema;

namespace Lib_app.entidades
{
    public class Ventas
    {
        public int Id { get; set; }
        public int Cliente { get; set; }
        public int Empleado { get; set; }
        public DateTime Fecha_Venta { get; set; }
        public decimal Total { get; set; }

        [ForeignKey("Cliente")] public Clientes? _Cliente { get; set; }
        [ForeignKey("Empleado")] public Empleados? _Empleado { get; set; }

        public List<Detalle_Ventas>? Detalle_Ventas { get; set; }
        public List<Metodo_Pagos>? Metodo_Pagos { get; set; } 

    }
}
