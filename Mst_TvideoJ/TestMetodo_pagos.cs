using Lib_app.implementaciones;
using Lib_app.entidades;
using Lib_app.interfaces;
using Lib_app.nucleo;
using Microsoft.EntityFrameworkCore;

namespace Mst_TvideoJ
{
    [TestClass]
    public class PruebaMetodo_Pagos         //------
    {
        private Conexion conexion;
        private Metodo_Pagos entidad;    //------

        public PruebaMetodo_Pagos()           //------
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
            entidad = new Metodo_Pagos ()    //------
            {
                Venta = 1,
                Tipo_Pago = "efectivo",
                Descripcion = "pago en caja"
            
            };

            this.conexion.Metodo_Pagos!.Add(this.entidad!);  //------
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista_metodo_pagos = this.conexion.Metodo_Pagos!.ToList(); //-----
            if (lista_metodo_pagos.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Tipo_Pago = "credito";        //-----

            var entry = this.conexion!.Entry<Metodo_Pagos>(this.entidad);  //------
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Metodo_Pagos!.Remove(this.entidad!);    //------
            this.conexion.SaveChanges();
        }
    }
}
