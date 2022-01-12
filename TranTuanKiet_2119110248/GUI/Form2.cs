using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TranTuanKiet_2119110248.GUI
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            SqlConnection conn = new SqlConnection(@"Data Source =TRAN-TUAN-KIET\SQLEXPRESS; Initial Catalog=TranTuanKiet_2119110248;
                        User id = sa; Password = sa");
            try
            {
                    conn.Open();

                    string sql = "select * from Account where TK='" + TBTK.Text + "'and MK='" + TBMK.Text + "'";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader data = cmd.ExecuteReader();
                    if (data.Read() == true)
                    {
                        Form1 form1 = new Form1();
                    this.Hide();
                        form1.ShowDialog();
                    this.Show();
                    }
                else
                {
                    MessageBox.Show("sai tài khoản hoặc mật khẩu","thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối  !");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((TBMK.Text == "") || (TBTK.Text == ""))
            {
                MessageBox.Show("Hãy Điền đủ thông tin !", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {

                SqlConnection conn = new SqlConnection(@"Data Source =TRAN-TUAN-KIET\SQLEXPRESS; Initial Catalog=TranTuanKiet_2119110248;
                        User id = sa; Password = sa");
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into Account values (@TK,@MK)", conn);
                cmd.Parameters.Add(new SqlParameter("@TK", TBTK.Text));
                cmd.Parameters.Add(new SqlParameter("@MK", TBMK.Text));
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("đăng ký thành công !","thông báo", MessageBoxButtons.OK);
            
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có Muốn đống chương trình không!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                this.Close();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
