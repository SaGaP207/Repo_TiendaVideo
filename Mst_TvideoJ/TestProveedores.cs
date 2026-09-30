using Lib_app.implementaciones;
using Lib_app.entidades;
using Lib_app.interfaces;
using Lib_app.nucleo;
using Microsoft.EntityFrameworkCore;

namespace Mst_TvideoJ
{
    [TestClass]
    public class PruebaProveedores         //------
    {
        private Conexion conexion;
        private Proveedores entidad;    //------

        public PruebaProveedores()           //------
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
            entidad = new Proveedores()    //------
            {
                Nit = "123",
                Nombre_Empresa = "Prueba",
                Telefono = "333213",
                Correo = "example@mail.com",

            };

            this.conexion.Proveedores!.Add(this.entidad!);  //------
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista_proveedores = this.conexion.Proveedores!.ToList(); //-----
            if (lista_proveedores.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Telefono = "111111";        //-----

            var entry = this.conexion!.Entry<Proveedores>(this.entidad);  //------
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Proveedores!.Remove(this.entidad!);    //------
            this.conexion.SaveChanges();
        }
    }
}
