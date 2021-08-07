﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Constant
{
    public static class Message
    {
        public static readonly string WARNING_ITEM_NOT_FOUND = "Không tìm thấy thông tin đang xử lý";

        public static class ToastMessage
        {
            public static readonly string TITLE_SUCCESS = "Thông báo";
            public static readonly string TITLE_WARNING = "Cảnh báo";
            public static readonly string TITLE_ERROR = "Lỗi";
            public static readonly string CREATE_SUCCESS = "Lưu dữ liệu thành công";
            public static readonly string CREATE_ERROR = "Lưu dữ liệu thất bại";
            public static readonly string UPDATE_SUCCESS = "Cập nhật dữ liệu thành công";
            public static readonly string UPDATE_ERROR = "Cập nhật dữ liệu thất bại";
            public static readonly string DELETE_SUCCESS = "Dữ liệu đã được xóa";
            public static readonly string DELETE_ERROR = "Lỗi khi xóa dữ liệu";
        }
    }
}
