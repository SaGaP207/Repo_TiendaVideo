using System.ComponentModel.DataAnnotations.Schema;

namespace Lib_app.entidades
{
    public class Metodo_Pagos
    {
        public int Id { get; set; }
        public int Venta { get; set; }
        public string? Tipo_Pago { get; set; }
        public string? Descripcion { get; set; }

        [ForeignKey("Venta")] public Ventas? _Venta { get; set; }
    }

}
