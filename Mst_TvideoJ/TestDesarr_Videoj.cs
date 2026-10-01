using Lib_app.implementaciones;
using Lib_app.entidades;
using Lib_app.interfaces;
using Lib_app.nucleo;
using Microsoft.EntityFrameworkCore;

namespace Mst_TvideoJ
{
    [TestClass]
    public class PruebaDesarr_Videoj       //------
    {
        private Conexion conexion;
        private Desarr_Videoj entidad;    //------

        public PruebaDesarr_Videoj()           //------
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
            entidad = new Desarr_Videoj()    //------
            {
                Videojuego = 1,
                Desarrollador = 1,
                Fecha_Lanzamiento = DateTime.Now,
                Clasif_Edad = "+18"

            };

            this.conexion.Desarr_Videoj!.Add(this.entidad!);  //------
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista_desarr_videoj = this.conexion.Desarr_Videoj!.ToList(); //-----
            if (lista_desarr_videoj.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Clasif_Edad = "+15";        //-----

            var entry = this.conexion!.Entry<Desarr_Videoj>(this.entidad);  //------
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Desarr_Videoj!.Remove(this.entidad!);    //------
            this.conexion.SaveChanges();
        }
    }
}