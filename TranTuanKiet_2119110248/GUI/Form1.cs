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
using TranTuanKiet_2119110248.GUI;

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
                    MessageBox.Show("Hãy Điền đủ thông tin !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (TBID.Text.Length < 10)
                    {
                        MessageBox.Show("Phải Điền đủ 10 chữ số!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
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
                        MessageBox.Show("Thêm thành công !");
                    }
                }
            }
            catch (Exception) {
                if (TBID.Text.Length > 10 )
                {
                    MessageBox.Show("Mã Nhân Viên Tối Đa 10 Chữ Sô!,","thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                else
                MessageBox.Show("Mã Nhân Viên Đã Tồn Tại ! ","thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
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
                MessageBox.Show("Xóa thành công !");
            }
        }

        private void Sua(object sender, EventArgs e)
        {
            if ((TBID.Text == "") || (TBNAME.Text == "") || TBNOISINH.Text == "")
            {
                MessageBox.Show("Điền Đủ thông tin ! ", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DataGridViewRow row = dataGridView1.CurrentRow;
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
                cus.NOISINH = TBNOISINH.Text;
                cus.KV = (DepartmentDTO)CBNAME.SelectedItem;
                cusBAL.EditCustomer(cus);


                row.Cells[0].Value = cus.IDME;
                row.Cells[1].Value = cus.NAME_EM;
                row.Cells[2].Value = cus.BIRTH;
                row.Cells[3].Value = cus.GT;
                row.Cells[4].Value = cus.NOISINH;
                row.Cells[5].Value = cus.IDDEPART;
                MessageBox.Show("sữa thành công !");
            }
          
            

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

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
          
            this.Hide();
            form2.ShowDialog();
            this.Show();
            this.Close();
        }

        private void TBID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }


    }
}
