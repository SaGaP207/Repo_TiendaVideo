using Lib_app.implementaciones;
using Lib_app.entidades;
using Lib_app.interfaces;
using Lib_app.nucleo;
using Microsoft.EntityFrameworkCore;

namespace Mst_TvideoJ
{
    [TestClass]
    public class PruebaVJ_Plataformas       //------
    {
        private Conexion conexion;
        private VJ_Plataformas entidad;    //------

        public PruebaVJ_Plataformas()           //------
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
            entidad = new VJ_Plataformas()    //------
            {
                Videojuego = 1,
                Plataforma = 1,
                Fecha_Lanzamiento = DateTime.Now,
                Precio_Plataforma = 3210000.00m
            };

            this.conexion.VJ_Plataformas!.Add(this.entidad!);  //------
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista_Vj_plataformas = this.conexion.VJ_Plataformas!.ToList(); //-----
            if (lista_Vj_plataformas.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Precio_Plataforma = 5210000.00m;        //-----

            var entry = this.conexion!.Entry<VJ_Plataformas>(this.entidad);  //------
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.VJ_Plataformas!.Remove(this.entidad!);    //------
            this.conexion.SaveChanges();
        }
    }
}
