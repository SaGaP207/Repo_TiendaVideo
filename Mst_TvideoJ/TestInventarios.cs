using Lib_app.implementaciones;
using Lib_app.entidades;
using Lib_app.interfaces;
using Lib_app.nucleo;
using Microsoft.EntityFrameworkCore;

namespace Mst_TvideoJ
{
    [TestClass]
    public class PruebaInventarios         //------
    {
        private Conexion conexion;
        private Inventarios entidad;    //------

        public PruebaInventarios()           //------
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
            entidad = new Inventarios()    //------
            {
                Sucursal = 1,
                Cantidad = 12,
                Stock_Minimo = 5,
                Fecha_Actualizacion = DateTime.Now

            };

            this.conexion.Inventarios!.Add(this.entidad!);  //------
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista_inventarios = this.conexion.Inventarios!.ToList(); //-----
            if (lista_inventarios.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Stock_Minimo = 10;        //-----

            var entry = this.conexion!.Entry<Inventarios>(this.entidad);  //------
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Inventarios!.Remove(this.entidad!);    //------
            this.conexion.SaveChanges();
        }
    }
}
