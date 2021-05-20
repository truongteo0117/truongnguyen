using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using WindowsFormsApp1.ViewModel;
namespace WindowsFormsApp1
{
    public partial class LoginF : DevExpress.XtraEditors.XtraForm
    {
        private WindowsFormsApp1.ViewModel.VanBanViewModel _vm = new WindowsFormsApp1.ViewModel.VanBanViewModel();
        public LoginF()
        {
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;
        }
        public LoginF(string name):this()
        {
            textBox1.Text = name;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                string[] user = new string[2];
                if (_vm.Login(textBox1.Text, textBox2.Text) != "null")
                {
                    MessageBox.Show("Đăng Nhập Thành Công !!");
                    user[0] = textBox1.Text;
                    user[1] = _vm.Login(textBox1.Text, textBox2.Text);
                    MainForm mainForm = new MainForm(user);
                    mainForm.FormClosed += new FormClosedEventHandler(mainForm_FormClosed);
                    mainForm.Show();
                    this.Hide();

                }
                else MessageBox.Show("Đăng Nhập Thất Bại");
            }
            else MessageBox.Show("Vui Lòng Điền Đủ Thông Tin");
        }
        private void mainForm_FormClosed(object sender, EventArgs e)
        {
            this.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void LoginF_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}