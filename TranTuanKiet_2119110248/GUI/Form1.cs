using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TranTuanKiet_2119110248.BLL;
using TranTuanKiet_2119110248.DTO;

namespace TranTuanKiet_2119110248
{
    public partial class Form1 : Form
    {
        EmployeeBLL cusBAL = new EmployeeBLL();
        DepartmentBLL areaBAL = new DepartmentBLL();
        public Form1()
        {
            InitializeComponent();
        }
        //Thoát
        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có Muốn đống chương trình không!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                this.Close();
            }
        }

        private void Them(object sender, EventArgs e)
        {
            try
            {
                if ((TBID.Text == "") || (TBNAME.Text == "") || TBNOISINH.Text == "")
                {
                    MessageBox.Show("Hãy Điền đủ thông tin !", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
                else
                {
                    EmployeeDTO cus = new EmployeeDTO();
                    cus.IDME = int.Parse(TBID.Text);
                    cus.NAME_EM = TBNAME.Text;
                    cus.BIRTH = DTNS.Value;
                    if (CBGT.Checked)
                    {
                        cus.GT = "NAM";
                    }
                    else
                    {
                        cus.GT = "NU";
                    }
                    //cus.GT = TBGT.Text;
                    cus.NOISINH = TBNOISINH.Text;
                    cus.KV = (DepartmentDTO)CBNAME.SelectedItem;
                    cusBAL.NewCustomer(cus);
                    dataGridView1.Rows.Add(cus.IDME, cus.NAME_EM, cus.BIRTH, cus.GT, cus.NOISINH, cus.KV.NAME);
                }
            }
            catch (Exception) {
                MessageBox.Show("Mã Nhân Viên Đã Tồn Tại ! ");
            }
        }

        private void Xoa(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc là muốn xóa thành viên này!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result == System.Windows.Forms.DialogResult.OK)
            {

                EmployeeDTO cus = new EmployeeDTO();
                cus.IDME =int.Parse(TBID.Text);
                cusBAL.DeleteCustomer(cus);

                DataGridViewRow row = dataGridView1.CurrentRow;
                int idx = dataGridView1.CurrentCell.RowIndex;
                dataGridView1.Rows.RemoveAt(idx);
            }
        }

        private void Sua(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<EmployeeDTO> lstCus = cusBAL.ReadCusTomer();
            foreach (EmployeeDTO cus in lstCus)
            {
                dataGridView1.Rows.Add(cus.IDME, cus.NAME_EM, cus.BIRTH.Date.ToString(), cus.GT, cus.NOISINH, cus.IDDEPART);
            }
            List<DepartmentDTO> lstArea = areaBAL.ReadAreaList();
            foreach (DepartmentDTO areas in lstArea)
            {
                CBNAME.Items.Add(areas);
                CBNAME.DisplayMember = "NAME";

            }
        }

        private void ROW(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;


            if (idx >= 0)
            {
                TBID.Text = dataGridView1.Rows[idx].Cells[0].Value.ToString();
                TBNAME.Text = dataGridView1.Rows[idx].Cells[1].Value.ToString();
                DTNS.Text = dataGridView1.Rows[idx].Cells[2].Value.ToString();
                if (dataGridView1.Rows[idx].Cells[3].Value.ToString().Length < 3)
                {
                    CBGT.Checked = false;
                }
                else
                {
                    CBGT.Checked = true;
                }

                TBNOISINH.Text = dataGridView1.Rows[idx].Cells[4].Value.ToString();
                CBNAME.Text = dataGridView1.Rows[idx].Cells[5].Value.ToString();

            }
        }
    }
}
