﻿using FashionShopCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopBL.BaseBL
{
    public interface IBaseBL<T>
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
        public ServiceResponse GetRecordByID(int recordID);


        /// <summary>
        /// Xóa 1 bản ghi theo ID
        /// </summary>
        /// <param name="recordID">ID của bản ghi muốn xóa</param>
        /// <returns>ID của bản ghi đã bị xóa</returns>
        /// CreateBy: Nguyễn Quang Minh (12/11/2022)
        public ServiceResponse DeleteRecord(int recordID);

        /// <summary>
        /// Thêm mới một bản ghi
        /// </summary>
        /// <param name="record">Đối tượng cẩn thêm mới</param>
        /// <returns>ID của đối tượng vừa thêm mới</returns>
        /// CreatedBy: Nguyễn Quang Minh (25/11/2022)
        public ServiceResponse InsertRecord(T record);

        /// <summary>
        /// Sửa thông tin 1 bản ghi theo ID
        /// </summary>
        /// <param name="recordID">ID của bản ghi muốn sửa</param>
        /// <param name="record">Đối tượng bản ghi muốn sửa</param>
        /// <returns>ID của bản ghi đã sửa</returns>
        /// CreateBy: Nguyễn Quang Minh (12/11/2022)
        public ServiceResponse UpdateRecord(int recordID, T record);
    }
}
