namespace Lib_app.entidades
{
    public class Promociones
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal Porcentaje_Desc { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Fin { get; set; }

        public List<VJ_Promociones> VJ_Promociones { get; set; } = new List<VJ_Promociones>();

    }
}
