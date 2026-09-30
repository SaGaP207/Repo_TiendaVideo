using System.ComponentModel.DataAnnotations.Schema;

namespace Lib_app.entidades
{
    public class Inventarios
    {
        public int Id { get; set; }
        public int Sucursal { get; set; }
        public int Cantidad { get; set; }
        public int Stock_Minimo { get; set; }
        public DateTime Fecha_Actualizacion { get; set; }

        [ForeignKey("Sucursal")] public Sucursales? _Sucursal { get; set; }
        //public List<Videojuegos> Videojuegos { get; set; } = new List<Videojuegos>();
    }
}
