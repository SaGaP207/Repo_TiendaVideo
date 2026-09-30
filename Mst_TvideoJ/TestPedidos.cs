using Lib_app.implementaciones;
using Lib_app.entidades;
using Lib_app.interfaces;
using Lib_app.nucleo;
using Microsoft.EntityFrameworkCore;

namespace Mst_TvideoJ
{
    [TestClass]
    public class PruebaPedidos         //------
    {
        private Conexion conexion;
        private Pedidos entidad;    //------

        public PruebaPedidos()           //------
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
            entidad = new Pedidos()    //------
            {
                Proveedor = 1,
                Empleado = 1,
                Fecha_Pedido = DateTime.Now,
                Estado = true,
                Total = 87662.89m

            };

            this.conexion.Pedidos!.Add(this.entidad!);  //------
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista_pedidos = this.conexion.Pedidos!.ToList(); //-----
            if (lista_pedidos.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Estado = false;        //-----

            var entry = this.conexion!.Entry<Pedidos>(this.entidad);  //------
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Pedidos!.Remove(this.entidad!);    //------
            this.conexion.SaveChanges();
        }
    }
}
