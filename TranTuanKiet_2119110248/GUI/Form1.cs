using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TranTuanKiet_2119110248
{
    public partial class Form1 : Form
    {
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

        }

        private void Xoa(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc là muốn xóa thành viên này!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result == System.Windows.Forms.DialogResult.OK)
            {

            }
        }

        private void Sua(object sender, EventArgs e)
        {

        }
    }
}
