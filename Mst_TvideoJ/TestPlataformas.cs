
using Lib_app.implementaciones;
using Lib_app.entidades;
using Lib_app.interfaces;
using Lib_app.nucleo;
using Microsoft.EntityFrameworkCore;

namespace Mst_TvideoJ
{
    [TestClass]
    public class PruebaPlataformas        //------
    {
        private Conexion conexion;
        private Plataformas entidad;    //------

        public PruebaPlataformas()           //------
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
            entidad = new Plataformas()    //------
            {
                Nombre = "PlayStation 5 (PS5)",
                Fabricante = "Sony Interactive Entertainment",
                Tipo_Plataforma = "Consola de videojuegos de sobremesa",
                Estado = true
            };

            this.conexion.Plataformas!.Add(this.entidad!);  //------
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista_plataformas = this.conexion.Plataformas!.ToList(); //-----
            if (lista_plataformas.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Estado = false;        //-----

            var entry = this.conexion!.Entry<Plataformas>(this.entidad);  //------
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Plataformas!.Remove(this.entidad!);    //------
            this.conexion.SaveChanges();
        }
    }
}