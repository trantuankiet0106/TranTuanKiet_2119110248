using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranTuanKiet_2119110248.DTO;

namespace TranTuanKiet_2119110248.DAO
{
    public class DepartmentDAO:Dbconnection
    {
        public List<DepartmentDTO> ReadAreaList()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("selectDepartment", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            List<DepartmentDTO> lstCus = new List<DepartmentDTO>();
            while (reader.Read())
            {
                DepartmentDTO cus = new DepartmentDTO();
                cus.ID = reader["ID"].ToString();    
                cus.NAME = reader["NAME"].ToString();
                lstCus.Add(cus);
            }
            conn.Close();
            return lstCus;
        }
        public DepartmentDTO ReadArea(string ID)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(
                "select * from Department where ID= " +"'" +ID.ToString()+"'", conn);
            DepartmentDTO area = new DepartmentDTO();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows && reader.Read())
            {
                area.ID =reader["ID"].ToString();
                area.NAME = reader["NAME"].ToString();
            }
            conn.Close();
            return area;
        }

    }
}
