using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPDescargaArchivos.DTO
{
    public class UnidadDTO
    {
        public int IdCompania { get; set; }
        public int IdSucursal { get; set; }
        public int IdOrigen { get; set; }
        public int PeriodoYear { get; set; }
        public int PeriodoMes { get; set; }
        public int Cantidad { get; set; }
        public string Factura { get; set; }
        public DateTime FechaFactura { get; set; }
        public string TipoVenta { get; set; }
        public string TipoPago { get; set; }
        public string SerieNumero { get; set; }
        public string NumeroInventario { get; set; }
        public Decimal? Isan { get; set; }
         public Decimal? Costo { get; set; }
        public Decimal? Venta { get; set; }
        public Decimal? Utilidad { get; set; }
        public Decimal? Margen { get; set; }
        public string Anio { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }
        public string Interior { get; set; }
        public string NumeroVendedor { get; set; }
        public string NombreVendedor { get; set; }
        public DateTime FechaCompra { get; set; }
        public string NombreCliente { get; set; }
        public string Rfc { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string CodigoPostal { get; set; }
        public string Email { get; set; }
    }


    public class UnidadInventarioDTO
    {
        public int IdCompania { get; set; }
        public int IdSucursal { get; set; }
        public DateTime FechaHistorico { get; set; }
        public string SerieNumero { get; set; }
        public string NumeroInventario { get; set; }
        public int Anio { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string VersionUnidad { get; set; }
        public string Color { get; set; }
        public string Interior { get; set; }
        public Decimal Costo { get; set; }
        public DateTime FechaAlta { get; set; }
        public string Estatus { get; set; }
        public string TipoCompra { get; set; }
        public int IdOrigen { get; set; }
    }

    public class ServiciosDTO
    {
            public int IdCompania              { get; set; }
            public int IdSucursal              { get; set; }
            public DateTime FechaHistorico     { get; set; }
            public string Factura	           { get; set; }
            public DateTime FechaFactura	   { get; set; }
            public string NumeroOT	           { get; set; }
            public DateTime FechaApertura	   { get; set; }
            public DateTime FechaEntrega	   { get; set; }
            public string CodigoOperacion	   { get; set; }
            public string Descripcion	       { get; set; }
            public Decimal? CostoTOT	           { get; set; }
            public Decimal? CostoTotal	       { get; set; }
            public Decimal? VentaMO	           { get; set; }
            public Decimal? VentaMateriales	   { get; set; }
            public Decimal? VentaTOT	           { get; set; }
            public Decimal? VentaPartes	       { get; set; }
            public Decimal? CostoPartes	       { get; set; }
            public Decimal? VentaTotal	       { get; set; }
            public Decimal? DescuentoMO         { get; set; }
            public Decimal? DescuentoMateriales { get; set; }
            public Decimal? DescuentoPartes     { get; set; }
            public string Taller	           { get; set; }
            public string NumeroAsesor	       { get; set; }           
            public string NombreAsesor	       { get; set; }
            public string NombreCliente	       { get; set; }
            public string RFC	               { get; set; }
            public string Direccion	           { get; set; }
            public string Telefono	           { get; set; }
            public string CP	               { get; set; }
            public string Email	               { get; set; }
            public string Odometro	           { get; set; }
            public string vin	               { get; set; }
            public string Anio	               { get; set; }
            public string Marca	               { get; set; }
            public string Modelo	           { get; set; }
            public string Color	               { get; set; }
            public string TipoOrden	           { get; set; }
            public string TipoPago             { get; set; }
            public int idOrigen                { get; set; }
    }

    public class SEROEPDTO
    {
        public int IdCompania { get; set; }
        public int IdSucursal { get; set; }
        public DateTime FechaHistorico { get; set; }
        public string NumeroOT { get; set; }
        public DateTime FechaApertura { get; set; }
        public string Vin { get; set; }
        public int Dias { get; set; }
        public Decimal? Costo { get; set; }
        public Decimal? Venta { get; set; }
        public string TipoOrden { get; set; }
        public string Taller { get; set; }
        public string NumeroAsesor { get; set; }
        public string NombreAsesor { get; set; }
        public string NombreCliente { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string CP { get; set; }
        public int idOrigen { get; set; }
    }

    public class REFVTA
    {
        public int IdCompania { get; set; }
        public int IdSucursal { get; set; }
        public DateTime FechaHistorico { get; set; }
        public string Factura { get; set; }
        public DateTime FechaFactura { get; set; }
        public string NumeroParte { get; set; }
        public decimal Cantidad { get; set; }
        public decimal CostoUnit { get; set; }
        public decimal Costo { get; set; }
        public decimal VentaUnit { get; set; }
        public decimal Venta { get; set; }
        public string NombreCliente { get; set; }
        public string RFC { get; set; }
        public string TipoParte { get; set; }
        public int idOrigen { get; set; }
        public string NumeroOT { get; set; }
        public string Descripcion { get; set; }
        public string TipoVenta { get; set; }
        public string TipoOrden { get; set; }
    }

    public class REFINV
    {
        public int IdCompania { get; set; }
        public int IdSucursal { get; set; }
        public DateTime FechaHistorico { get; set; }
        public string NumeroParte { get; set; }
        public string Descripcion { get; set; }
        public string Almacen { get; set; }
        public decimal Existencia { get; set; }
        public decimal CostoUnit { get; set; }
        public decimal Costo { get; set; }
        public decimal Precio { get; set; }
        public decimal Precio2 { get; set; }
        public decimal Precio3 { get; set; }
        public decimal Precio4 { get; set; }
        public decimal Precio5 { get; set; }
        public string UltimaCompra { get; set; }
        public string UltimaVenta { get; set; }
        public string FechaAlta { get; set; }
        public string TipoParte { get; set; }
        public string Clasificacion { get; set; }
        public int idOrigen { get; set; }
    }
}
