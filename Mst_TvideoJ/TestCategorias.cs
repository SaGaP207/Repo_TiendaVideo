using Lib_app.implementaciones;
using Lib_app.entidades;
using Lib_app.interfaces;
using Lib_app.nucleo;
using Microsoft.EntityFrameworkCore;

namespace Mst_TvideoJ
{
    [TestClass]
    public class PruebaCategorias
    {
        private Conexion conexion;
        private Categorias entidad;    //------

        public PruebaCategorias()
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
            entidad = new Categorias()    //------
            {
                Nombre = "Prueba",
                Descripcion = "Si",
                Estado = true,
                Fecha_Creacion = DateTime.Now
            };

            this.conexion.Categorias!.Add(this.entidad!);  //------
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista_categorias = this.conexion.Categorias!.ToList(); //-----
            if (lista_categorias.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Estado = false;

            var entry = this.conexion!.Entry<Categorias>(this.entidad);  //------
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Categorias!.Remove(this.entidad!);    //------
            this.conexion.SaveChanges();
        }
    }
}
