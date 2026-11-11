using System.Collections.Generic;
using SalesManagement.DAL;
using SalesManagement.DTO;

namespace SalesManagement.BUS
{
    public class NhanVienBUS
    {
        private NhanVienDAL dal = new NhanVienDAL();
        public List<NhanVienDTO> GetAll() => dal.GetAll();
    }
}