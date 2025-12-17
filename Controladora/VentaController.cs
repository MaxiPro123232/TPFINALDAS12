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

        public List<Venta> ObtenerTodas()
        {
            return _repositorio.ListarVentas();
        }

        public Venta? ObtenerPorId(int id)
        {
            return _repositorio.BuscarVentaPorId(id);
        }

        public string GenerarNumeroFactura()
        {
            return _repositorio.GenerarNumeroFactura();
        }

        public bool ProcesarVenta(Venta venta, List<DetalleVenta> detalles)
        {
            return _repositorio.ProcesarVenta(venta, detalles);
        }

        public List<Venta> ObtenerVentasPorPeriodo(DateTime fechaInicio, DateTime fechaFin)
        {
            return _repositorio.ListarVentasPorPeriodo(fechaInicio, fechaFin);
        }

        public List<Venta> ObtenerVentasPorProducto(int productoId)
        {
            return _repositorio.ListarVentasPorProducto(productoId);
        }

        public List<Venta> ObtenerVentasPorSucursal(int sucursalId)
        {
            return _repositorio.ListarVentasPorSucursal(sucursalId);
        }

        public List<Venta> ObtenerVentasPorVendedor(int vendedorId)
        {
            return _repositorio.ListarVentasPorVendedor(vendedorId);
        }

        public List<dynamic> ObtenerProductosMasVendidos(int? top = 10)
        {
            return _repositorio.ObtenerProductosMasVendidos(top);
        }
    }
}

