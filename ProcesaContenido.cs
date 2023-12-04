using FTPDescargaArchivos.Data;
using FTPDescargaArchivos.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPDescargaArchivos
{
    public class ProcesaContenido
    {
        public void GuardarVentaUnidad(string[] contenidoArchivo, int idCompania, int idSucursal)
        {
            Console.WriteLine("Inicio proceso Ventas Unidad W32 : " + idCompania);
            int posicion = 0;
            List<UnidadDTO> unidadList = new List<UnidadDTO>();
            try
            {
                foreach (var linea in contenidoArchivo)
                {
                    if (posicion > 1)
                    {
                        string[] valores = linea.Split('|');
                        unidadList.Add(new UnidadDTO
                        {
                            IdCompania = idCompania,
                            IdSucursal = idSucursal,
                            Cantidad = Convert.ToDecimal(valores[8]) > 0 ? 1 : -1,
                            Factura = valores[1].ToString(),
                            FechaFactura = Convert.ToDateTime(valores[2]),
                            TipoVenta = valores[3].ToString(),
                            TipoPago = valores[4].ToString(),
                            SerieNumero = valores[5].ToString(),
                            NumeroInventario = valores[6].ToString(),
                            Isan = this.ConvertirStringToDecimal(valores[7]),
                            Costo = this.ConvertirStringToDecimal(valores[8]),
                            Venta = this.ConvertirStringToDecimal(valores[9]),
                            Utilidad = this.ConvertirStringToDecimal(valores[10]),
                            Margen = this.ConvertirStringToDecimal(valores[11]),
                            Anio = valores[12].ToString(),
                            Marca = valores[13].ToString(),
                            Modelo = valores[14].ToString(),
                            Color = valores[15].ToString(),
                            Interior = valores[16].ToString(),
                            NumeroVendedor = valores[17].ToString(),
                            NombreVendedor = valores[18].ToString(),
                            FechaCompra = Convert.ToDateTime(valores[19]),
                            NombreCliente = valores[21].ToString(),
                            Rfc = valores[22].ToString(),
                            Direccion = valores[23].ToString(),
                            Telefono = valores[24].ToString(),
                            CodigoPostal = valores[25].ToString(),
                            Email = valores[26].ToString(),
                            IdOrigen = 1
                        });
                    }
                    posicion++;
                }
                new W32Data().W32InsertarUnidad(unidadList,idCompania);
            }
            catch (Exception expection)
            {

            }
        }
        public void GuardarVentaUnidadUsado(string[] contenidoArchivo, int idCompania, int idSucursal)
        {
            int posicion = 0;
            Console.WriteLine("Inicio proceso GuardarVentaUnidadUsado : " + idCompania );
            List<UnidadDTO> unidadList = new List<UnidadDTO>();
            try
            {
                foreach (var linea in contenidoArchivo)
                {
                    if (posicion > 1)
                    {
                        string[] valores = linea.Split('|');
                        unidadList.Add(new UnidadDTO
                        {
                            IdCompania = idCompania,
                            IdSucursal = idSucursal,
                            Cantidad = Convert.ToDecimal(valores[8].Replace(".", ",")) > 0 ? 1 : -1,
                            Factura = valores[1].ToString(),
                            FechaFactura = Convert.ToDateTime(valores[2]),
                            TipoVenta = valores[3].ToString(),
                            TipoPago = valores[4].ToString(),
                            SerieNumero = valores[5].ToString(),
                            NumeroInventario = valores[6].ToString(),
                            Isan = this.ConvertirStringToDecimal(valores[7]),
                            Costo = this.ConvertirStringToDecimal(valores[8]),
                            Venta = this.ConvertirStringToDecimal(valores[9]),
                            Utilidad = this.ConvertirStringToDecimal(valores[10]),
                            Margen = this.ConvertirStringToDecimal(valores[11]),
                            Anio = valores[12].ToString(),
                            Marca = valores[13].ToString(),
                            Modelo = valores[14].ToString(),
                            Color = valores[15].ToString(),
                            Interior = valores[16].ToString(),
                            NumeroVendedor = valores[17].ToString(),
                            NombreVendedor = valores[18].ToString(),
                            FechaCompra = Convert.ToDateTime(valores[19]),
                            NombreCliente = valores[21].ToString(),
                            Rfc = valores[22].ToString(),
                            Direccion = valores[23].ToString(),
                            Telefono = valores[24].ToString(),
                            CodigoPostal = valores[25].ToString(),
                            Email = valores[26].ToString(),
                            IdOrigen = 2
                        });
                    }
                    posicion++;
                }
                new W32Data().W32InsertarUnidadUsado(unidadList, idCompania);
            }
            catch (Exception expection)
            {
                Console.WriteLine("Error : " + expection);
            }
        }
        public void GuardarInventarioUnidad(string[] contenidoArchivo,int idCompania, int idSucursal)
        {
            Console.WriteLine("Inicio proceso GuardarInventarioUnidad : " + idCompania);
            int posicion = 0;
            DateTime fechaRegistro = Convert.ToDateTime(contenidoArchivo[1]);
            List<UnidadInventarioDTO> unidadList = new List<UnidadInventarioDTO>();
            try
            {
                foreach (var linea in contenidoArchivo)
                {
                    if (posicion > 1)
                    {
                        string[] valores = linea.Split('|');
                        unidadList.Add(new UnidadInventarioDTO
                        {
                            IdCompania = idCompania,
                            IdSucursal = idSucursal,
                            FechaHistorico = fechaRegistro,
                            SerieNumero = valores[1].ToString(),
                            NumeroInventario = valores[2].ToString(),
                            Anio = Convert.ToInt32(valores[3]),
                            Marca = valores[4].ToString(),
                            Modelo = valores[5].ToString(),
                            VersionUnidad = valores[6].ToString(),
                            Color = valores[7].ToString(),
                            Interior = valores[8].ToString(),
                            Costo = this.ConvertirStringToDecimal(valores[9]),
                            FechaAlta = Convert.ToDateTime(valores[10]),
                            Estatus = valores[11].ToString(),
                            TipoCompra = valores[12].ToString()
                        });
                    }
                    posicion++;
                }
                new W32Data().W32InsertarInventario(unidadList, idCompania);
            }
            catch (Exception expection)
            {

            }
        }
        public void GuardarInventarioUnidadUsado(string[] contenidoArchivo, int idCompania, int idSucursal)
        {
            Console.WriteLine("Inicio proceso GuardarInventarioUnidadUsado : " + idCompania);
            int posicion = 0;
            DateTime fechaRegistro = Convert.ToDateTime(contenidoArchivo[1]);
            List<UnidadInventarioDTO> unidadList = new List<UnidadInventarioDTO>();
            try
            {
                foreach (var linea in contenidoArchivo)
                {
                    if (posicion > 1)
                    {
                        string[] valores = linea.Split('|');
                        unidadList.Add(new UnidadInventarioDTO
                        {
                            IdCompania = idCompania,
                            IdSucursal = idSucursal,
                            FechaHistorico = fechaRegistro,
                            SerieNumero = valores[1].ToString(),
                            NumeroInventario = valores[2].ToString(),
                            Anio = Convert.ToInt32(valores[3]),
                            Marca = valores[4].ToString(),
                            Modelo = valores[5].ToString(),
                            VersionUnidad = valores[6].ToString(),
                            Color = valores[7].ToString(),
                            Interior = valores[8].ToString(),
                            Costo = this.ConvertirStringToDecimal(valores[9]),
                            FechaAlta = Convert.ToDateTime(valores[10]),
                            Estatus = valores[11].ToString(),
                            TipoCompra = valores[12].ToString(),
                            IdOrigen = 2,
                        });
                    }
                    posicion++;
                }
                new W32Data().W32InsertarInventarioUsado(unidadList, idCompania);
            }
            catch (Exception expection)
            {

            }
        }
        public void GuardarInventarioServicio(string[] contenidoArchivo, int idCompania, int idSucursal, int idOrigen)
        {
            try
            {
                Console.WriteLine("Inicio proceso GuardarInventarioServicio : " + idCompania);
                int posicion = 0;
                DateTime fechaRegistro = Convert.ToDateTime(contenidoArchivo[1]);
                List<ServiciosDTO> unidadList = new List<ServiciosDTO>();
            
                foreach (var linea in contenidoArchivo)
                {
                    if (posicion > 1)
                    {
                        string[] valores = linea.Split('|');
                        unidadList.Add(new ServiciosDTO
                        {
                            IdCompania =            idCompania,
                            IdSucursal =            idSucursal,
                            FechaHistorico =        fechaRegistro,
                            Factura =               valores[1].ToString(),
                            FechaFactura =          Convert.ToDateTime(valores[2]),
                            NumeroOT =              valores[3].ToString(),
                            FechaApertura =         Convert.ToDateTime(valores[4]),
                            FechaEntrega =          Convert.ToDateTime(valores[5]),
                            CodigoOperacion =       valores[6].ToString(),
                            Descripcion =           valores[7].ToString(),
                            CostoTOT =              this.ConvertirStringToDecimal(valores[10]),
                            CostoTotal =            this.ConvertirStringToDecimal(valores[20]),
                            VentaMO =               this.ConvertirStringToDecimal(valores[12]),
                            VentaMateriales =       this.ConvertirStringToDecimal(valores[13]),
                            VentaTOT =              this.ConvertirStringToDecimal(valores[14]),
                            VentaPartes =           this.ConvertirStringToDecimal(valores[15]),
                            DescuentoMO =           this.ConvertirStringToDecimal(valores[16]),
                            CostoPartes =           this.ConvertirStringToDecimal(valores[11]),
                            VentaTotal =            this.ConvertirStringToDecimal(valores[21]),
                            DescuentoMateriales =   this.ConvertirStringToDecimal(valores[17]),
                            DescuentoPartes =       this.ConvertirStringToDecimal(valores[19]),
                            Taller =                valores[24].ToString(),
                            NumeroAsesor =          valores[25].ToString(),
                            NombreAsesor =          valores[26].ToString(),
                            NombreCliente =         valores[27].ToString(),
                            RFC =                   valores[28].ToString(),
                            Direccion =             valores[29].ToString(),
                            Telefono =              valores[30].ToString(),
                            CP =                    valores[31].ToString(),
                            Email =                 valores[32].ToString(),
                            Odometro =              valores[33].ToString(),
                            vin =                   valores[34].ToString(),
                            Anio =                  valores[35].ToString(),
                            Marca =                 valores[36].ToString(),
                            Modelo =                valores[37].ToString(),
                            Color =                 valores[38].ToString(),
                            TipoOrden =             valores[40].ToString(),
                            TipoPago =              valores[41].ToString(),
                            idOrigen =              idOrigen,
                        });
                    }
                    posicion++;
                }
                new W32Data().W32InsertarServicios(unidadList, idCompania);
            }
            catch (Exception expection)
            {
                Console.WriteLine(expection);
            }
        }
        public void GuardarInventarioSEROEP(string[] contenidoArchivo, int idCompania, int idSucursal, int idOrigen)
        {
            Console.WriteLine("Inicio proceso GuardarInventarioSEROEP : " + idCompania);
            int posicion = 0;
            DateTime fechaRegistro = Convert.ToDateTime(contenidoArchivo[1]);
            List<SEROEPDTO> unidadList = new List<SEROEPDTO>();
            try
            {
                foreach (var linea in contenidoArchivo)
                {
                    if (posicion > 1)
                    {
                        string[] valores = linea.Split('|');
                        unidadList.Add(new SEROEPDTO
                        {
                            IdCompania = idCompania,
                            IdSucursal = idSucursal,
                            FechaHistorico = fechaRegistro,
                            NumeroOT = valores[1].ToString(),
                            FechaApertura = Convert.ToDateTime(valores[2]),
                            Vin = valores[3].ToString(),
                            Dias = Convert.ToInt32(valores[4]),
                            Costo = this.ConvertirStringToDecimal(valores[5]),
                            Venta = this.ConvertirStringToDecimal(valores[6]),
                            TipoOrden = valores[7].ToString(),
                            Taller = valores[8].ToString(),
                            NumeroAsesor = valores[9].ToString(),
                            NombreAsesor = valores[10].ToString(),
                            NombreCliente = valores[11].ToString(),
                            Direccion = valores[12].ToString(),
                            Telefono = valores[13].ToString(),
                            CP = valores[14].ToString(),
                            idOrigen = idOrigen,
                        });
                    }
                    posicion++;
                }
                new W32Data().W32InsertarSEROEP(unidadList, idCompania);
            }
            catch (Exception expection)
            {
                Console.WriteLine(expection);
            }
        }
        public void GuardarInventarioREFVTA(string[] contenidoArchivo, int idCompania, int idSucursal, int idOrigen)
        {
            Console.WriteLine("Inicio proceso GuardarInventarioREFVTA : " + idCompania);
            int posicion = 0;
            DateTime fechaRegistro = Convert.ToDateTime(contenidoArchivo[1]);
            List<REFVTA> unidadList = new List<REFVTA>();
            try
            {
                foreach (var linea in contenidoArchivo)
                {
                    if (posicion > 1)
                    {
                        string[] valores = linea.Split('|');
                        unidadList.Add(new REFVTA
                        {
                            IdCompania = idCompania,
                            IdSucursal = idSucursal,
                            FechaHistorico = fechaRegistro,
                            Factura = valores[1].ToString(),
                            FechaFactura = Convert.ToDateTime(valores[2]),
                            NumeroParte = valores[3].ToString(),
                            Cantidad =  this.ConvertirStringToDecimal(valores[4]),
                            CostoUnit = this.ConvertirStringToDecimal(valores[5]),
                            Costo =     this.ConvertirStringToDecimal(valores[6]),
                            VentaUnit = this.ConvertirStringToDecimal(valores[7]),
                            Venta =     this.ConvertirStringToDecimal(valores[8]),
                            NombreCliente = valores[13].ToString(),
                            RFC = valores[14].ToString(),
                            TipoParte = valores[21].ToString(),
                            TipoOrden = valores[19].ToString(),
                            TipoVenta = "Mostrador",
                            idOrigen = idOrigen,
                        });
                    }
                    posicion++;
                }
                new W32Data().W32InsertarREFVTA(unidadList, idCompania);
            }
            catch (Exception expection)
            {
                Console.WriteLine(expection);
            }
        }
        public void GuardarInventarioREFSER(string[] contenidoArchivo, int idCompania, int idSucursal, int idOrigen)
        {
            Console.WriteLine("Inicio proceso GuardarInventarioREFSER : " + idCompania);
            int posicion = 0;
            DateTime fechaRegistro = Convert.ToDateTime(contenidoArchivo[1]);
            List<REFVTA> unidadList = new List<REFVTA>();
            try
            {
                foreach (var linea in contenidoArchivo)
                {
                    if (posicion > 1)
                    {
                        string[] valores = linea.Split('|');
                        unidadList.Add(new REFVTA
                        {
                            IdCompania = idCompania,
                            IdSucursal = idSucursal,
                            FechaHistorico = fechaRegistro,
                            Factura = valores[1].ToString(),
                            FechaFactura = Convert.ToDateTime(valores[2]),
                            NumeroOT = valores[3].ToString(),
                            NumeroParte = valores[4].ToString(),
                            Descripcion = valores[5].ToString(),
                            Cantidad = this.ConvertirStringToDecimal(valores[6]),
                            CostoUnit = this.ConvertirStringToDecimal(valores[7]),
                            Costo = this.ConvertirStringToDecimal(valores[8]),
                            VentaUnit = this.ConvertirStringToDecimal(valores[9]),
                            Venta = this.ConvertirStringToDecimal(valores[10]),
                            TipoOrden = valores[13].ToString(),
                            TipoVenta = valores[14].ToString(),
                            RFC = valores[15].ToString(),
                            idOrigen = idOrigen,
                        });
                    }
                    posicion++;
                }
                new W32Data().W32InsertarREFSER(unidadList, idCompania);
            }
            catch (Exception expection)
            {
                Console.WriteLine(expection);
            }
        }
        public void GuardarInventarioREFINV(string[] contenidoArchivo, int idCompania, int idSucursal)
        {
            Console.WriteLine("Inicio proceso GuardarInventarioREFINV : " + idCompania);
            int posicion = 0;
            DateTime fechaRegistro = Convert.ToDateTime(contenidoArchivo[1]);
            List<REFINV> unidadList = new List<REFINV>();
            try
            {
                foreach (var linea in contenidoArchivo)
                {
                    if (posicion > 1)
                    {
                        string[] valores = linea.Split('|');
                        unidadList.Add(new REFINV
                        {
                            IdCompania = idCompania,
                            IdSucursal = idSucursal,
                            FechaHistorico = fechaRegistro,
                            NumeroParte = valores[1].ToString(),
                            Descripcion = valores[2].ToString(),
                            Almacen = valores[3].ToString(),
                            Existencia = this.ConvertirStringToDecimal(valores[4]),
                            CostoUnit = this.ConvertirStringToDecimal(valores[5]),
                            Costo =     this.ConvertirStringToDecimal(valores[6]),
                            Precio =    this.ConvertirStringToDecimal(valores[7]),
                            Precio2 =   this.ConvertirStringToDecimal(valores[8]),
                            Precio3 =   this.ConvertirStringToDecimal(valores[9]),
                            Precio4 =   this.ConvertirStringToDecimal(valores[10]),
                            Precio5 =   this.ConvertirStringToDecimal(valores[11]),
                            UltimaCompra = valores[12].ToString(),
                            UltimaVenta = valores[13].ToString(),
                            FechaAlta = valores[14].ToString(),
                            TipoParte = valores[15].ToString(),
                            Clasificacion = valores[16].ToString(),
                            idOrigen = 1,
                        });
                    }
                    posicion++;
                }
                new W32Data().W32InsertarREFINV(unidadList, idCompania);
            }
            catch (Exception expection)
            {
                Console.WriteLine(expection);
            }
        }
        
        public decimal ConvertirStringToDecimal(string valor)
        {

            if (valor.Length==0){
                valor = "0";
            }
            if (valor.Equals("Principal"))
            {
                valor = "1";
            }
            string[] str = valor.Split('.');
            string strDecimal;
            string valorFinal = valor;
            if (str.Count() > 1)
            {
                if (str[1].Length > 5)
                {
                    strDecimal = str[1].Substring(0, 5);
                    valorFinal = str[0] + '.' + strDecimal;
                }
                else
                {
                    valorFinal = valor;
                }
            }
            else
            {
                valorFinal = valor;
            }
            valorFinal = valorFinal.Replace(".", ",");
            decimal d = Convert.ToDecimal(valorFinal);
            d = Math.Floor(100 * d) / 100;
            string s = d.ToString("N2");
            decimal final = Convert.ToDecimal(s);
            return final;
        }
    }
}

