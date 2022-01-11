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
   public class EmployeeDAo : Dbconnection 
    {
        public List<EmployeeDTO> ReadEmployee()
        {

            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("selectEmployee", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();



            List<EmployeeDTO> lstCus = new List<EmployeeDTO>();
            DepartmentDAO are = new DepartmentDAO();
            while (reader.Read())
            {
                EmployeeDTO cus = new EmployeeDTO();
                cus.IDME = int.Parse(reader["IDEM"].ToString());
                cus.NAME_EM = reader["NAME_EM"].ToString();
                cus.BIRTH = DateTime.Parse(reader["BIRTH"].ToString());
                cus.GT = reader["gt"].ToString();
                cus.NOISINH = reader["NOISINH"].ToString();
                cus.KV = are.ReadArea(reader["IDDEPART"].ToString());
                lstCus.Add(cus);
            }
            conn.Close();
            return lstCus;

        }

        public void EditEmployee(EmployeeDTO cus)
        {
            SqlConnection conn = CreateConnection();
            SqlCommand cmd = new SqlCommand("UpdateEmployee", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@IDEM", cus.IDME));
            cmd.Parameters.Add(new SqlParameter("@NAME_EM", cus.NAME_EM));
            cmd.Parameters.Add(new SqlParameter("@BIRTH", cus.BIRTH));
            cmd.Parameters.Add(new SqlParameter("@gt", cus.GT));
            cmd.Parameters.Add(new SqlParameter("@NOISINH", cus.NOISINH));
            cmd.Parameters.Add(new SqlParameter("@IDDEPART", cus.KV.ID));
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void DeleteEmployee(EmployeeDTO cus)
        {

            SqlConnection conn = CreateConnection();
            SqlCommand cmd = new SqlCommand("DeleteEmployee", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@IDEM", cus.IDME));
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void NewEmployee(EmployeeDTO cus)
        {
            SqlConnection conn = CreateConnection();
            SqlCommand cmd = new SqlCommand("InserteEmployee", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@IDEM", cus.IDME));
            cmd.Parameters.Add(new SqlParameter("@NAME_EM", cus.NAME_EM));
            cmd.Parameters.Add(new SqlParameter("@BIRTH", cus.BIRTH));
            cmd.Parameters.Add(new SqlParameter("@gt", cus.GT));
            cmd.Parameters.Add(new SqlParameter("@NOISINH", cus.NOISINH));
            cmd.Parameters.Add(new SqlParameter("@IDDEPART", cus.KV.ID));
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();


        }
    }
}
