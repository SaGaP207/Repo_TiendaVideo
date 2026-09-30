using Lib_app.implementaciones;
using Lib_app.entidades;
using Lib_app.interfaces;
using Lib_app.nucleo;
using Microsoft.EntityFrameworkCore;

namespace Mst_TvideoJ
{
    [TestClass]
    public class PruebaClientes         //------
    {
        private Conexion conexion;
        private Clientes entidad;    //------

        public PruebaClientes()           //------
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
            entidad = new Clientes()    //------
            {
                Nombre = "Prueba",
                Cedula = "123",
                Direccion = "Prueba",
                Ciudad = "Prueba"
            };

            this.conexion.Clientes!.Add(this.entidad!);  //------
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista_clientes = this.conexion.Clientes!.ToList(); //-----
            if (lista_clientes.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Cedula = "321";        //-----

            var entry = this.conexion!.Entry<Clientes>(this.entidad);  //------
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Clientes!.Remove(this.entidad!);    //------
            this.conexion.SaveChanges();
        }
    }
}
