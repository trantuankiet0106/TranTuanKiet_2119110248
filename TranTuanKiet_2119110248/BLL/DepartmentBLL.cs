using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranTuanKiet_2119110248.DAO;
using TranTuanKiet_2119110248.DTO;

namespace TranTuanKiet_2119110248.BLL
{
    public class DepartmentBLL
    {
        DepartmentDAO dal = new DepartmentDAO();
        public List<DepartmentDTO> ReadAreaList()
        {
            List<DepartmentDTO> lstArea = dal.ReadAreaList();
            return lstArea;
        }
    }
}
