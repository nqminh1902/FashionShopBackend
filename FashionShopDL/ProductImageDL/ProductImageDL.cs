using Dapper;
using FashionShopCommon;
using FashionShopCommon.Entities;
using FashionShopDL.BaseDL;
using FashionShopDL.ProductDL;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace FashionShopDL.ProductImageDL
{
    public class ProductImageDL:BaseDL<ProductImage>, IProductImageDL
    {
        public ServiceResponse InsertProductImage(List<ProductImage> productImages)
        {
            if(productImages.Count > 0)
            {
                MySqlTransaction transaction = null;
                var parameter = new DynamicParameters();
                var insertValues = new List<string>();
                foreach (var image in productImages)
                {
                    insertValues.Add($"('{image.ImageUrl}', '{image.ImageID}', '{image.ImageThumbnail}', {image.ProductID}, '{image.CreatedBy}')");
                }

                if (insertValues.Count > 0)
                {
                    string sql = string.Join(",", insertValues);
                    parameter.Add("v_ProductImages", sql);
                }
                // Khời tạo kết nối tới DB MySQL
                using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
                {
                    mySqlConnection.Open();
                    try
                    {
                        transaction = mySqlConnection.BeginTransaction();
                        //Thực hiện gọi vào DB
                        var result = mySqlConnection.Execute("Proc_ProductImage_Insert", parameter, transaction: transaction, commandType: System.Data.CommandType.StoredProcedure);
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
                    Success = false,
                    Data = null
                };
            }
        }
    }
}
