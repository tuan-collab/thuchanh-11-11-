using System;
using System.Collections.Generic;
using HRMManagement.DAL;
using HRMManagement.DTO;

namespace HRMManagement.BUS
{
    public class BangLuongBUS
    {
        private BangLuongDAL dal = new BangLuongDAL();

        public bool ChotLuongThang(string thangNam)
        {
            if (string.IsNullOrWhiteSpace(thangNam))
                throw new Exception("Vui lòng chọn Tháng/Năm cần chốt lương!");
            return dal.ChotLuongThang(thangNam);
        }

        public List<BangLuongDTO> GetBangLuongByThang(string thangNam)
        {
            return dal.GetBangLuongByThang(thangNam);
        }
    }
}