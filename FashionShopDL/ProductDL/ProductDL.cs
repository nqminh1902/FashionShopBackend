using Dapper;
using FashionShopCommon;
using FashionShopCommon.Entities;
using FashionShopCommon.Entities.Attribute;
using FashionShopDL.BaseDL;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopDL.ProductDL
{
    public class ProductDL:BaseDL<Product>, IProductDL
    {
        public override ServiceResponse InsertRecord(Product record)
        {
            // Chuẩn bị câu lệnh sql
            string storeProcedureName = "Proc_Product_Insert";

            var parameters = new DynamicParameters();

            // Lấy rả các Prop của đối tượng
            var properties = record?.GetType().GetProperties();

            // Khởi tạo biến lưu giá trị
            object propValue;

            foreach (var prop in properties)
            {
                // LẤy ra attribute KeyAttribute
                var keyAtrribute = Attribute.GetCustomAttribute(prop, typeof(Key));
                var detailTableAtrribute = Attribute.GetCustomAttribute(prop, typeof(DetailTable));
                // Nếu có thì lưu id mới
                if (detailTableAtrribute != null)
                {
                    continue;
                }
                // Lưu giá trị của đối tượng
                else
                {
                    propValue = prop.GetValue(record);
                }

                // Chuyền vào parameter
                parameters.Add($"v_{prop.Name}", propValue);
            }
            // Khởi tạo kết nối tới DB MySQL
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                mySqlConnection.Open();
                // Bắt đầu transaction 
                var transaction = mySqlConnection.BeginTransaction();
                // Thực hiện gọi vào DB
                var result = mySqlConnection.QueryFirstOrDefault<int>(storeProcedureName, parameters, transaction, commandType: System.Data.CommandType.StoredProcedure);
                // return kết quả
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
                // Rollback về lại ban đầu
                else
                {
                    transaction.Rollback();
                    mySqlConnection.Close();
                    return new ServiceResponse()
                    {
                        Success = false,
                        Data = null
                    };
                }
            }
        }
    }
}
