using FTPDescargaArchivos.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Threading;

namespace FTPDescargaArchivos.Data
{
    public class W32Data
    {
        /// <summary>
        /// Registra la información del proveedor
        /// </summary>
        /// <returns>Un objeto de tipo ProveedorResponseDTO</returns>
        public int W32InsertarUnidad(List<UnidadDTO> unidadList,int idCompania)
        {
            int totales = 0;
                using (var conexion = new SqlConnection(Helper.Connection()))
                {
                    conexion.Open();
                    using (TransactionScope transactionScope = new TransactionScope())
                    {
                    try
                    {
                        var cont = 1;
                        foreach (var unidad in unidadList)
                        {
                            cont++;
                            var cmdUnidad = new SqlCommand("[Unidad].[InsertaUnidadW32]", conexion);
                            cmdUnidad.CommandType = CommandType.StoredProcedure;
                            cmdUnidad.Parameters.Add(new SqlParameter("@idCompania", unidad.IdCompania));
                            cmdUnidad.Parameters.Add(new SqlParameter("@idSucursal", unidad.IdSucursal));
                            cmdUnidad.Parameters.Add(new SqlParameter("@periodoYear", unidad.PeriodoYear));
                            cmdUnidad.Parameters.Add(new SqlParameter("@periodoMes", unidad.PeriodoMes));
                            cmdUnidad.Parameters.Add(new SqlParameter("@cantidad", unidad.Cantidad));
                            cmdUnidad.Parameters.Add(new SqlParameter("@factura", unidad.Factura));
                            cmdUnidad.Parameters.Add(new SqlParameter("@fechaFactura", unidad.FechaFactura));
                            cmdUnidad.Parameters.Add(new SqlParameter("@tipoVenta", unidad.TipoVenta));
                            cmdUnidad.Parameters.Add(new SqlParameter("@tipoPago", unidad.TipoPago));
                            cmdUnidad.Parameters.Add(new SqlParameter("@serieNumero", unidad.SerieNumero));
                            cmdUnidad.Parameters.Add(new SqlParameter("@numeroInventario", unidad.NumeroInventario));
                            cmdUnidad.Parameters.Add(new SqlParameter("@isan$", unidad.Isan));
                            cmdUnidad.Parameters.Add(new SqlParameter("@costo$", unidad.Costo));
                            cmdUnidad.Parameters.Add(new SqlParameter("@venta$", unidad.Venta));
                            cmdUnidad.Parameters.Add(new SqlParameter("@utilidad$", unidad.Utilidad));
                            cmdUnidad.Parameters.Add(new SqlParameter("@margen$", unidad.Margen));
                            cmdUnidad.Parameters.Add(new SqlParameter("@anio", unidad.Anio));
                            cmdUnidad.Parameters.Add(new SqlParameter("@marca", unidad.Marca));
                            cmdUnidad.Parameters.Add(new SqlParameter("@modelo", unidad.Modelo));
                            cmdUnidad.Parameters.Add(new SqlParameter("@color", unidad.Color));
                            cmdUnidad.Parameters.Add(new SqlParameter("@interior", unidad.Interior));
                            cmdUnidad.Parameters.Add(new SqlParameter("@numeroVendedor", unidad.NumeroVendedor));
                            cmdUnidad.Parameters.Add(new SqlParameter("@NombreVendedor", unidad.NombreVendedor));
                            cmdUnidad.Parameters.Add(new SqlParameter("@fechaCompra", unidad.FechaCompra));
                            cmdUnidad.Parameters.Add(new SqlParameter("@nombreCliente", unidad.NombreCliente));
                            cmdUnidad.Parameters.Add(new SqlParameter("@rfc", unidad.Rfc));
                            cmdUnidad.Parameters.Add(new SqlParameter("@direccion", unidad.Direccion));
                            cmdUnidad.Parameters.Add(new SqlParameter("@telefono", unidad.Telefono));
                            cmdUnidad.Parameters.Add(new SqlParameter("@codigoPostal", unidad.CodigoPostal));
                            cmdUnidad.Parameters.Add(new SqlParameter("@email", unidad.Email));
                            //cmdUnidad.Parameters.Add(new SqlParameter("Result", SqlDbType.BigInt) { Direction = ParameterDirection.ReturnValue });
                            //cmdUnidad.ExecuteNonQuery();
                            var result = Convert.ToInt32(cmdUnidad.ExecuteScalar());//Convert.ToInt32(cmdUnidad.Parameters["Result"].Value);
                            if(result < 0)
                            {
                                transactionScope.Dispose();
                                conexion.Close();
                                return 0;
                            }
                            totales++;
                        }
                        Console.WriteLine("Cantidad : " + totales);
                        Console.WriteLine("Total art : " + unidadList.Count());
                        transactionScope.Complete();
                        transactionScope.Dispose();
                        this.sendEstatusImport("Venta Unidad", true, idCompania);

                    }
                    catch (Exception exception)
                    {
                        this.sendEstatusImport("Venta Unidad", false, idCompania);
                        Console.WriteLine("Error : " + exception);
                    }
                    finally
                    {
                        conexion.Close();
                    }
                }
            }
            
            return 1;
        }
        /// <summary>
        /// Registra la información del proveedor
        /// </summary>
        /// <returns>Un objeto de tipo ProveedorResponseDTO</returns>
        public int W32InsertarUnidadUsado(List<UnidadDTO> unidadList, int idCompania)
        {

            int totales = 0;
            using (var conexion = new SqlConnection(Helper.Connection()))
            {
                Console.WriteLine("Entra aca : ");
                conexion.Open();
                using (TransactionScope transactionScope = new TransactionScope())
                {
                    try
                    {
                        foreach (var unidad in unidadList)
                        {
                            var cmdUnidad = new SqlCommand("[Unidad].[InsertaUnidadUsadoW32]", conexion);
                            cmdUnidad.CommandType = CommandType.StoredProcedure;
                            cmdUnidad.Parameters.Add(new SqlParameter("@idCompania", unidad.IdCompania));
                            cmdUnidad.Parameters.Add(new SqlParameter("@idSucursal", unidad.IdSucursal));
                            cmdUnidad.Parameters.Add(new SqlParameter("@periodoYear", unidad.PeriodoYear));
                            cmdUnidad.Parameters.Add(new SqlParameter("@periodoMes", unidad.PeriodoMes));
                            cmdUnidad.Parameters.Add(new SqlParameter("@cantidad", unidad.Cantidad));
                            cmdUnidad.Parameters.Add(new SqlParameter("@factura", unidad.Factura));
                            cmdUnidad.Parameters.Add(new SqlParameter("@fechaFactura", unidad.FechaFactura));
                            cmdUnidad.Parameters.Add(new SqlParameter("@tipoVenta", unidad.TipoVenta));
                            cmdUnidad.Parameters.Add(new SqlParameter("@tipoPago", unidad.TipoPago));
                            cmdUnidad.Parameters.Add(new SqlParameter("@serieNumero", unidad.SerieNumero));
                            cmdUnidad.Parameters.Add(new SqlParameter("@numeroInventario", unidad.NumeroInventario));
                            cmdUnidad.Parameters.Add(new SqlParameter("@isan$", unidad.Isan));
                            cmdUnidad.Parameters.Add(new SqlParameter("@costo$", unidad.Costo));
                            cmdUnidad.Parameters.Add(new SqlParameter("@venta$", unidad.Venta));
                            cmdUnidad.Parameters.Add(new SqlParameter("@utilidad$", unidad.Utilidad));
                            cmdUnidad.Parameters.Add(new SqlParameter("@margen$", unidad.Margen));
                            cmdUnidad.Parameters.Add(new SqlParameter("@anio", unidad.Anio));
                            cmdUnidad.Parameters.Add(new SqlParameter("@marca", unidad.Marca));
                            cmdUnidad.Parameters.Add(new SqlParameter("@modelo", unidad.Modelo));
                            cmdUnidad.Parameters.Add(new SqlParameter("@color", unidad.Color));
                            cmdUnidad.Parameters.Add(new SqlParameter("@interior", unidad.Interior));
                            cmdUnidad.Parameters.Add(new SqlParameter("@numeroVendedor", unidad.NumeroVendedor));
                            cmdUnidad.Parameters.Add(new SqlParameter("@NombreVendedor", unidad.NombreVendedor));
                            cmdUnidad.Parameters.Add(new SqlParameter("@fechaCompra", unidad.FechaCompra));
                            cmdUnidad.Parameters.Add(new SqlParameter("@nombreCliente", unidad.NombreCliente));
                            cmdUnidad.Parameters.Add(new SqlParameter("@rfc", unidad.Rfc));
                            cmdUnidad.Parameters.Add(new SqlParameter("@direccion", unidad.Direccion));
                            cmdUnidad.Parameters.Add(new SqlParameter("@telefono", unidad.Telefono));
                            cmdUnidad.Parameters.Add(new SqlParameter("@codigoPostal", unidad.CodigoPostal));
                            cmdUnidad.Parameters.Add(new SqlParameter("@email", unidad.Email));
                            cmdUnidad.Parameters.Add(new SqlParameter("@idOrigen", unidad.IdOrigen));

                            //cmdUnidad.Parameters.Add(new SqlParameter("Result", SqlDbType.BigInt) { Direction = ParameterDirection.ReturnValue });
                            //cmdUnidad.ExecuteNonQuery();
                            var result = Convert.ToInt32(cmdUnidad.ExecuteScalar());//Convert.ToInt32(cmdUnidad.Parameters["Result"].Value);
                            if (result < 0)
                            {
                                transactionScope.Dispose();
                                conexion.Close();
                                return 0;
                            }
                            totales++;
                        }
                        Console.WriteLine("Cantidad : " + totales);
                        Console.WriteLine("Total art : " + unidadList.Count());
                        this.sendEstatusImport("Venta Unidad Usado", true, idCompania);
                        transactionScope.Complete();
                        transactionScope.Dispose();

                    }
                    catch (Exception exception)
                    {
                        this.sendEstatusImport("Venta Unidad Usado", false, idCompania);
                        Console.WriteLine("Error : " + exception);
                    }
                    finally
                    {
                        conexion.Close();
                    }
                }
            }

            return 1;
        }

        /// <summary>
        /// Registra la información del proveedor
        /// </summary>
        /// <returns>Un objeto de tipo ProveedorResponseDTO</returns>
        public int W32InsertarInventario(List<UnidadInventarioDTO> unidadList, int idCompania)
        {
            int totales = 0;
            using (var conexion = new SqlConnection(Helper.Connection()))
            {
                conexion.Open();
                using (TransactionScope transactionScope = new TransactionScope())
                {
                    try
                    {
                        if (unidadList.Count > 0)
                        {
                            var cmdReinicio = new SqlCommand("[Unidad].[ReiniciaInventarioW32]", conexion);
                            cmdReinicio.CommandType = CommandType.StoredProcedure;
                            cmdReinicio.Parameters.Add(new SqlParameter("@idCompania", unidadList[0].IdCompania));
                            cmdReinicio.Parameters.Add(new SqlParameter("@idSucursal", unidadList[0].IdSucursal));
                            cmdReinicio.Parameters.Add(new SqlParameter("@fechaHistorico", unidadList[0].FechaHistorico));
                            cmdReinicio.Parameters.Add(new SqlParameter("@idOrigen", 1));
                            var result = Convert.ToInt32(cmdReinicio.ExecuteScalar());
                        }

                        foreach (var unidad in unidadList)
                        {
                            Console.WriteLine("Intent : "+ unidad.FechaHistorico);
                            var cmdUnidad = new SqlCommand("[Unidad].[InsertaInventarioW32]", conexion);
                            cmdUnidad.CommandType = CommandType.StoredProcedure;
                            cmdUnidad.Parameters.Add(new SqlParameter("@idCompania", unidad.IdCompania));
                            cmdUnidad.Parameters.Add(new SqlParameter("@idSucursal", unidad.IdSucursal));
                            cmdUnidad.Parameters.Add(new SqlParameter("@fechaHistorico", unidad.FechaHistorico));
                            cmdUnidad.Parameters.Add(new SqlParameter("@serieNumero", unidad.SerieNumero));
                            cmdUnidad.Parameters.Add(new SqlParameter("@numeroInventario", unidad.NumeroInventario));
                            cmdUnidad.Parameters.Add(new SqlParameter("@anio", unidad.Anio));
                            cmdUnidad.Parameters.Add(new SqlParameter("@marca", unidad.Marca));
                            cmdUnidad.Parameters.Add(new SqlParameter("@modelo", unidad.Modelo));
                            cmdUnidad.Parameters.Add(new SqlParameter("@versionUnidad", unidad.VersionUnidad));
                            cmdUnidad.Parameters.Add(new SqlParameter("@color", unidad.Color));
                            cmdUnidad.Parameters.Add(new SqlParameter("@interior", unidad.Interior));
                            cmdUnidad.Parameters.Add(new SqlParameter("@costo", unidad.Costo));
                            cmdUnidad.Parameters.Add(new SqlParameter("@fechaAlta", unidad.FechaAlta));
                            cmdUnidad.Parameters.Add(new SqlParameter("@estatus", unidad.Estatus));
                            cmdUnidad.Parameters.Add(new SqlParameter("@tipoCompra", unidad.TipoCompra));

                            //cmdUnidad.Parameters.Add(new SqlParameter("Result", SqlDbType.BigInt) { Direction = ParameterDirection.ReturnValue });
                            //cmdUnidad.ExecuteNonQuery();
                            var result = Convert.ToInt32(cmdUnidad.ExecuteScalar());//Convert.ToInt32(cmdUnidad.Parameters["Result"].Value);
                            if (result < 0)
                            {
                                transactionScope.Dispose();
                                conexion.Close();
                                return 0;
                            }
                            totales++;
                        }
                        Console.WriteLine("Cantidad : " + totales);
                        Console.WriteLine("Total art : " + unidadList.Count());
                        transactionScope.Complete();
                        transactionScope.Dispose();
                        this.sendEstatusImport("Inventario Nuevos", true, idCompania);

                    }
                    catch (Exception exception)
                    {
                        this.sendEstatusImport("Inventario Nuevos", false, idCompania);
                        Console.WriteLine("Error : " + exception);
                    }
                    finally
                    {
                        conexion.Close();
                    }
                }
            }

            return 1;
        }
        /// <summary>
        /// Registra la información del proveedor
        /// </summary>
        /// <returns>Un objeto de tipo ProveedorResponseDTO</returns>
        public int W32InsertarInventarioUsado(List<UnidadInventarioDTO> unidadList, int idCompania)
        {
            int totales = 0;
            using (var conexion = new SqlConnection(Helper.Connection()))
            {
                conexion.Open();
                using (TransactionScope transactionScope = new TransactionScope())
                {
                    try
                    {
                        if (unidadList.Count > 0)
                        {
                            var cmdReinicio = new SqlCommand("[Unidad].[ReiniciaInventarioW32]", conexion);
                            cmdReinicio.CommandType = CommandType.StoredProcedure;
                            cmdReinicio.Parameters.Add(new SqlParameter("@idCompania", unidadList[0].IdCompania));
                            cmdReinicio.Parameters.Add(new SqlParameter("@idSucursal", unidadList[0].IdSucursal));
                            cmdReinicio.Parameters.Add(new SqlParameter("@fechaHistorico", unidadList[0].FechaHistorico));
                            cmdReinicio.Parameters.Add(new SqlParameter("@idOrigen", unidadList[0].IdOrigen));
                            var result = Convert.ToInt32(cmdReinicio.ExecuteScalar());
                        }
                       
                        foreach (var unidad in unidadList)
                        {
                            var cmdUnidad = new SqlCommand("[Unidad].[InsertaInventarioUsadoW32]", conexion);
                            cmdUnidad.CommandType = CommandType.StoredProcedure;
                            cmdUnidad.Parameters.Add(new SqlParameter("@idCompania", unidad.IdCompania));
                            cmdUnidad.Parameters.Add(new SqlParameter("@idSucursal", unidad.IdSucursal));
                            cmdUnidad.Parameters.Add(new SqlParameter("@fechaHistorico", unidad.FechaHistorico));
                            cmdUnidad.Parameters.Add(new SqlParameter("@serieNumero", unidad.SerieNumero));
                            cmdUnidad.Parameters.Add(new SqlParameter("@numeroInventario", unidad.NumeroInventario));
                            cmdUnidad.Parameters.Add(new SqlParameter("@anio", unidad.Anio));
                            cmdUnidad.Parameters.Add(new SqlParameter("@marca", unidad.Marca));
                            cmdUnidad.Parameters.Add(new SqlParameter("@modelo", unidad.Modelo));
                            cmdUnidad.Parameters.Add(new SqlParameter("@versionUnidad", unidad.VersionUnidad));
                            cmdUnidad.Parameters.Add(new SqlParameter("@color", unidad.Color));
                            cmdUnidad.Parameters.Add(new SqlParameter("@interior", unidad.Interior));
                            cmdUnidad.Parameters.Add(new SqlParameter("@costo", unidad.Costo));
                            cmdUnidad.Parameters.Add(new SqlParameter("@fechaAlta", unidad.FechaAlta));
                            cmdUnidad.Parameters.Add(new SqlParameter("@estatus", unidad.Estatus));
                            cmdUnidad.Parameters.Add(new SqlParameter("@tipoCompra", unidad.TipoCompra));
                            cmdUnidad.Parameters.Add(new SqlParameter("@idOrigen", unidad.IdOrigen));

                            
                            var result = Convert.ToInt32(cmdUnidad.ExecuteScalar());
                            if (result < 0)
                            {
                                transactionScope.Dispose();
                                conexion.Close();
                                return 0;
                            }
                            totales++;
                        }
                        Console.WriteLine("Cantidad : " + totales);
                        Console.WriteLine("Total art : " + unidadList.Count());
                        transactionScope.Complete();
                        transactionScope.Dispose();
                        this.sendEstatusImport("Inventario Usado", true, idCompania);

                    }
                    catch (Exception exception)
                    {
                        this.sendEstatusImport("Inventario Usado", false, idCompania);
                        Console.WriteLine("Error : " + exception);
                    }
                    finally
                    {
                        conexion.Close();
                    }
                }
            }

            return 1;
        }
        //*************************************
        public int W32InsertarServicios(List<ServiciosDTO> unidadList, int idCompania)
        {
            int totales = 0;
            var status = false;
            using (var conexion = new SqlConnection(Helper.Connection()))
            {
                conexion.Open();
                using (TransactionScope transactionScope = new TransactionScope())
                {
                    try
                    {
                        foreach (var unidad in unidadList)
                        {
                            var cmdUnidad = new SqlCommand("[LibroVenta].[InsertarServicioHyPW32]", conexion);
                            cmdUnidad.CommandType = CommandType.StoredProcedure;
                            cmdUnidad.Parameters.Add(new SqlParameter("@Factura", unidad.Factura));
                            cmdUnidad.Parameters.Add(new SqlParameter("@FechaFactura", unidad.FechaFactura));
                            cmdUnidad.Parameters.Add(new SqlParameter("@FechaHistorico", unidad.FechaHistorico));
                            cmdUnidad.Parameters.Add(new SqlParameter("@IdCompania", unidad.IdCompania));
                            cmdUnidad.Parameters.Add(new SqlParameter("@IdSucursal", unidad.IdSucursal));
                            cmdUnidad.Parameters.Add(new SqlParameter("@NumeroOT", unidad.NumeroOT));
                            cmdUnidad.Parameters.Add(new SqlParameter("@FechaApertura", unidad.FechaApertura));
                            cmdUnidad.Parameters.Add(new SqlParameter("@FechaEntrega", unidad.FechaEntrega));
                            cmdUnidad.Parameters.Add(new SqlParameter("@CodigoOperacion", unidad.CodigoOperacion));
                            cmdUnidad.Parameters.Add(new SqlParameter("@Descripcion", unidad.Descripcion));
                            cmdUnidad.Parameters.Add(new SqlParameter("@CostoTOT", unidad.CostoTOT));
                            cmdUnidad.Parameters.Add(new SqlParameter("@CostoTotal", unidad.CostoTotal));
                            cmdUnidad.Parameters.Add(new SqlParameter("@VentaMO", unidad.VentaMO));
                            cmdUnidad.Parameters.Add(new SqlParameter("@VentaMateriales", unidad.VentaMateriales));
                            cmdUnidad.Parameters.Add(new SqlParameter("@VentaTOT", unidad.VentaTOT));
                            cmdUnidad.Parameters.Add(new SqlParameter("@VentaPartes", unidad.VentaPartes));
                            cmdUnidad.Parameters.Add(new SqlParameter("@DescuentoMO", unidad.DescuentoMO));
                            cmdUnidad.Parameters.Add(new SqlParameter("@CostoPartes", unidad.CostoPartes));
                            cmdUnidad.Parameters.Add(new SqlParameter("@VentaTotal", unidad.VentaTotal));
                            cmdUnidad.Parameters.Add(new SqlParameter("@DescuentoPartes", unidad.DescuentoPartes));
                            cmdUnidad.Parameters.Add(new SqlParameter("@DescuentoMateriales", unidad.DescuentoMateriales));
                            cmdUnidad.Parameters.Add(new SqlParameter("@Taller", unidad.Taller));
                            cmdUnidad.Parameters.Add(new SqlParameter("@NumeroAsesor", unidad.NumeroAsesor));
                            cmdUnidad.Parameters.Add(new SqlParameter("@NombreAsesor", unidad.NombreAsesor));
                            cmdUnidad.Parameters.Add(new SqlParameter("@NombreCliente", unidad.NombreCliente));
                            cmdUnidad.Parameters.Add(new SqlParameter("@RFC", unidad.RFC));
                            cmdUnidad.Parameters.Add(new SqlParameter("@Direccion", unidad.Direccion));
                            cmdUnidad.Parameters.Add(new SqlParameter("@Telefono", unidad.Telefono));
                            cmdUnidad.Parameters.Add(new SqlParameter("@CP", unidad.CP));
                            cmdUnidad.Parameters.Add(new SqlParameter("@Email", unidad.Email));
                            cmdUnidad.Parameters.Add(new SqlParameter("@Odometro", unidad.Odometro));
                            cmdUnidad.Parameters.Add(new SqlParameter("@vin", unidad.vin));
                            cmdUnidad.Parameters.Add(new SqlParameter("@Anio", unidad.Anio));
                            cmdUnidad.Parameters.Add(new SqlParameter("@Marca", unidad.Marca));
                            cmdUnidad.Parameters.Add(new SqlParameter("@Modelo", unidad.Modelo));
                            cmdUnidad.Parameters.Add(new SqlParameter("@Color", unidad.Color));
                            cmdUnidad.Parameters.Add(new SqlParameter("@TipoOrden", unidad.TipoOrden));
                            cmdUnidad.Parameters.Add(new SqlParameter("@TipoPago", unidad.TipoPago));
                            cmdUnidad.Parameters.Add(new SqlParameter("@idOrigen", unidad.idOrigen));
                            var result = Convert.ToInt32(cmdUnidad.ExecuteScalar());
                            if (result < 0)
                            {
                                transactionScope.Dispose();
                                return 0;
                            }
                            totales++;
                        }
                        Console.WriteLine("Cantidad : " + totales);
                        Console.WriteLine("Total art : " + unidadList.Count());
                        transactionScope.Complete();
                        transactionScope.Dispose();
                        status = true;
                    }
                    catch (TransactionAbortedException exception)
                    {
                        if (totales == unidadList.Count())
                        {
                            status = true;
                        }
                        else
                        {
                            status = false;
                        }
                    }
                    catch (Exception exception)
                    {
                        status = false;
                        Console.WriteLine("Error : " + exception);
                    }
                    finally
                    {
                        conexion.Close();
                    }
                    this.sendEstatusImport("Servicio", status, idCompania);
                }
            }
            return 1;
        }
        public int W32InsertarSEROEP(List<SEROEPDTO> unidadList, int idCompania)
        {
            int totales = 0;
            var status = false;
            using (var conexion = new SqlConnection(Helper.Connection()))
            {
                conexion.Open();
                using (TransactionScope transactionScope = new TransactionScope())
                {
                    try
                    {
                        foreach (var unidad in unidadList)
                        {
                            var cmdUnidad = new SqlCommand("[LibroVenta].[InsertarOrdenesServicioHyPW32]", conexion);
                            cmdUnidad.CommandType = CommandType.StoredProcedure;
                            cmdUnidad.Parameters.Add(new SqlParameter("@IdCompania", unidad.IdCompania));
                            cmdUnidad.Parameters.Add(new SqlParameter("@IdSucursal", unidad.IdSucursal));
                            cmdUnidad.Parameters.Add(new SqlParameter("@FechaHistorico", unidad.FechaHistorico));
                            cmdUnidad.Parameters.Add(new SqlParameter("@NumeroOT", unidad.NumeroOT));
                            cmdUnidad.Parameters.Add(new SqlParameter("@FechaApertura", unidad.FechaApertura));
                            cmdUnidad.Parameters.Add(new SqlParameter("@Vin", unidad.Vin));
                            cmdUnidad.Parameters.Add(new SqlParameter("@Dias", unidad.Dias));
                            cmdUnidad.Parameters.Add(new SqlParameter("@Costo", unidad.Costo));
                            cmdUnidad.Parameters.Add(new SqlParameter("@Venta", unidad.Venta));
                            cmdUnidad.Parameters.Add(new SqlParameter("@TipoOrden", unidad.TipoOrden));
                            cmdUnidad.Parameters.Add(new SqlParameter("@Taller", unidad.Taller));
                            cmdUnidad.Parameters.Add(new SqlParameter("@NumeroAsesor", unidad.NumeroAsesor));
                            cmdUnidad.Parameters.Add(new SqlParameter("@NombreAsesor", unidad.NombreAsesor));
                            cmdUnidad.Parameters.Add(new SqlParameter("@NombreCliente", unidad.NombreCliente));
                            cmdUnidad.Parameters.Add(new SqlParameter("@Direccion", unidad.Direccion));
                            cmdUnidad.Parameters.Add(new SqlParameter("@Telefono", unidad.Telefono));
                            cmdUnidad.Parameters.Add(new SqlParameter("@CP", unidad.CP));
                            cmdUnidad.Parameters.Add(new SqlParameter("@idOrigen", unidad.idOrigen));
                            var result = Convert.ToInt32(cmdUnidad.ExecuteScalar());
                            if (result < 0)
                            {
                                transactionScope.Dispose();
                                conexion.Close();
                                return 0;
                            }
                            totales++;
                        }
                        Console.WriteLine("Cantidad : " + totales);
                        Console.WriteLine("Total art : " + unidadList.Count());
                        transactionScope.Complete();
                        transactionScope.Dispose();
                        status = true;
                    }
                    catch (TransactionAbortedException exception)
                    {
                        if (totales == unidadList.Count())
                        {
                            status = true;
                        }
                        else
                        {
                            status = false;
                        }
                    }
                    catch (Exception exception)
                    {
                        status = false;
                        Console.WriteLine("Error : " + exception);
                    }
                    finally
                    {
                        conexion.Close();
                    }
                    this.sendEstatusImport("Ordenes Servicio", status, idCompania);
                }
            }

            return 1;
        }
        public int W32InsertarREFVTA(List<REFVTA> unidadList, int idCompania)
        {
            int totales = 0;
            var status = false;
            using (var conexion = new SqlConnection(Helper.Connection()))
            {
                conexion.Open();
                using (TransactionScope transactionScope = new TransactionScope())
                {
                    try
                    {
                        foreach (var unidad in unidadList)
                        {
                            var cmdUnidad = new SqlCommand("[LibroVenta].[InsertarRefaccionesHyPW32]", conexion);
                            cmdUnidad.CommandType = CommandType.StoredProcedure;
                            cmdUnidad.Parameters.Add(new SqlParameter("@IdCompania", unidad.IdCompania));
                            cmdUnidad.Parameters.Add(new SqlParameter("@IdSucursal", unidad.IdSucursal));
                            cmdUnidad.Parameters.Add(new SqlParameter("@FechaHistorico", unidad.FechaHistorico));
                            cmdUnidad.Parameters.Add(new SqlParameter("@Factura", unidad.Factura));
                            cmdUnidad.Parameters.Add(new SqlParameter("@FechaFactura", unidad.FechaFactura));
                            cmdUnidad.Parameters.Add(new SqlParameter("@NumeroParte", unidad.NumeroParte));
                            cmdUnidad.Parameters.Add(new SqlParameter("@Cantidad", unidad.Cantidad));
                            cmdUnidad.Parameters.Add(new SqlParameter("@CostoUnit", unidad.CostoUnit));
                            cmdUnidad.Parameters.Add(new SqlParameter("@Costo", unidad.Costo));
                            cmdUnidad.Parameters.Add(new SqlParameter("@VentaUnit", unidad.VentaUnit));
                            cmdUnidad.Parameters.Add(new SqlParameter("@Venta", unidad.Venta));
                            cmdUnidad.Parameters.Add(new SqlParameter("@NombreCliente", unidad.NombreCliente));
                            cmdUnidad.Parameters.Add(new SqlParameter("@RFC", unidad.RFC));
                            cmdUnidad.Parameters.Add(new SqlParameter("@TipoParte", unidad.TipoParte));
                            cmdUnidad.Parameters.Add(new SqlParameter("@TipoOrden", unidad.TipoOrden));
                            cmdUnidad.Parameters.Add(new SqlParameter("@TipoVenta", unidad.TipoVenta));
                            cmdUnidad.Parameters.Add(new SqlParameter("@idOrigen", unidad.idOrigen));
                            var result = Convert.ToInt32(cmdUnidad.ExecuteScalar());
                            if (result < 0)
                            {
                                transactionScope.Dispose();
                                conexion.Close();
                                return 0;
                            }
                            totales++;
                        }
                        Console.WriteLine("Cantidad : " + totales);
                        Console.WriteLine("Total art : " + unidadList.Count());
                        transactionScope.Complete();
                        transactionScope.Dispose();
                        status = true;
                    }
                    catch (TransactionAbortedException exception)
                    {
                        if (totales == unidadList.Count())
                        {
                            status = true;
                        }
                        else
                        {
                            status = false;
                        }
                    }
                    catch (Exception exception)
                    {
                        status = false;
                        Console.WriteLine("Error : " + exception);
                    }
                    finally
                    {
                        conexion.Close();
                    }
                    this.sendEstatusImport("Venta Refacciones", status, idCompania);
                }
            }

            return 1;
        }
        public int W32InsertarREFSER(List<REFVTA> unidadList, int idCompania)
        {
            int totales = 0;
            var status = false;
            using (var conexion = new SqlConnection(Helper.Connection()))
            {
                conexion.Open();
                using (TransactionScope transactionScope = new TransactionScope())
                {
                    try
                    {
                        foreach (var unidad in unidadList)
                        {
                            var cmdUnidad = new SqlCommand("[LibroVenta].[InsertarRefaccionesServicioHyPW32]", conexion);
                            cmdUnidad.CommandType = CommandType.StoredProcedure;
                            cmdUnidad.Parameters.Add(new SqlParameter("@IdCompania", unidad.IdCompania));
                            cmdUnidad.Parameters.Add(new SqlParameter("@IdSucursal", unidad.IdSucursal));
                            cmdUnidad.Parameters.Add(new SqlParameter("@FechaHistorico", unidad.FechaHistorico));
                            cmdUnidad.Parameters.Add(new SqlParameter("@Factura", unidad.Factura));
                            cmdUnidad.Parameters.Add(new SqlParameter("@FechaFactura", unidad.FechaFactura));
                            cmdUnidad.Parameters.Add(new SqlParameter("@NumeroParte", unidad.NumeroParte));
                            cmdUnidad.Parameters.Add(new SqlParameter("@Cantidad", unidad.Cantidad));
                            cmdUnidad.Parameters.Add(new SqlParameter("@CostoUnit", unidad.CostoUnit));
                            cmdUnidad.Parameters.Add(new SqlParameter("@Costo", unidad.Costo));
                            cmdUnidad.Parameters.Add(new SqlParameter("@VentaUnit", unidad.VentaUnit));
                            cmdUnidad.Parameters.Add(new SqlParameter("@Venta", unidad.Venta));
                            cmdUnidad.Parameters.Add(new SqlParameter("@RFC", unidad.RFC));
                            cmdUnidad.Parameters.Add(new SqlParameter("@idOrigen", unidad.idOrigen));
                            cmdUnidad.Parameters.Add(new SqlParameter("@NumeroOT", unidad.NumeroOT));
                            cmdUnidad.Parameters.Add(new SqlParameter("@Descripcion", unidad.Descripcion));
                            cmdUnidad.Parameters.Add(new SqlParameter("@TipoVenta", unidad.TipoVenta));
                            cmdUnidad.Parameters.Add(new SqlParameter("@TipoOrden", unidad.TipoOrden));
                            var result = Convert.ToInt32(cmdUnidad.ExecuteScalar());
                            if (result < 0)
                            {
                                transactionScope.Dispose();
                                conexion.Close();
                                return 0;
                            }
                            totales++;
                        }
                        Console.WriteLine("Cantidad : " + totales);
                        Console.WriteLine("Total art : " + unidadList.Count());
                        transactionScope.Complete();
                        transactionScope.Dispose();
                        status = true;
                    }
                    catch (TransactionAbortedException exception)
                    {
                        if (totales == unidadList.Count())
                        {
                            status = true;
                        }
                        else
                        {
                            status = false;
                        }
                    }
                    catch (Exception exception)
                    {
                        status = false;
                        Console.WriteLine("Error : " + exception);
                    }
                    finally
                    {
                        conexion.Close();
                    }
                    this.sendEstatusImport("Servicio Refacciones", status, idCompania);
                }
            }

            return 1;
        }
        public int W32InsertarREFINV(List<REFINV> unidadList, int idCompania)
        {
            int totales = 0;
            var status = false;
            using (var conexion = new SqlConnection(Helper.Connection()))
            {
                conexion.Open();
                using (TransactionScope transactionScope = new TransactionScope())
                {
                    try
                    {
                        foreach (var unidad in unidadList)
                        {
                            var cmdUnidad = new SqlCommand("[LibroVenta].[InsertarRefaccionesInventarioHyPW32]", conexion);
                            cmdUnidad.CommandType = CommandType.StoredProcedure;
                            cmdUnidad.Parameters.Add(new SqlParameter("@IdCompania", unidad.IdCompania));
                            cmdUnidad.Parameters.Add(new SqlParameter("@IdSucursal", unidad.IdSucursal));
                            cmdUnidad.Parameters.Add(new SqlParameter("@FechaHistorico", unidad.FechaHistorico));
                            cmdUnidad.Parameters.Add(new SqlParameter("@NumeroParte", unidad.NumeroParte));
                            cmdUnidad.Parameters.Add(new SqlParameter("@Descripcion", unidad.Descripcion));
                            cmdUnidad.Parameters.Add(new SqlParameter("@Almacen", unidad.Almacen));
                            cmdUnidad.Parameters.Add(new SqlParameter("@Existencia", unidad.Existencia));
                            cmdUnidad.Parameters.Add(new SqlParameter("@CostoUnit", unidad.CostoUnit));
                            cmdUnidad.Parameters.Add(new SqlParameter("@Costo", unidad.Costo));
                            cmdUnidad.Parameters.Add(new SqlParameter("@Precio", unidad.Precio));
                            cmdUnidad.Parameters.Add(new SqlParameter("@Precio2", unidad.Precio2));
                            cmdUnidad.Parameters.Add(new SqlParameter("@Precio3", unidad.Precio3));
                            cmdUnidad.Parameters.Add(new SqlParameter("@Precio4", unidad.Precio4));
                            cmdUnidad.Parameters.Add(new SqlParameter("@Precio5", unidad.Precio5));
                            cmdUnidad.Parameters.Add(new SqlParameter("@UltimaCompra", unidad.UltimaCompra));
                            cmdUnidad.Parameters.Add(new SqlParameter("@UltimaVenta", unidad.UltimaVenta));
                            cmdUnidad.Parameters.Add(new SqlParameter("@FechaAlta", unidad.FechaAlta));
                            cmdUnidad.Parameters.Add(new SqlParameter("@TipoParte", unidad.TipoParte));
                            cmdUnidad.Parameters.Add(new SqlParameter("@Clasificacion", unidad.Clasificacion));
                            cmdUnidad.Parameters.Add(new SqlParameter("@idOrigen", unidad.idOrigen));
                            var result = Convert.ToInt32(cmdUnidad.ExecuteScalar());
                            totales++;
                        }
                        Console.WriteLine("Cantidad : " + totales);
                        Console.WriteLine("Total art : " + unidadList.Count());
                        transactionScope.Complete();
                        transactionScope.Dispose();
                        status = true;
                    }
                    catch (TransactionAbortedException exception)
                    {
                        if (totales == unidadList.Count())
                        {
                            status = true;
                        }
                        else
                        {
                            status = false;
                        }
                    }
                    catch (Exception exception)
                    {
                        status = false; 
                        Console.WriteLine("Error : " + exception);
                    }
                    finally
                    {
                        conexion.Close();
                    }
                    this.sendEstatusImport("Inventario Refacciones", status, idCompania);
                }
            }
            return 1;
        }
        public void sendEstatusImport(string proceso, bool status, int idcompania)
        {
            using (var conexion = new SqlConnection(Helper.Connection()))
            {
                conexion.Open();
                using (TransactionScope transactionScope = new TransactionScope())
                {
                    try
                    {
                        Console.WriteLine("Se ejecuto : " + proceso);
                        var cmdUnidad = new SqlCommand("[ImportarArchivos].[InsImportRegistros]", conexion);
                        cmdUnidad.CommandType = CommandType.StoredProcedure;
                        cmdUnidad.Parameters.Add(new SqlParameter("@Proceso", proceso));
                        cmdUnidad.Parameters.Add(new SqlParameter("@Estatus", status));
                        cmdUnidad.Parameters.Add(new SqlParameter("@idCompania", idcompania));
                        var result = Convert.ToInt32(cmdUnidad.ExecuteScalar());
                        if (result < 0)
                        {
                            transactionScope.Dispose();
                            conexion.Close();
                        }
                        transactionScope.Complete();
                        transactionScope.Dispose();
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine("Error");
                        Console.WriteLine(exception);

                    }
                    finally
                    {
                        conexion.Close();
                    }
                }
            }

        }
    }
}
