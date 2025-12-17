using TechStore.Entidades;
using TechStore.Modelo;

namespace TechStore.Controladores
{
    public class VentaController
    {
        private readonly RepositorioVenta _repositorio;

        public VentaController()
        {
            _repositorio = new RepositorioVenta();
        }

        // Retorna todas las ventas. No modifica BD.
        public List<Venta> ObtenerTodas()
        {
            return _repositorio.ListarVentas();
        }

        // Busca una venta por ID. Parámetros: id. Retorna la venta o null.
        public Venta? ObtenerPorId(int id)
        {
            return _repositorio.BuscarVentaPorId(id);
        }

        // Genera un número de factura único. Retorna el número generado.
        public string GenerarNumeroFactura()
        {
            return _repositorio.GenerarNumeroFactura();
        }

        // Procesa una venta completa: valida stock, calcula totales, guarda venta y detalles, actualiza stock. Parámetros: venta, detalles. Retorna true si se procesó, false si falló. Modifica BD.
        public bool ProcesarVenta(Venta venta, List<DetalleVenta> detalles)
        {
            return _repositorio.ProcesarVenta(venta, detalles);
        }

        // Retorna ventas dentro de un rango de fechas. Parámetros: fechaInicio, fechaFin. No modifica BD.
        public List<Venta> ObtenerVentasPorPeriodo(DateTime fechaInicio, DateTime fechaFin)
        {
            return _repositorio.ListarVentasPorPeriodo(fechaInicio, fechaFin);
        }

        // Retorna ventas que contengan un producto específico. Parámetros: productoId. No modifica BD.
        public List<Venta> ObtenerVentasPorProducto(int productoId)
        {
            return _repositorio.ListarVentasPorProducto(productoId);
        }

        // Retorna ventas de una sucursal específica. Parámetros: sucursalId. No modifica BD.
        public List<Venta> ObtenerVentasPorSucursal(int sucursalId)
        {
            return _repositorio.ListarVentasPorSucursal(sucursalId);
        }

        // Retorna ventas realizadas por un vendedor específico. Parámetros: vendedorId. No modifica BD.
        public List<Venta> ObtenerVentasPorVendedor(int vendedorId)
        {
            return _repositorio.ListarVentasPorVendedor(vendedorId);
        }

        // Retorna los productos más vendidos con estadísticas. Parámetros: top (cantidad, default 10). No modifica BD.
        public List<dynamic> ObtenerProductosMasVendidos(int? top = 10)
        {
            return _repositorio.ObtenerProductosMasVendidos(top);
        }
    }
}

