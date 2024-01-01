using Dapper;
using FashionShopCommon;
using FashionShopCommon.Entities;
using FashionShopCommon.Entities.Attribute;
using FashionShopCommon.Entities.DTO;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopDL.BaseDL
{
    public class BaseDL<T> : IBaseDL<T>
    {
        // Rules: Khởi tạo muộn nhất có thể. Giải phóng sớm nhất có thể

        /// <summary>
        /// Lấy danh sách tất cả nhân viên
        /// </summary>
        /// <returns>Danh sách tất cả nhân viên</returns>
        /// CreatedBy: Nguyễn Quang Minh (11/11/2022)
        public ServiceResponse GetAllRecords()
        {
            // Chuẩn bị câu lệnh SQL
            string storeProcedureName = String.Format(Procedure.GET_ALL, typeof(T).Name);

            // Thực hiên gọi vào DB
            var records = new List<T>();

            // Khời tạo kết nối tới DB MySQL
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                records = (List<T>)mySqlConnection.Query<T>(storeProcedureName, commandType: System.Data.CommandType.StoredProcedure);

            }
            if(records.Count > 0)
            {
                return new ServiceResponse()
                {
                    Success = true,
                    Data = records
                };
            }
            return new ServiceResponse()
            {
                Success = false,
                Data = records
            }; ;

        }

        /// <summary>
        /// Lấy thông tin của 1 bản ghi theo ID
        /// </summary>
        /// <param name="recordID"> Id của bản ghi </param>
        /// <returns>Trả về thông tin của bản ghi</returns>
        /// CreatedBy: Nguyễn Quang Minh (11/11/2022)
        public virtual async Task<ServiceResponse> GetRecordByID(int recordID)
        {

            // Chuẩn bị câu lệnh SQL
            string storeProcedureName = String.Format(Procedure.GET_BY_ID, typeof(T).Name);

            var parameters = new DynamicParameters();
            parameters.Add($"v_{typeof(T).Name}ID", recordID);


            // Khời tạo kết nối tới DB MySQL
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                // Thực hiên gọi vào DB
                var record = await mySqlConnection.QueryFirstOrDefaultAsync<T>(storeProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                // Xử lý trả về

                // Thành công: Trả về dữ liệu cho FE
                if(record != null)
                {
                    return new ServiceResponse()
                    {
                        Data = record,
                        Success = true
                    };
                }
                return new ServiceResponse()
                {
                    Data = record,
                    Success = false
                };
            }

        }

        /// <summary>
        /// Lấy mã bản ghi để kiểm tra có bị trùng không
        /// </summary>
        /// <param name="recordCode"> Mã của bản ghi</param>
        /// <returns>Trả về true or false</returns>
        public async Task<bool> CheckCodeExist(string recordCode, T record)
        {
            // Chuẩn bị câu lệnh SQL
            string storeProcedureName = String.Format(Procedure.GET_CODE_BY_CODE, typeof(T).Name);

            // Chuẩn bị tham số đầu vào
            var parameters = new DynamicParameters();

            parameters.Add($"v_{typeof(T).Name}Code", recordCode);

            // Khời tạo kết nối tới DB MySQL
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                //Thực hiện gọi vào DB
                var code = await mySqlConnection.QueryFirstOrDefaultAsync(storeProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

                if (code != null)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Xóa 1 bản ghi theo ID
        /// </summary>
        /// <param name="recordID">ID của bản ghi muốn xóa</param>
        /// <returns>ID của bản ghi đã bị xóa</returns>
        /// CreateBy: Nguyễn Quang Minh (12/11/2022)
        public async Task<ServiceResponse> DeleteRecord(int recordID)
        {

            // Chuẩn bị câu lệnh SQL
            string storeProcedureName = String.Format(Procedure.DELETE, typeof(T).Name);

            var parameters = new DynamicParameters();
            parameters.Add($"v_{typeof(T).Name}ID", recordID);

            // Khời tạo kết nối tới DB MySQL
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                var numberOfRowsAffected = await mySqlConnection.ExecuteAsync(storeProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                //Thành công: Trả về Id nhân viên thêm thành công
                if (numberOfRowsAffected > 0)
                {
                    return new ServiceResponse()
                    {
                        Success = true,
                        Data = recordID
                    };
                }
                return new ServiceResponse()
                {
                    Success = false,
                    Data = recordID
                };

            }

        }

        /// <summary>
        /// Xóa hàng loạt bản ghi theo ID
        /// </summary>
        /// <param name="">Danh sách ID</param>
        /// <returns>Danh sách ID xóa thành công</returns>
        /// CreateBy: Nguyễn Quang Minh (15/11/2022)
        public virtual async Task<ServiceResponse> DeleteMultiple(List<int> ids)
        {

            MySqlTransaction transaction = null;

            var str = string.Join("','", ids);

            //Chuẩn bị câu lệnh SQL
            string sql = $" DELETE FROM {typeof(T).Name.ToLower()} WHERE {typeof(T).Name}ID IN ('{str}');";

            int numberOfRowsAffected = 0;

            // Khời tạo kết nối tới DB MySQL
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                mySqlConnection.Open();
                try
                {
                    transaction = mySqlConnection.BeginTransaction();
                    //Thực hiện gọi vào DB
                    numberOfRowsAffected = await mySqlConnection.ExecuteAsync(sql, transaction: transaction);
                    if (numberOfRowsAffected == ids.Count)
                    {
                        transaction.Commit();

                    }
                    else
                    {

                        transaction.Rollback();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
                finally
                {
                    mySqlConnection.Close();
                }
            }
            //Xử lý kết quả trả về

            //Thành công: Trả về Id nhân viên thêm thành công
            if (numberOfRowsAffected > 0)
            {
                return new ServiceResponse()
                {
                    Success = true,
                    Data = ids
                };
            }
            return new ServiceResponse()
            {
                Success = false,
                Data = ids
            };
        }

        /// <summary>
        /// Thêm mới một bản ghi
        /// </summary>
        /// <param name="record">Đối tượng cẩn thêm mới</param>
        /// <returns>ID của đối tượng vừa thêm mới</returns>
        /// CreatedBy: Nguyễn Quang Minh (25/11/2022)
        public virtual async Task<ServiceResponse> InsertRecord(T record)
        {
            // Chuẩn bị câu lệnh sql
            string storeProcedureName = String.Format(Procedure.INSERT_RECORD, typeof(T).Name);

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
                if (keyAtrribute != null)
                {
                    continue;
                }
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
                var result = await mySqlConnection.QueryFirstOrDefaultAsync<int>(storeProcedureName, parameters, transaction, commandType: System.Data.CommandType.StoredProcedure);
                // return kết quả
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

        /// <summary>
        /// Thêm nhiều bản ghi
        /// </summary>
        /// <param name="records"></param>
        /// <returns></returns>
        public virtual async Task<ServiceResponse> InsertMultipleRecord(List<T> records)
        {
            foreach (var item in records)
            {
                var res = await InsertRecord(item);
                if(res == null)
                {
                    return new ServiceResponse()
                    {
                        Success = false,
                        Data = null
                    };
                }
            }
            return new ServiceResponse()
            {
                Success = true,
                Data = records
            };
        }

        /// <summary>
        /// Cập nhật nhiều bản ghi
        /// </summary>
        /// <param name="records"></param>
        /// <returns></returns>
        public virtual ServiceResponse UpdateMultipleRecord(List<T> records)
        {
            return new ServiceResponse()
            {
                Success = false,
                Data = null
            };
        }

        /// <summary>
        /// Sửa thông tin 1 bản ghi theo ID
        /// </summary>
        /// <param name="recordID">ID của bản ghi muốn sửa</param>
        /// <param name="record">Đối tượng bản ghi muốn sửa</param>
        /// <returns>ID của bản ghi đã sửa</returns>
        /// CreateBy: Nguyễn Quang Minh (12/11/2022)
        public virtual async Task<ServiceResponse> UpdateRecord(int recordID, T record)
        {
            // Chuẩn bị câu lệnh sql
            string storeProcedureName = String.Format(Procedure.UPDATE_RECORD, typeof(T).Name);

            var parameters = new DynamicParameters();

            // Lấy rả các Prop của đối tượng
            var properties = record?.GetType().GetProperties();

            // Khởi tạo biến lưu giá trị
            object propValue;

            foreach (var prop in properties)
            {
                var detailTableAtrribute = Attribute.GetCustomAttribute(prop, typeof(DetailTable));
                var cancelUpdateAtrribute = Attribute.GetCustomAttribute(prop, typeof(CancelUpdate)); 
                // Nếu có thì lưu id mới
                if (detailTableAtrribute != null)
                {
                    continue;
                }
                if (cancelUpdateAtrribute != null)
                {
                    continue;
                }
                else
                {
                    // Lưu giá trị của đối tượng
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
                var result = await mySqlConnection.ExecuteAsync(storeProcedureName, parameters, transaction, commandType: System.Data.CommandType.StoredProcedure);
                if (result > 0)
                {
                    transaction.Commit();
                    mySqlConnection.Close();
                    return new ServiceResponse()
                    {
                        Success = true,
                        Data = record
                    };
                }
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

        /// <summary>
        /// Hàm lấy bàn ghi theo tìm kiếm và phân trang
        /// </summary>
        /// <param name="pagingRequest"></param>
        /// <returns></returns>
        public virtual async Task<PagingResult> GetPaging(DynamicParameters parameter)
        {
            //Chuẩn bị câu lệnh sql
            string storeProcedureName = String.Format(Procedure.GET_BY_FILTER_PAGING, typeof(T).Name);

            // Khời tạo kết nối tới DB MySQL
            using (var mysqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                var multipleResult = await mysqlConnection.QueryMultipleAsync(storeProcedureName, parameter, commandType: System.Data.CommandType.StoredProcedure);

                if (multipleResult != null)
                {
                    var listData = multipleResult.Read<T>().ToList();
                    var totalCount = multipleResult.Read<long>().Single();
                    return new PagingResult()
                    {
                        Data = listData,
                        TotalCount = totalCount,
                    };
                }
            }
            return new PagingResult();
        }
    }
}
