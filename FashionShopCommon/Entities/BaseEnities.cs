﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopCommon.Entities
{
    public class BaseEnities
    {
        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// Người tạo
        /// </summary>
        public string? CreateBy { get; set; }

        /// <summary>
        /// Thời gian chỉnh sửa gần nhất
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Người chỉnh sửa gần nhất
        /// </summary>
        public string? ModifiedBy { get; set; }
    }
}