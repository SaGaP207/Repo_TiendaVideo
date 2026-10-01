using Lib_app.entidades;
using Lib_app.implementaciones;
using Lib_app.interfaces;
using Lib_app.nucleo;
using Microsoft.EntityFrameworkCore;

namespace Mst_TvideoJ
{
    [TestClass]
    public class PruebaPromociones       //------
    {
        private Conexion conexion;
        private Promociones entidad;    //------

        public PruebaPromociones()           //------
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
            entidad = new Promociones()    //------
            {
                Nombre = "super promo",
                Descripcion = "Hasta el 1 de noviembre 2026",
                Porcentaje_Desc = 15.50m,
                Fecha_Inicio = DateTime.Now,
                Fecha_Fin = DateTime.Now
            };

            this.conexion.Promociones!.Add(this.entidad!);  //------
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista_promociones = this.conexion.Promociones!.ToList(); //-----
            if (lista_promociones.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Descripcion = "Hasta el 12 de noviembre 2026";        //-----

            var entry = this.conexion!.Entry<Promociones>(this.entidad);  //------
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Promociones!.Remove(this.entidad!);    //------
            this.conexion.SaveChanges();
        }
    }
}