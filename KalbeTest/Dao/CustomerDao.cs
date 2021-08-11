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
    public class CustomerDao
    {

        private readonly IConfiguration _config;


        public CustomerDao(IConfiguration config)
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

        public IList<CustomerModel> GetAllData()
        {
            var data = new List<CustomerModel>();

            try
            {
                using (IDbConnection conn = Connection)
                {
                    var param = new DynamicParameters();



                    data = conn.Query<CustomerModel>(
                                               @"SELECT  [intCustomerId]
                                                  ,[txtCustomerName]
                                                  ,[txtCustAddress]
                                                  ,[bitGender]
                                                  ,[dtmBirthDate]
                                                  ,[dtminserted]
                                              FROM [Customer]").ToList();



                }

            }
            catch (Exception ex)
            {

                throw ex;

            }
            return data;

        }


        public CustomerModel GetDataById(int CustId)
        {
            var data = new CustomerModel();

            try
            {
                using (IDbConnection conn = Connection)
                {
                    var param = new DynamicParameters();



                    data = conn.Query<CustomerModel>(
                                               @"SELECT  [intCustomerId]
                                              ,[txtCustomerName]
                                              ,[txtCustAddress]
                                              ,[bitGender]
                                              ,[dtmBirthDate]
                                              ,[dtminserted]
                                          FROM [Customer] where [intCustomerId] = @intCustomerId", new
                                               {
                                                   intCustomerId = CustId
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


        public CustomerModel CreateCustomer(CustomerModel model)
        {
            var data = new CustomerModel();

            try
            {
                using (IDbConnection conn = Connection)
                {




                    data = conn.Query<CustomerModel>(
                                                @"INSERT INTO [dbo].[Customer]
                                                           ([txtCustomerName]
                                                           ,[txtCustAddress]
                                                           ,[bitGender]
                                                           ,[dtmBirthDate]
                                                           ,[dtminserted])
                                                     VALUES
                                                           (@txtCustomerName
                                                           ,@txtCustAddress
                                                           ,@bitGender
                                                           ,@dtmBirthDate
                                                           ,getdate())", new
                                                {
                                                    @txtCustomerName = model.txtCustomerName,
                                                    @txtCustAddress = model.txtCustAddress,
                                                    @bitGender = model.bitGender,
                                                    @dtmBirthDate = model.dtmBirthDate,
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

        public CustomerModel UpdateCustomer(CustomerModel model)
        {
            var data = new CustomerModel();

            try
            {
                using (IDbConnection conn = Connection)
                {




                    data = conn.Query<CustomerModel>(
                                                @"UPDATE [dbo].[Customer]
                                                   SET [txtCustomerName] = @txtCustomerName
                                                      ,[txtCustAddress] = @txtCustAddress
                                                      ,[bitGender] = @bitGender
                                                      ,[dtmBirthDate] = @dtmBirthDate
                                                      ,[dtminserted] = getdate()
                                                 WHERE  intCustomerId = @intCustomerId
                                                    ", new
                                                {
                                                    @txtCustomerName = model.txtCustomerName,
                                                    @txtCustAddress = model.txtCustAddress,
                                                    @bitGender = model.bitGender,
                                                   @dtmBirthDate = model.dtmBirthDate,
                                                    @intCustomerId = model.intCustomerId
                                                }).FirstOrDefault();



                }

            }
            catch (Exception ex)
            {

                throw ex;

            }
            return data;

        }

        public void DeleteCustomer(int Id)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Execute("delete from Customer where intCustomerId = @id",
                                new
                                {
                                    @id = Id
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

