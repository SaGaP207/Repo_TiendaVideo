using Lib_app.implementaciones;
using Lib_app.entidades;
using Lib_app.interfaces;
using Lib_app.nucleo;
using Microsoft.EntityFrameworkCore;

namespace Mst_TvideoJ
{
    [TestClass]
    public class PruebaVentas         //------
    {
        private Conexion conexion;
        private Ventas entidad;    //------

        public PruebaVentas()           //------
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
            entidad = new Ventas()    //------
            {
                Cliente = 1,
                Empleado = 1,
                Fecha_Venta = DateTime.Now,
                Total = 120000.12m
            };

            this.conexion.Ventas!.Add(this.entidad!);  //------
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista_ventas = this.conexion.Ventas!.ToList(); //-----
            if (lista_ventas.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Total = 3123;        //-----

            var entry = this.conexion!.Entry<Ventas>(this.entidad);  //------
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Ventas!.Remove(this.entidad!);    //------
            this.conexion.SaveChanges();
        }
    }
}
