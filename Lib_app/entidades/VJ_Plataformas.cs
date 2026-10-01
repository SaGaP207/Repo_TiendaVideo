
using Lib_app.entidades;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib_app.entidades
{
    public class VJ_Plataformas
    {
        public int Id { get; set; }
        public int Videojuego { get; set; }
        public int Plataforma { get; set; }
        public DateTime Fecha_Lanzamiento { get; set; }
        public decimal Precio_Plataforma { get; set; }

        [ForeignKey("Videojuego")] public Videojuegos? _Videojuego { get; set; }
        [ForeignKey("Plataforma")] public Plataformas? _Plataforma { get; set; }
        public List<VJ_Promociones> VJ_Promociones { get; set; } = new List<VJ_Promociones>();

    }
}