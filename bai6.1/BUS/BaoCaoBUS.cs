using System;
using System.Collections.Generic;
using SalesManagement.DAL;

namespace SalesManagement.BUS
{
    public class BaoCaoBUS
    {
        private BaoCaoDAL dal = new BaoCaoDAL();

        public decimal TinhTongDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            return dal.TinhTongDoanhThu(tuNgay, denNgay);
        }

        public List<string> GetTop5SanPhamBanChay()
        {
            return dal.GetTop5SanPhamBanChay();
        }
    }
}