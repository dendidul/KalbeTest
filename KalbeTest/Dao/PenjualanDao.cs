using Dapper;
using KalbeTest.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace KalbeTest.Dao
{
    public class PenjualanDao
    {

        private readonly IConfiguration _config;


        public PenjualanDao(IConfiguration config)
        {

            this._config = config;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DbConnection"));
            }
        }

        public IList<PenjualanModel> GetAllData()
        {
            var data = new List<PenjualanModel>();

            try
            {
                using (IDbConnection conn = Connection)
                {
                    var param = new DynamicParameters();



                    data = conn.Query<PenjualanModel>(
                                               @"
                                                    SELECT [intSalesOrderID]
                                                          ,[intCustomerID]
                                                          ,[intProductID]
                                                          ,[dtSalesOrder]
                                                          ,[intQty]
	                                                      ,txtCustomerName,txtProductName

                                                      FROM Penjualan p 
                                                      outer apply
                                                      (
	                                                    select txtCustomerName from Customer c where p.[intCustomerID] = c.intCustomerId
                                                      )x
                                                      outer apply
                                                      (
	                                                    select txtProductName from Produk pr where p.[intProductID] = pr.intProductId
                                                      )zi
                                                    ").ToList();



                }

            }
            catch (Exception ex)
            {

                throw ex;

            }
            return data;

        }


        public PenjualanModel GetDataById(int SOId)
        {
            var data = new PenjualanModel();

            try
            {
                using (IDbConnection conn = Connection)
                {
                    var param = new DynamicParameters();



                    data = conn.Query<PenjualanModel>(
                                               @"SELECT [intSalesOrderID]
                                                  ,[intCustomerID]
                                                  ,[intProductID]
                                                  ,[dtSalesOrder]
                                                  ,[intQty]
                                              FROM [Penjualan] where intSalesOrderID = @SOId", new
                                               {
                                                   @SOId = SOId
                                               }
                                               ).FirstOrDefault();



                }

            }
            catch (Exception ex)
            {

                throw ex;

            }
            return data;

        }


        public PenjualanModel CreatePenjualan(PenjualanModel model)
        {
            var data = new PenjualanModel();

            try
            {
                using (IDbConnection conn = Connection)
                {




                    data = conn.Query<PenjualanModel>(
                                                @"INSERT INTO [dbo].[Penjualan]
                                                           ([intCustomerID]
                                                           ,[intProductID]
                                                           ,[dtSalesOrder]
                                                           ,[intQty])
                                                     VALUES
                                                           (@intCustomerID
                                                           ,@intProductID
                                                           ,@dtSalesOrder
                                                           ,@intQty)
                                                    ", new
                                                {
                                                    @intCustomerID = model.intCustomerID,
                                                    @intProductID = model.intProductID,
                                                    @dtSalesOrder = model.dtSalesOrder,
                                                    @intQty = model.intQty,
                                                }).FirstOrDefault();



                }

            }
            catch (Exception ex)
            {

                throw ex;

            }
            return data;

        }

        public PenjualanModel UpdatePenjualan(PenjualanModel model)
        {
            var data = new PenjualanModel();

            try
            {
                using (IDbConnection conn = Connection)
                {




                    data = conn.Query<PenjualanModel>(
                                                @"UPDATE [dbo].[Penjualan]
                                                   SET [intCustomerID] = @intCustomerID
                                                      ,[intProductID] = @intProductID
                                                      ,[dtSalesOrder] = @dtSalesOrder
                                                      ,[intQty] = @intQty
                                                 WHERE intSalesOrderID = @intSalesOrderID 
                                                    ", new
                                                {
                                                    @intCustomerID = model.intCustomerID,
                                                    @intProductID = model.intProductID,
                                                    @dtSalesOrder = model.dtSalesOrder,
                                                    @intQty = model.intQty,
                                                    @intSalesOrderID = model.intSalesOrderID
                                                }).FirstOrDefault();



                }

            }
            catch (Exception ex)
            {

                throw ex;

            }
            return data;

        }

        public void DeletePenjualan(int SOId)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Execute("delete from Penjualan where intSalesOrderID = @id",
                                new
                                {
                                    @id = SOId
                                });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }



    }
}
