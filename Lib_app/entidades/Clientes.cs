namespace Lib_app.entidades
{
    public class Clientes
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Cedula { get; set; }
        public string? Direccion { get; set; }
        public string? Ciudad { get; set; }

        public List<Ventas>? Ventas { get; set; }
        //public List<Resenas> Resenas { get; set; } = new List<Resenas>();
    }
}
