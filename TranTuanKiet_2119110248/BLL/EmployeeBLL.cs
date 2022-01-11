using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranTuanKiet_2119110248.DAO;
using TranTuanKiet_2119110248.DTO;

namespace TranTuanKiet_2119110248.BLL
{
public class EmployeeBLL
{
        EmployeeDAo dal = new EmployeeDAo();
        public List<EmployeeDTO> ReadCusTomer()
        {
            List<EmployeeDTO> lstCus = dal.ReadEmployee();
            return lstCus;
        }
        public void NewCustomer(EmployeeDTO cus)
        {
            dal.NewEmployee(cus);
        }
        public void DeleteCustomer(EmployeeDTO cus)
        {
            dal.DeleteEmployee(cus);
        }
        public void EditCustomer(EmployeeDTO cus)
        {
            dal.EditEmployee(cus);
        }
    }
}
