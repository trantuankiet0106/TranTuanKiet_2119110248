using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranTuanKiet_2119110248.DAO
{
  public  class Dbconnection
    {
        public Dbconnection()
        {
        }
        public SqlConnection CreateConnection()
        {
            SqlConnection conn = new SqlConnection(@"Data Source =TRAN-TUAN-KIET\SQLEXPRESS; Initial Catalog=TranTuanKiet_2119110248;
                       User id = sa; Password = sa");
            return conn;

        }
    }
}
