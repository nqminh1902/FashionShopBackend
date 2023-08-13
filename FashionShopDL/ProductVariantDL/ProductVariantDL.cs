using Dapper;
using FashionShopCommon;
using FashionShopCommon.Entities;
using FashionShopDL.BaseDL;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopDL.ProductVariantDL
{
    public class ProductVariantDL:BaseDL<ProductVariant>, IProductVariantDL
    {
        public ServiceResponse InsertMultipleProductVariant(int productId)
        {
            if(productId != null)
            {
                MySqlTransaction transaction = null;
                var parameter = new DynamicParameters();

                parameter.Add("v_productID", productId);
                
                // Khời tạo kết nối tới DB MySQL
                using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
                {
                    mySqlConnection.Open();
                    try
                    {
                        transaction = mySqlConnection.BeginTransaction();
                        //Thực hiện gọi vào DB
                        var result = mySqlConnection.Execute("Proc_ProductVariant_InsertMultiple", parameter, transaction: transaction, commandType: System.Data.CommandType.StoredProcedure);
                        if (result != null)
                        {
                            transaction.Commit();
                            mySqlConnection.Close();
                            return new ServiceResponse()
                            {
                                Success = true,
                                Data = result
                            };

                        }
                        else
                        {

                            transaction.Rollback();
                            return new ServiceResponse()
                            {
                                Success = false,
                                Data = null
                            };
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return new ServiceResponse()
                        {
                            Success = false,
                            Data = null
                        };
                    }
                }
            }
            else
            {
                return new ServiceResponse()
                {
                    Success = true,
                    Data = null
                };

            }
        }
    }
}
