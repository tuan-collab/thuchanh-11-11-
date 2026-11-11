using System;
using System.Collections.Generic;
using SalesManagement.DAL;
using SalesManagement.DTO;

namespace SalesManagement.BUS
{
    public class HoaDonBUS
    {
        private HoaDonDAL dal = new HoaDonDAL();

        public int ThanhToan(HoaDonDTO hd, List<ChiTietHoaDonDTO> listCT)
        {
            if (listCT == null || listCT.Count == 0)
                throw new Exception("Giỏ hàng đang trống! Vui lòng chọn sản phẩm.");
            if (hd.MaNV <= 0)
                throw new Exception("Vui lòng chọn nhân viên lập hóa đơn.");

            return dal.ThanhToan(hd, listCT);
        }
    }
}