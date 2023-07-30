using FashionShopCommon;
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
        public IEnumerable<T> GetAllRecords();

        /// <summary>
        /// Lấy thông tin của 1 bản ghi theo ID
        /// </summary>
        /// <param name="recordID"> Id của bản ghi </param>
        /// <returns>Trả về thông tin của bản ghi</returns>
        /// CreatedBy: Nguyễn Quang Minh (11/11/2022)
        public T GetRecordByID(Guid recordID);

        /// <summary>
        /// Lấy mã bản ghi để kiểm tra có bị trùng không
        /// </summary>
        /// <param name="recordCode"> Mã của bản ghi</param>
        /// <returns>Trả về true or false</returns>
        public bool CheckCodeExist(string recordCode, T record);

        /// <summary>
        /// Xóa 1 bản ghi theo ID
        /// </summary>
        /// <param name="recordID">ID của bản ghi muốn xóa</param>
        /// <returns>ID của bản ghi đã bị xóa</returns>
        /// CreateBy: Nguyễn Quang Minh (12/11/2022)
        public Guid DeleteRecord(Guid recordID);

        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="record">bản ghi</param>
        /// <returns>id</returns>
        public ServiceResponse InsertRecord(T record);

        /// <summary>
        /// Cập nhật bản ghi
        /// </summary>
        /// <param name="record">bản ghi</param>
        /// <returns>id</returns>
        public ServiceResponse UpdateRecord(Guid recordID, T record);
    }
}
