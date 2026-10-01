using Lib_app.implementaciones;
using Lib_app.entidades;
using Lib_app.interfaces;
using Lib_app.nucleo;
using Microsoft.EntityFrameworkCore;

namespace Mst_TvideoJ
{
    [TestClass]
    public class PruebaVJ_Promociones     //------
    {
        private Conexion conexion;
        private VJ_Promociones entidad;    //------

        public PruebaVJ_Promociones()           //------
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
            entidad = new VJ_Promociones()    //------
            {
                Vj_Plataforma = 1,
                Promocion = 1,
                Precio_Promocion = 150.50m,
            };

            this.conexion.VJ_Promociones!.Add(this.entidad!);  //------
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista_Vj_promociones = this.conexion.VJ_Promociones!.ToList(); //-----
            if (lista_Vj_promociones.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Precio_Promocion = 17000.50m;       //-----

            var entry = this.conexion!.Entry<VJ_Promociones>(this.entidad);  //------
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.VJ_Promociones!.Remove(this.entidad!);    //------
            this.conexion.SaveChanges();
        }
    }
}
