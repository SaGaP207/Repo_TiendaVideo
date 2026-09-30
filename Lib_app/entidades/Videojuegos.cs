using System.ComponentModel.DataAnnotations.Schema;

namespace Lib_app.entidades
{
    public class Videojuegos
    {
        public int Id { get; set; }
        public int Categoria { get; set; }
        public int Inventario { get; set; }
        public string? Nombre { get; set; }
        public decimal Precio { get; set; }
        public bool Estado { get; set; }

        [ForeignKey("Categoria")] public Categorias? _Categoria { get; set; }
        [ForeignKey("Inventario")] public Inventarios? _Inventario { get; set; }
        //public List<Detalle_Ventas> Detalle_Ventas { get; set; } = new List<Detalle_Ventas>();
        //public List<Detalle_Pedidos> Detalle_Pedidos { get; set; } = new List<Detalle_Pedidos>();
        //public List<VJ_Plataformas> VJ_Plataformas { get; set; } = new List<VJ_Plataformas>();
        //public List<Resenas> Resenas { get; set; } = new List<Resenas>();
        //public List<Desarr_Videoj> Desarr_Videoj { get; set; } = new List<Desarr_Videoj>();
    }
}
