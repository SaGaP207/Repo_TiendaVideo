using Lib_app.implementaciones;
using Lib_app.entidades;
using Lib_app.interfaces;
using Lib_app.nucleo;
using Microsoft.EntityFrameworkCore;

namespace Mst_TvideoJ
{
    [TestClass]
    public class PruebaDetalle_Ventas        //------
    {
        private Conexion conexion;
        private Detalle_Ventas entidad;    //------

        public PruebaDetalle_Ventas()           //------
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
            entidad = new Detalle_Ventas()    //------
            {
                Venta = 1,
                Videojuego = 1,
                Cantidad = 2,
                Precio_Unitario = 210000.00m,
                Subtotal = 210000.00m
            };

            this.conexion.Detalle_Ventas!.Add(this.entidad!);  //------
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista_detalle_ventas = this.conexion.Detalle_Ventas!.ToList(); //-----
            if (lista_detalle_ventas.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Subtotal = 110000.00m;        //-----

            var entry = this.conexion!.Entry<Detalle_Ventas>(this.entidad);  //------
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Detalle_Ventas!.Remove(this.entidad!);    //------
            this.conexion.SaveChanges();
        }
    }
}