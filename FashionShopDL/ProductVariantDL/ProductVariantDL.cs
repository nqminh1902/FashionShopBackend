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
using System.Windows.Markup;

namespace FashionShopDL.ProductVariantDL
{
    public class ProductVariantDL:BaseDL<ProductVariant>, IProductVariantDL
    {
        public ServiceResponse InsertMultipleProductVariant(int productId, List<ProductVariant> productVariants)
        {
            if(productId > 0 && productVariants.Count > 0)
            {
                MySqlTransaction transaction = null;
                var parameter = new DynamicParameters();
                List<string> listVariantInsert = new List<string>();
                for (int i = 0; i < productVariants.Count; i++)
                {
                    parameter.Add($"@ProductID{i}", productId);
                    parameter.Add($"@ProductColorID{i}", productVariants[i].ProductColorID);
                    parameter.Add($"@ProductSizeID{i}", productVariants[i].ProductSizeID);
                    parameter.Add($"@Quantity{i}", productVariants[i].Quantity);
                    listVariantInsert.Add($"(@ProductID{i}, @ProductSizeID{i}, @ProductColorID{i}, @Quantity{i}, NOW(), NOW(), 'Nguyễn Quang Minh')");
                }

                string sql = string.Format("INSERT INTO product_variant (ProductID, ProductSizeID, ProductColorID, Quantity, ModifiedDate, CreatedDate, CreatedBy) VALUES {0};", string.Join(", ", listVariantInsert));
                
                // Khời tạo kết nối tới DB MySQL
                using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
                {
                    mySqlConnection.Open();
                    try
                    {
                        transaction = mySqlConnection.BeginTransaction();
                        //Thực hiện gọi vào DB
                        var result = mySqlConnection.Execute(sql, parameter, transaction: transaction);
                        if (result > 0)
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
