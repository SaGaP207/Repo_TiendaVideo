using Lib_app.entidades;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib_app.entidades
{
    public class Resenas
    {
        public int Id { get; set; }
        public int Cliente { get; set; }
        public int Videojuego { get; set; }
        public decimal Puntuacion { get; set; }
        public string? Comentario { get; set; }
        public DateTime Fecha_Resena { get; set; }

        [ForeignKey("Cliente")] public Clientes? _Cliente { get; set; }
        [ForeignKey("Videojuego")] public Videojuegos? _Videojuego { get; set; }

    }
}
