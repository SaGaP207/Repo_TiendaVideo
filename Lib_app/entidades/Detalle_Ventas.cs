
using Lib_app.entidades;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib_app.entidades
{
    public class Detalle_Ventas
    {
        public int Id { get; set; }
        public int Venta { get; set; }
        public int Videojuego { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio_Unitario { get; set; }
        public decimal Subtotal { get; set; }


        [ForeignKey("Venta")] public Ventas? _Venta { get; set; }
        [ForeignKey("Videojuego")] public Videojuegos? _Videojuego { get; set; }

    }
}