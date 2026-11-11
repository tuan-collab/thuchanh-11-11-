using System.Collections.Generic;
using HRMManagement.DAL;
using HRMManagement.DTO;

namespace HRMManagement.BUS
{
    public class PhongBanBUS
    {
        private PhongBanDAL dal = new PhongBanDAL();
        public List<PhongBanDTO> GetAll() => dal.GetAll();
    }
}