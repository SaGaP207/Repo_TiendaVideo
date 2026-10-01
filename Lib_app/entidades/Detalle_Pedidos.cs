using Lib_app.entidades;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib_app.entidades
{
    public class Detalle_Pedidos
    {
        public int Id { get; set; }
        public int Pedido { get; set; }
        public int Videojuego { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio_Compra { get; set; }
        public decimal Subtotal { get; set; }



        [ForeignKey("Pedido")] public Pedidos? _Pedido { get; set; }
        [ForeignKey("Videojuego")] public Videojuegos? _Videojuego { get; set; }

    }
}
