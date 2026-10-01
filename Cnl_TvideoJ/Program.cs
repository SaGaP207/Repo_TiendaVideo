using Lib_app.implementaciones;
using Lib_app.interfaces;
using Lib_app.nucleo;
using Microsoft.EntityFrameworkCore;

try
{
    IConexion conexion = new Conexion();
    conexion.StringConexion = General.GetStringConexion();
    var lista_sucursales = conexion.Sucursales!.ToList();
    var lista_cargos = conexion.Cargos!.ToList();
    var lista_empleados = conexion.Empleados!.Include (x=> x._Sucursal).Include(x => x._Cargo).ToList();
    var lista_categorias = conexion.Categorias!.ToList();
    var lista_clientes = conexion.Clientes!.ToList();
    var lista_ventas = conexion.Ventas!.Include(x => x._Empleado).Include(x => x._Cliente).ToList();
    var lista_metodo_pagos = conexion.Metodo_Pagos!.Include(x => x._Venta).ToList();
    var lista_inventarios = conexion.Inventarios!.Include(x => x._Sucursal).ToList();
    var lista_proveedores = conexion.Proveedores!.ToList();
    var lista_pedidos = conexion.Pedidos!.Include(x => x._Proveedor).Include(x => x._Empleado).ToList();
    var lista_videojuegos = conexion.Videojuegos!.Include(x => x._Inventario).Include(x => x._Categoria).ToList();
    var lista_detalle_ventas = conexion.Detalle_Ventas!.Include (x=> x._Venta).Include(x => x._Videojuego).ToList();
    var lista_detalle_pedidos = conexion.Detalle_Pedidos!.Include(x => x._Pedido).Include(x => x._Videojuego).ToList();
    var lista_plataformas = conexion.Plataformas!.ToList();
    var lista_Vj_plataformas = conexion.VJ_Plataformas!.Include(x => x._Videojuego).Include(x => x._Plataforma).ToList();
    var lista_resenas = conexion.Resenas!.Include(x => x._Cliente).Include(x => x._Videojuego).ToList();
    var lista_promociones = conexion.Promociones!.ToList();
    var lista_Vj_promociones = conexion.VJ_Promociones!.Include(x => x._Vj_Plataforma).Include(x => x._Promocion).ToList();
    var lista_desarrolladores = conexion.Desarrolladores!.ToList();
    var lista_desarr_videoj = conexion.Desarr_Videoj!.Include(x => x._Videojuego).Include(x => x._Desarrollador).ToList();



}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}

Console.WriteLine("Cnl_TvideoJ");