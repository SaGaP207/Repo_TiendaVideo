
using Lib_app.entidades;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib_app.entidades
{
    public class VJ_Promociones
    {
        public int Id { get; set; }
        public int Vj_Plataforma { get; set; }
        public int Promocion { get; set; }
        public decimal Precio_Promocion { get; set; }

        [ForeignKey("Vj_Plataforma")] public VJ_Plataformas? _Vj_Plataforma { get; set; }
        [ForeignKey("Promocion")] public Promociones? _Promocion { get; set; }
    }
}