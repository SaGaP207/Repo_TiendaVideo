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
        public List<Detalle_Ventas>? Detalle_Ventas { get; set; }
        public List<Detalle_Pedidos>? Detalle_Pedidos { get; set; }
        public List<VJ_Plataformas>? VJ_Plataformas { get; set; }
        public List<Resenas>? Resenas { get; set; }
        public List<Desarr_Videoj>? Desarr_Videoj { get; set; }
    }
}
