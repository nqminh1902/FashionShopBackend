using Dapper;
using FashionShopCommon;
using FashionShopCommon.Entities;
using FashionShopCommon.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopDL.BaseDL
{
    public interface IBaseDL<T>
    {
        /// <summary>
        /// Lấy danh sách tất cả bản ghi
        /// </summary>
        /// <returns>Danh sách tất cả bản ghi</returns>
        /// CreatedBy: Nguyễn Quang Minh (11/11/2022)
        public ServiceResponse GetAllRecords();

        /// <summary>
        /// Lấy thông tin của 1 bản ghi theo ID
        /// </summary>
        /// <param name="recordID"> Id của bản ghi </param>
        /// <returns>Trả về thông tin của bản ghi</returns>
        /// CreatedBy: Nguyễn Quang Minh (11/11/2022)
        public Task<ServiceResponse> GetRecordByID(int recordID);

        /// <summary>
        /// Lấy mã bản ghi để kiểm tra có bị trùng không
        /// </summary>
        /// <param name="recordCode"> Mã của bản ghi</param>
        /// <returns>Trả về true or false</returns>
        public Task<bool> CheckCodeExist(string recordCode, T record);

        /// <summary>
        /// Xóa 1 bản ghi theo ID
        /// </summary>
        /// <param name="recordID">ID của bản ghi muốn xóa</param>
        /// <returns>ID của bản ghi đã bị xóa</returns>
        /// CreateBy: Nguyễn Quang Minh (12/11/2022)
        public Task<ServiceResponse> DeleteRecord(int recordID);

        /// <summary>
        /// Xóa nhiều bản ghi
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public Task<ServiceResponse> DeleteMultiple(List<int> ids);

        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="record">bản ghi</param>
        /// <returns>id</returns>
        public Task<ServiceResponse> InsertRecord(T record);

        /// <summary>
        /// Thêm mới nhieeyuf bản ghi
        /// </summary>
        /// <param name="records"></param>
        /// <returns></returns>
        public Task<ServiceResponse> InsertMultipleRecord(List<T> records);

        /// <summary>
        /// Cập nhật bản ghi
        /// </summary>
        /// <param name="record">bản ghi</param>
        /// <returns>id</returns>
        public Task<ServiceResponse> UpdateRecord(int recordID, T record);

        /// <summary>
        /// Lấy ra bản ghi theo tìm kiếm và phân trang
        /// </summary>
        /// <param name="pagingRequest"></param>
        /// <returns></returns>
        public Task<PagingResult> GetPaging(DynamicParameters parameter);
    }
}
