using Lib_app.implementaciones;
using Lib_app.entidades;
using Lib_app.interfaces;
using Lib_app.nucleo;
using Microsoft.EntityFrameworkCore;

namespace Mst_TvideoJ
{
    [TestClass]
    public class PruebaVideojuegos         //------
    {
        private Conexion conexion;
        private Videojuegos entidad;    //------

        public PruebaVideojuegos()           //------
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
            entidad = new Videojuegos()    //------
            {
                Categoria = 1,
                Inventario = 1,
                Nombre = "Test",
                Precio = 20000.02m,
                Estado = true

            };

            this.conexion.Videojuegos!.Add(this.entidad!);  //------
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista_videojuegos = this.conexion.Videojuegos!.ToList(); //-----
            if (lista_videojuegos.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Estado = false;        //-----

            var entry = this.conexion!.Entry<Videojuegos>(this.entidad);  //------
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Videojuegos!.Remove(this.entidad!);    //------
            this.conexion.SaveChanges();
        }
    }
}
