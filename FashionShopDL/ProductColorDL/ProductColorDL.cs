using Dapper;
using FashionShopCommon;
using FashionShopCommon.Entities;
using FashionShopDL.BaseDL;
using FashionShopDL.ProductImageDL;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopDL.ProductColorDL
{
    public class ProductColorDL : BaseDL<ProductColor>, IProductColorDL
    {
        public override ServiceResponse InsertMultipleRecord(List<ProductColor> records)
        {
            if (records.Count > 0)
            {
                MySqlTransaction transaction = null;
                var parameter = new DynamicParameters();
                var insertValues = new List<string>();
                foreach (var color in records)
                {
                    insertValues.Add($"('{color.ProductColorName}', {color.ProductID}, '{color.CreatedBy}')");
                }

                if (insertValues.Count > 0)
                {
                    string sql = string.Join(",", insertValues);
                    parameter.Add("v_ProductColors", sql);
                }
                // Khời tạo kết nối tới DB MySQL
                using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
                {
                    mySqlConnection.Open();
                    try
                    {
                        transaction = mySqlConnection.BeginTransaction();
                        //Thực hiện gọi vào DB
                        var result = mySqlConnection.Execute("Proc_ProductColor_InsertMultiple", parameter, transaction: transaction, commandType: System.Data.CommandType.StoredProcedure);
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

        public ServiceResponse GetColorsByID(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add($"v_ProductID", id);


            // Khời tạo kết nối tới DB MySQL
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                // Thực hiên gọi vào DB
                var result = mySqlConnection.Query("Proc_ProductColor_GetColorByID", parameters, commandType: System.Data.CommandType.StoredProcedure);
                // Xử lý trả về

                // Thành công: Trả về dữ liệu cho FE
                if (result != null)
                {
                    return new ServiceResponse()
                    {
                        Data = result,
                        Success = true
                    };
                }
                return new ServiceResponse()
                {
                    Data = result,
                    Success = false
                };
            }
        }
    }
    
}
