using System.Collections.Generic;
using SalesManagement.DAL;
using SalesManagement.DTO;

namespace SalesManagement.BUS
{
    public class SanPhamBUS
    {
        private SanPhamDAL dal = new SanPhamDAL();
        public List<SanPhamDTO> Search(string keyword) => dal.Search(keyword ?? "");
    }
}