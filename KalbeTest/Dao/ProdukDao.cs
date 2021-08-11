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
    public class ProdukDao
    { 
        private readonly IConfiguration _config;


    public ProdukDao(IConfiguration config)
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

    public IList<ProdukModel> GetAllData()
    {
        var data = new List<ProdukModel>();

        try
        {
            using (IDbConnection conn = Connection)
            {
                var param = new DynamicParameters();



                data = conn.Query<ProdukModel>(
                                           @"SELECT  [intProductId]
                                              ,[txtProductCode]
                                              ,[txtProductName]
                                              ,[intQuantity]
                                              ,[decPrice]
                                              ,[dtinserted]
                                          FROM [Produk]").ToList();



            }

        }
        catch (Exception ex)
        {

            throw ex;

        }
        return data;

    }


    public ProdukModel GetDataById(int SOId)
    {
        var data = new ProdukModel();

        try
        {
            using (IDbConnection conn = Connection)
            {
                var param = new DynamicParameters();



                data = conn.Query<ProdukModel>(
                                           @"SELECT  [intProductId]
                                              ,[txtProductCode]
                                              ,[txtProductName]
                                              ,[intQuantity]
                                              ,[decPrice]
                                              ,[dtinserted]
                                          FROM [Produk]where intProductId = @SOId", new
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


    public ProdukModel CreateProduk(ProdukModel model)
    {
        var data = new ProdukModel();

        try
        {
            using (IDbConnection conn = Connection)
            {




                data = conn.Query<ProdukModel>(
                                    @"INSERT INTO [dbo].[Produk]
                                           ([txtProductCode]
                                           ,[txtProductName]
                                           ,[intQuantity]
                                           ,[decPrice]
                                           ,[dtinserted])
                                     VALUES
                                           (@txtProductCode
                                           ,@txtProductName
                                           ,@intQuantity
                                           ,@decPrice
                                           ,GETDATE())
                                                    ", new
                                            {
                                        txtProductCode = model.txtProductCode,
                                        txtProductName = model.txtProductName,
                                        intQuantity = model.intQuantity,
                                        decPrice = model.decPrice,
                                            }).FirstOrDefault();



            }

        }
        catch (Exception ex)
        {

            throw ex;

        }
        return data;

    }

    public ProdukModel UpdateProduk(ProdukModel model)
    {
        var data = new ProdukModel();

        try
        {
            using (IDbConnection conn = Connection)
            {




                data = conn.Query<ProdukModel>(
                                            @"UPDATE [dbo].[Produk]
                                               SET [txtProductCode] = @txtProductCode
                                                  ,[txtProductName] = @txtProductName
                                                  ,[intQuantity] = @intQuantity
                                                  ,[decPrice] = @decPrice
                                                  ,[dtinserted] = GETDATE()
                                             WHERE intProductId = @intProductId
                                                    ", new
                                            {
                                                txtProductCode = model.txtProductCode,
                                                txtProductName = model.txtProductName,
                                                intQuantity = model.intQuantity,
                                                decPrice = model.decPrice,
                                                intProductId = model.intProductId
                                            }).FirstOrDefault();



            }

        }
        catch (Exception ex)
        {

            throw ex;

        }
        return data;

    }

    public void DeleteProduk(int SOId)
    {
        try
        {
            using (IDbConnection conn = Connection)
            {
                conn.Execute("delete from Produk where intProductId = @id",
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
