using Lib_app.implementaciones;
using Lib_app.entidades;
using Lib_app.interfaces;
using Lib_app.nucleo;
using Microsoft.EntityFrameworkCore;

namespace Mst_TvideoJ
{
    [TestClass]
    public class PruebaResenas       //------
    {
        private Conexion conexion;
        private Resenas entidad;    //------

        public PruebaResenas()           //------
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
            entidad = new Resenas()    //------
            {
                Cliente = 1,
                Videojuego = 1,
                Puntuacion = 3.5m,
                Comentario = "excelente juego",
                Fecha_Resena = DateTime.Now
            };

            this.conexion.Resenas!.Add(this.entidad!);  //------
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista_resenas = this.conexion.Resenas!.ToList(); //-----
            if (lista_resenas.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Comentario = "porqueria de juego";        //-----

            var entry = this.conexion!.Entry<Resenas>(this.entidad);  //------
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Resenas!.Remove(this.entidad!);    //------
            this.conexion.SaveChanges();
        }
    }
}
