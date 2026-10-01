using Lib_app.implementaciones;
using Lib_app.entidades;
using Lib_app.interfaces;
using Lib_app.nucleo;
using Microsoft.EntityFrameworkCore;

namespace Mst_TvideoJ
{
    [TestClass]
    public class PruebaDesarrolladores        //------
    {
        private Conexion conexion;
    private Desarrolladores entidad;    //------

    public PruebaDesarrolladores()           //------
    {
        this.conexion = new Conexion();
        conexion.StringConexion = General.GetStringConexion();
    }

    [TestMethod]
    public void Ejecutar()
    {
        Insertar();
        Consultar();
        Actualizar();
        Borrar();
    }

    private void Insertar()
    {
        entidad = new Desarrolladores()    //------
        {
            Nombre = "julian",
            Nit = "1128275612",
            Pais = "colombia",
            Sitio_Web = "juli88524@gmail.com"

        };

        this.conexion.Desarrolladores!.Add(this.entidad!);  //------
        this.conexion.SaveChanges();
    }

    public void Consultar()
    {
        var lista_desarrolladores = this.conexion.Desarrolladores!.ToList(); //-----
        if (lista_desarrolladores.Count <= 0)
            throw new Exception("Lista vacia");
    }

    private void Actualizar()
    {
        this.entidad!.Pais = "mexico";        //-----

        var entry = this.conexion!.Entry<Desarrolladores>(this.entidad);  //------
        entry.State = EntityState.Modified;
        this.conexion!.SaveChanges();
    }

    private void Borrar()
    {
        this.conexion.Desarrolladores!.Remove(this.entidad!);    //------
        this.conexion.SaveChanges();
    }
}
}
