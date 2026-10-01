using Lib_app.entidades;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib_app.entidades
{
    public class Desarr_Videoj
    {
        public int Id { get; set; }
        public int Videojuego { get; set; }
        public int Desarrollador { get; set; }
        public DateTime Fecha_Lanzamiento { get; set; }
        public string? Clasif_Edad { get; set; }

        [ForeignKey("Videojuego")] public Videojuegos? _Videojuego { get; set; }
        [ForeignKey("Desarrollador")] public Desarrolladores? _Desarrollador { get; set; }
    }
}
