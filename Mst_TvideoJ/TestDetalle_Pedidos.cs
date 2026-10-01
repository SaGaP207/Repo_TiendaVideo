
using Lib_app.implementaciones;
using Lib_app.entidades;
using Lib_app.interfaces;
using Lib_app.nucleo;
using Microsoft.EntityFrameworkCore;

namespace Mst_TvideoJ
{
    [TestClass]
    public class PruebaDetalle_Pedidos        //------
    {
        private Conexion conexion;
        private Detalle_Pedidos entidad;    //------

        public PruebaDetalle_Pedidos()           //------
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
            entidad = new Detalle_Pedidos()    //------
            {
                Pedido = 1,
                Videojuego = 1,
                Cantidad = 2,
                Precio_Compra = 210000.00m,
                Subtotal = 210000.00m
            };

            this.conexion.Detalle_Pedidos!.Add(this.entidad!);  //------
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista_detalle_pedidos = this.conexion.Detalle_Pedidos!.ToList(); //-----
            if (lista_detalle_pedidos.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Cantidad = 4;        //-----

            var entry = this.conexion!.Entry<Detalle_Pedidos>(this.entidad);  //------
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Detalle_Pedidos!.Remove(this.entidad!);    //------
            this.conexion.SaveChanges();
        }
    }
}