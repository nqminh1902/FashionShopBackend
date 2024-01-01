using Dapper;
using FashionShopCommon;
using FashionShopCommon.Entities.DTO;
using FashionShopCommon.ExtentionMethod;
using FashionShopDL.BaseDL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopBL.BaseBL
{
    public class BaseBL<T> : IBaseBL<T>

    {
        #region Field

        private IBaseDL<T> _baseDL;

        #endregion

        #region Constructor

        public BaseBL(IBaseDL<T> baseDL)
        {
            _baseDL = baseDL;
        }

        #endregion

        #region Method
        /// <summary>
        /// Lấy danh sách tất cả bản ghi
        /// </summary>
        /// <returns>Danh sách tất cả bản ghi</returns>
        /// CreatedBy: Nguyễn Quang Minh (11/11/2022)
        public ServiceResponse GetAllRecords()
        {
            var respose = _baseDL.GetAllRecords();
            return respose;
 
        }

        /// <summary>
        /// Lấy thông tin của 1 bản ghi theo ID
        /// </summary>
        /// <param name="recordID"> Id của bản ghi </param>
        /// <returns>Trả về thông tin của bản ghi</returns>
        /// CreatedBy: Nguyễn Quang Minh (11/11/2022)
        public virtual async Task<ServiceResponse> GetRecordByID(int recordID)
        {
            return await _baseDL.GetRecordByID(recordID);
        }


        /// <summary>
        /// Xóa 1 bản ghi theo ID
        /// </summary>
        /// <param name="recordID">ID của bản ghi muốn xóa</param>
        /// <returns>ID của bản ghi đã bị xóa</returns>
        /// CreateBy: Nguyễn Quang Minh (12/11/2022)
        public async Task<ServiceResponse> DeleteRecord(int recordID)
        {
            var response = await _baseDL.DeleteRecord(recordID);
            return response;
        }

        /// <summary>
        /// Xóa hàng loạt bản ghi theo ID
        /// </summary>
        /// <param name="">Danh sách ID</param>
        /// <returns>Danh sách ID xóa thành công</returns>
        /// CreateBy: Nguyễn Quang Minh (15/11/2022)
        public virtual async Task<ServiceResponse> DeleteMultiple(List<int> ids)
        {
            return await _baseDL.DeleteMultiple(ids);
        }

        /// <summary>
        /// Thêm mới một bản ghi
        /// </summary>
        /// <param name="record">Đối tượng cẩn thêm mới</param>
        /// <returns>ID của đối tượng vừa thêm mới</returns>
        /// CreatedBy: Nguyễn Quang Minh (25/11/2022)
        public virtual async Task<ServiceResponse> InsertRecord(T record)
        {
            // Thực hiện gọi làm thêm bản ghi và trả về kết quả
            var response = await _baseDL.InsertRecord(record);
            if(response.Success == true ) 
            {
                return new ServiceResponse()
                {
                    Success = true,
                    Data = record
                };
            }
            return new ServiceResponse()
            {
                Success = false,
                Data = null
            };
        }

        /// <summary>
        /// Thêm mới nhiều bản ghi
        /// </summary>
        /// <param name="record">Đối tượng cẩn thêm mới</param>
        /// <returns>ID của đối tượng vừa thêm mới</returns>
        /// CreatedBy: Nguyễn Quang Minh (25/11/2022)
        public virtual async Task<ServiceResponse> InsertMultipleRecord(List<T> records)
        {
            // Thực hiện gọi làm thêm bản ghi và trả về kết quả

            foreach (var record in records)
            {
                var response = await InsertRecord(record);
                if (!response.Success)
                {
                    return new ServiceResponse()
                    {
                        Success = false,
                        Data = records
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
        /// Sửa thông tin 1 bản ghi theo ID
        /// </summary>
        /// <param name="recordID">ID của bản ghi muốn sửa</param>
        /// <param name="record">Đối tượng bản ghi muốn sửa</param>
        /// <returns>ID của bản ghi đã sửa</returns>
        /// CreateBy: Nguyễn Quang Minh (12/11/2022)
        public virtual async Task<ServiceResponse> UpdateRecord(int recordID, T record)
        {
            // Thực hiện gọi hàm sửa bản ghi và trả về kết quả
           var response = await _baseDL.UpdateRecord(recordID, record);
            if (response.Success == true )
            {
                return new ServiceResponse()
                {
                    Success = true,
                    Data = record
                };
            }
            return new ServiceResponse()
            {
                Success = false,
                Data = null
            };
        }


        /// <summary>
        /// Lấy ra bản ghi theo tìm kiếm và phân trang
        /// </summary>
        /// <param name="pagingRequest"></param>
        /// <returns></returns>
        public virtual async Task<ServiceResponse> GetPaging(PagingRequest pagingRequest)
        {
            var param = BuildWhereParameter(pagingRequest);
            var pagingResult = await _baseDL.GetPaging(param);
            if (pagingResult.TotalCount > 0)
            {
                return new ServiceResponse()
                {
                    Success = true,
                    Data = pagingResult
                };
            }
            return new ServiceResponse()
            {
                Success = false,
                Data = pagingResult
            };
        }

        /// <summary>
        /// Build câu lệnh v_where để lọc bản ghi 
        /// </summary>
        /// <param name="pagingRequest"></param>
        /// <returns></returns>
        public DynamicParameters BuildWhereParameter(PagingRequest pagingRequest)
        {
            // Chuẩn bị tham số đầu vào
            var parameters = new DynamicParameters();
            var andCondition = new List<string>();
            var lstSearchCondition = new List<string>();
            // Kiểm tra xem có searchValue không
            if (!string.IsNullOrEmpty(pagingRequest.SearchValue?.Trim()))
            {
                // Kiểm tra xem có cột cần tìm kiếm không
                if (pagingRequest.Collums?.Count > 0)
                {
                    foreach (var column in pagingRequest.Collums)
                    {
                        lstSearchCondition.Add($"{column} LIKE '%{pagingRequest.SearchValue}%'");
                    }
                }
            }
            // build câu lệnh tìm kiếm
            if (lstSearchCondition.Count > 0)
            {
                andCondition.Add($"{string.Join(" OR ", lstSearchCondition)}");
            }

            // Kiểm tra xem có bộ lọc tìm kiếm tùy chỉnh không
            if (!string.IsNullOrEmpty(pagingRequest.CustomFilter)) 
            {
                string decodedString = Base64Decode(pagingRequest.CustomFilter);
                var filterArray = JsonConvert.DeserializeObject<List<List<string>>>(decodedString);
                var customFilter = new List<string>();
                if(filterArray != null)
                {
                    foreach (var filter in filterArray)
                    {
                        customFilter.Add(string.Join(" ", filter));
                    }
                    //build câu lệnh tìm kiếm tùy chỉnh
                    andCondition.Add($"{string.Join(" AND ", customFilter)}");
                }
            }

            string sordCondition = ""; 

            // Kiểm tra xem có lọc theo điều kiện gì không
            if(pagingRequest.SortOrder?.Count > 0)
            {
                List<string> sordList = new List<string>();
                foreach (var column in pagingRequest.SortOrder)
                {
                    sordList.Add(column);
                }
                sordCondition += $" ORDER BY {string.Join(", ", sordList)}";
            }
            else 
            {
                sordCondition +=  $" ORDER BY ModifiedDate DESC";
            }

            // Build Câu lệnh Limit offset
            if (pagingRequest?.PageSize > 0)
            {
                sordCondition += $" LIMIT {pagingRequest.PageSize}";
            }

            if (pagingRequest?.PageIndex > 0)
            {
                sordCondition += $" OFFSET {(pagingRequest.PageIndex - 1) * pagingRequest.PageSize}";
            }


            // Build câu lệnh v_where
            if (andCondition.Count > 0)
            {
                var test = $" WHERE {string.Join(" AND ", andCondition)};";
                parameters.Add("v_where", $" WHERE {string.Join(" AND ", andCondition)}");
                parameters.Add("v_paging", $" {sordCondition};");
            }
            else
            {
                parameters.Add("v_where", "");
                parameters.Add("v_paging", $" {sordCondition};");
            }

            return parameters;
        }

        /// <summary>
        /// Convert chuỗi base64
        /// </summary>
        /// <param name="base64Encoded"></param>
        /// <returns></returns>
        static string Base64Decode(string base64Encoded)
        {
            byte[] data = Convert.FromBase64String(base64Encoded);
            return Encoding.UTF8.GetString(data);
        }
        #endregion

    }
}    

