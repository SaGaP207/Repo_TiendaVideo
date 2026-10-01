namespace Lib_app.entidades
{
    public class Plataformas
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Fabricante { get; set; }
        public string? Tipo_Plataforma { get; set; }
        public bool Estado { get; set; }

        public List<VJ_Plataformas>? VJ_Plataformas { get; set; }

    }
}
