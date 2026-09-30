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
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}

Console.WriteLine("Cnl_TvideoJ");