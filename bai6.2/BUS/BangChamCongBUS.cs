using System;
using System.Data;
using HRMManagement.DAL;

namespace HRMManagement.BUS
{
    public class BangChamCongBUS
    {
        private BangChamCongDAL dal = new BangChamCongDAL();

        public DataTable GetBangChamCongByThang(string thangNam)
        {
            if (string.IsNullOrWhiteSpace(thangNam))
                throw new Exception("Vui lòng chọn Tháng/Năm chấm công!");
            return dal.GetBangChamCongByThang(thangNam);
        }

        public bool SaveChanges(DataTable dt)
        {
            return dal.SaveChanges(dt);
        }
    }
}