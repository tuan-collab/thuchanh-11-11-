using System;
using System.Collections.Generic;
using HRMManagement.DAL;
using HRMManagement.DTO;

namespace HRMManagement.BUS
{
    public class NhanVienBUS
    {
        private NhanVienDAL dal = new NhanVienDAL();

        public List<NhanVienDTO> Search(string keyword, int? maPB) => dal.Search(keyword, maPB);

        public bool Insert(NhanVienDTO nv)
        {
            if (string.IsNullOrWhiteSpace(nv.HoTen))
                throw new Exception("Họ tên nhân viên không được để trống!");
            if (string.IsNullOrWhiteSpace(nv.CCCD))
                throw new Exception("Số CCCD không được để trống!");
            if (nv.LuongCoBan <= 0)
                throw new Exception("Lương cơ bản phải lớn hơn 0!");

            return dal.Insert(nv);
        }

        public bool Update(NhanVienDTO nv)
        {
            if (nv.MaNV <= 0)
                throw new Exception("Vui lòng chọn nhân viên cần cập nhật!");
            return dal.Update(nv);
        }

        public bool Delete(int maNV)
        {
            if (maNV <= 0)
                throw new Exception("Vui lòng chọn nhân viên cần xóa!");
            return dal.Delete(maNV);
        }
    }
}