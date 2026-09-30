using Lib_app.implementaciones;
using Lib_app.entidades;
using Lib_app.interfaces;
using Lib_app.nucleo;
using Microsoft.EntityFrameworkCore;

namespace Mst_TvideoJ
{
    [TestClass]
    public class PruebaSucursales
    {
        private Conexion conexion;
        private Sucursales entidad;

        public PruebaSucursales()
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
                entidad = new Sucursales()
                {
                    Nombre = "Prueba",
                    Direccion = "cll 1 # 1",
                    Ciudad = "Agua",
                    Telefono = "342",
                    Estado = true

                };

                this.conexion.Sucursales!.Add(this.entidad!);
                this.conexion.SaveChanges();
            }

            public void Consultar()
            {
                var lista_sucursales = this.conexion.Sucursales!.ToList();
                if (lista_sucursales.Count <= 0)
                    throw new Exception("Lista vacia");
            }

            private void Actualizar()
            {
                this.entidad!.Estado = false;

                var entry = this.conexion!.Entry<Sucursales>(this.entidad);
                entry.State = EntityState.Modified;
                this.conexion!.SaveChanges();
            }

            private void Borrar()
            {
                this.conexion.Sucursales!.Remove(this.entidad!);
                this.conexion.SaveChanges();
            }
        }
    }
