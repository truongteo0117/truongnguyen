using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApp1.Model;
using WindowsFormsApp1.ViewModel;
namespace WindowsFormsApp1
{
    public partial class MainForm : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        string phanloai;
        string app_key;
        int id;
        string name;
        private WindowsFormsApp1.ViewModel.VanBanViewModel _vm = new WindowsFormsApp1.ViewModel.VanBanViewModel();
        public MainForm(string[] user)
        {
            InitializeComponent();
            phanloai = "VanBanDenCung";
            _vm.ContactBindingSource = vanBanDen_CBindingSource;
            _vm.Load(phanloai, app_key);
            TabControl1.TabPages.Remove(vanbandicungTabPage1);
            TabControl1.TabPages.Remove(vanbandimemTabPage3);
            TabControl1.TabPages.Remove(vanbandenmemTabPage4);
            TabControl1.TabPages.Remove(history);
            name = user[0];
            label1.Text = user[0];
            id = int.Parse(user[1]);
            accordionControl1.LookAndFeel.SkinName = "Office 2010 Blue";

        }
        private void fluentDesignFormControl1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void gridControl2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void vanBanDiCControlElement3_Click(object sender, EventArgs e)
        {
            phanloai = "VanBanDiCung";
            _vm.ContactBindingSource = vanBanDi_CBindingSource;
            _vm.Load(phanloai, app_key);
            TabControl1.TabPages.Add(vanbandicungTabPage1);
            TabControl1.SelectedTabPage = vanbandicungTabPage1;
        }

        private void TabControl1_CloseButtonClick(object sender, EventArgs e)
        {
            TabControl1.TabPages.Remove(TabControl1.SelectedTabPage);
        }

        private void vanBanDenCControlElement4_Click(object sender, EventArgs e)
        {
            phanloai = "VanBanDenCung";
            _vm.ContactBindingSource = vanBanDen_CBindingSource;
            _vm.Load(phanloai, app_key);
            TabControl1.TabPages.Add(vanbandencungTabPage2);
            TabControl1.SelectedTabPage = vanbandencungTabPage2;

        }
        private void vanBanDiMControlElement6_Click(object sender, EventArgs e)
        {
            phanloai = "VanBanDiMem";
            _vm.ContactBindingSource = vanBanDi_MBindingSource;
            _vm.Load(phanloai, app_key);
            TabControl1.TabPages.Add(vanbandimemTabPage3);
            TabControl1.SelectedTabPage = vanbandimemTabPage3;
        }

        private void vanBanDenMControlElement7_Click(object sender, EventArgs e)
        {
            phanloai = "VanBanDenMem";
            _vm.ContactBindingSource = vanBanDen_MBindingSource;
            _vm.Load(phanloai, app_key);
            TabControl1.TabPages.Add(vanbandenmemTabPage4);
            TabControl1.SelectedTabPage = vanbandenmemTabPage4;
        }

        private void gridView2_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            //_vm.Edit();
        }

        //Add new row
        private void button5_Click(object sender, EventArgs e)
        {
            phanloai = "VanBanDenCung";
            _vm.New(phanloai, id);
            _vm.Load(phanloai, app_key);
        }

        //Delete
        private void button4_Click(object sender, EventArgs e)
        {
            phanloai = "VanBanDenCung";
            _vm.Delete(id, phanloai);
            _vm.Load(phanloai, app_key);
        }

        //Update
        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            string PhanLoai = "VanBanDenCung";
            _vm.Edit(PhanLoai, id);
            _vm.Load(phanloai, app_key);
        }
        //end Update
        //Update
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            string PhanLoai = "VanBanDiCung";
            _vm.Edit(PhanLoai, id);
            _vm.Load(phanloai, app_key);
        }
        //end Update
        private void accordionControlElement2_Click(object sender, EventArgs e)
        {
            _vm.ContactBindingSource = historyBindingSource;
            _vm.History(id);
            TabControl1.TabPages.Add(history);
            TabControl1.SelectedTabPage = history;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            phanloai = "VanBanDiCung";
            _vm.New(phanloai, id);
            _vm.Load(phanloai, app_key);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            phanloai = "VanBanDiMem";
            _vm.New(phanloai, id);
            _vm.Load(phanloai, app_key);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            phanloai = "VanBanDenMem";
            _vm.New(phanloai, id);
            _vm.Load(phanloai, app_key);
        }
        //Xử Lý Văn Bản ĐI CỨng
        private void gridView1_CellValueChanged_1(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            string PhanLoai = "VanBanDiCung";
            _vm.Edit(PhanLoai, id);
            _vm.Load(phanloai, app_key);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            phanloai = "VanBanDiCung";
            _vm.New(phanloai, id);
            _vm.Load(phanloai, app_key);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            phanloai = "VanBanDiCung";
            _vm.Delete(id, phanloai);
            _vm.Load(phanloai, app_key);
        }
        //End
        //Xử Lý Văn Bản Đi Mềm
        private void gridView3_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            string PhanLoai = "VanBanDiMem";
            _vm.Edit(PhanLoai, id);
            _vm.Load(phanloai, app_key);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            phanloai = "VanBanDiMem";
            _vm.Delete(id, phanloai);
            _vm.Load(phanloai, app_key);
        }
        //End

        //Xử Lý Văn Bản Đến Mềm
        private void gridView4_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            string PhanLoai = "VanBanDenMem";
            _vm.Edit(PhanLoai, id);
            _vm.Load(phanloai, app_key);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            phanloai = "VanBanDenMem";
            _vm.Delete(id, phanloai);
            _vm.Load(phanloai, app_key);
        }
        //End
        private void accordionControlElement4_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginF loginForm = new LoginF(name);
            loginForm.Show();

        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
