using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Model;
using WindowsFormsApp1.DataApi;
using System.Net;

namespace WindowsFormsApp1.ViewModel
{

    class VanBanViewModel
    {
        string id_user;
        private WindowsFormsApp1.DataApi.API _vm = new WindowsFormsApp1.DataApi.API();
        public BindingSource ContactBindingSource { get; set; }
        //public BindingSource ContactBindingSource2 { get; set; }
        public void Load(string phanloai, string app_key)
        {
            if(phanloai=="VanBanDenCung")
            {
                ContactBindingSource.ResetBindings(false);
                ContactBindingSource.DataSource = _vm.VBC_den(app_key);
            }
            else if (phanloai=="VanBanDiCung")
            {
                ContactBindingSource.ResetBindings(false);
                ContactBindingSource.DataSource = _vm.VBC_di(app_key);
            }
            else if (phanloai == "VanBanDiMem")
            {
                ContactBindingSource.ResetBindings(true);
                ContactBindingSource.DataSource = _vm.VBM_di(app_key);
            }
            else if (phanloai == "VanBanDenMem")
            {
                ContactBindingSource.ResetBindings(false);
                ContactBindingSource.DataSource = _vm.VBM_den(app_key);
            }

        }
        public string Login(string email, string password)
        {
            user _user = new user()
            {
                email = email,
                password = password
            };
            String data = JsonConvert.SerializeObject(_user);
            string id_user = _vm.check_login(data);
            return _vm.check_login(data);
        }
        public void New(string Phanloai, int id_user)
        {
            String data = "";
            if (Phanloai == "VanBanDenCung")
            {
                DateTime dt = new DateTime(2012, 02, 02);
                VanBanDen_C newvb = new VanBanDen_C()
                {
                    id_loaivanban = 1,
                    ma_vb = "hollow",
                    tenvb = "hollow",
                    sovb = "hollow",
                    mota = "hollow",
                    ngayden = dt,
                    nguoigui = "hollow",
                    nguoiky = "hollow",
                    nguoinhan = "hollow",
                    phanloai = "VanBanDenCung"

                };
                data = JsonConvert.SerializeObject(newvb);
            }
            else if (Phanloai == "VanBanDiCung")
            {

                DateTime dt = new DateTime(2012, 02, 02);
                VanBanDi_C newvb = new VanBanDi_C()
                {
                    id_loaivanban = 1,
                    ma_vb = "hollow",
                    tenvb = "hollow",
                    sovb = "hollow",
                    mota = "hollow",
                    ngaygui = dt,
                    nguoigui = "hollow",
                    nguoiky = "hollow",
                    nguoinhan = "hollow",
                    phanloai = "VanBanDiCung"

                };
                data = JsonConvert.SerializeObject(newvb);
            }
            else if (Phanloai == "VanBanDiMem")
            {
                DateTime dt = new DateTime(2012, 02, 02);
                VanBanDi_M newvb = new VanBanDi_M()
                {
                    id_loaivanban = 1,
                    file = "hollow",
                    tenvb = "hollow",
                    sovb = "hollow",
                    mota = "hollow",
                    ngaygui = dt,
                    nguoigui = "hollow",
                    nguoiky = "hollow",
                    nguoinhan = "hollow",
                    phanloai = "VanBanDiMem"

                };
                data = JsonConvert.SerializeObject(newvb);
            }
            else if (Phanloai == "VanBanDenMem")
            {
                DateTime dt = new DateTime(2012, 02, 02);
                VanBanDen_M newvb = new VanBanDen_M()
                {
                    id_loaivanban = 1,
                    file = "hollow",
                    tenvb = "hollow",
                    sovb = "hollow",
                    mota = "hollow",
                    ngayden = dt,
                    nguoigui = "hollow",
                    nguoiky = "hollow",
                    nguoinhan = "hollow",
                    phanloai = "VanBanDenMem"

                };
                data = JsonConvert.SerializeObject(newvb);
            }
            _vm.add(data);

             //Lưu vết
            History newHistory = new History()
            {
                id_user = id_user,
                thaotac = "Add"
            };
            string history = JsonConvert.SerializeObject(newHistory);
            _vm.add_history(history);
            //end Lưu Vết
        }
        public void Edit(string Phanloai, int id_user)
        {
            String data = "";
            var id = 0;
            if(Phanloai == "VanBanDenCung")
            {
                var vanbandenc = ContactBindingSource.Current as VanBanDen_C;
                VanBanDen_C newvb = new VanBanDen_C()
                {
                    id_loaivanban = int.Parse(vanbandenc.id_loaivanban.ToString()),
                    ma_vb = vanbandenc.ma_vb.ToString(),
                    tenvb = vanbandenc.tenvb.ToString(),
                    sovb = vanbandenc.sovb.ToString(),
                    mota = vanbandenc.mota.ToString(),
                    ngayden = vanbandenc.ngayden.Date,
                    nguoigui = vanbandenc.nguoigui.ToString(),
                    nguoiky = vanbandenc.nguoiky.ToString(),
                    nguoinhan = vanbandenc.nguoinhan.ToString(),
                    phanloai = "VanBanDenCung"

                };
                data = JsonConvert.SerializeObject(newvb);
                id = vanbandenc.id;
            }
            else if(Phanloai == "VanBanDiCung")
            {
                var vanbandic = ContactBindingSource.Current as VanBanDi_C;
                VanBanDi_C newvb = new VanBanDi_C()
                {
                    id_loaivanban = int.Parse(vanbandic.id_loaivanban.ToString()),
                    ma_vb = vanbandic.ma_vb.ToString(),
                    tenvb = vanbandic.tenvb.ToString(),
                    sovb = vanbandic.sovb.ToString(),
                    mota = vanbandic.mota.ToString(),
                    ngaygui = vanbandic.ngaygui.Date,
                    nguoigui = vanbandic.nguoigui.ToString(),
                    nguoiky = vanbandic.nguoiky.ToString(),
                    nguoinhan = vanbandic.nguoinhan.ToString(),
                    phanloai = "VanBanDiCung"
                };
                data = JsonConvert.SerializeObject(newvb);
                id = vanbandic.id;
            }
            else if (Phanloai == "VanBanDiMem")
            {
                var vanbandim = ContactBindingSource.Current as VanBanDi_M;
                VanBanDi_M newvb = new VanBanDi_M()
                {
                    id_loaivanban = int.Parse(vanbandim.id_loaivanban.ToString()),
                    tenvb = vanbandim.tenvb.ToString(),
                    sovb = vanbandim.sovb.ToString(),
                    mota = vanbandim.mota.ToString(),
                    ngaygui = vanbandim.ngaygui.Date,
                    nguoigui = vanbandim.nguoigui.ToString(),
                    nguoiky = vanbandim.nguoiky.ToString(),
                    nguoinhan = vanbandim.nguoinhan.ToString(),
                    file = vanbandim.file.ToString(),
                    phanloai = "VanBanDiMem"
                };
                data = JsonConvert.SerializeObject(newvb);
                id = vanbandim.id;
            }
            else if (Phanloai == "VanBanDenMem")
            {
                var vanbandenm = ContactBindingSource.Current as VanBanDen_M;
                VanBanDen_M newvb = new VanBanDen_M()
                {
                    id_loaivanban = int.Parse(vanbandenm.id_loaivanban.ToString()),
                    tenvb = vanbandenm.tenvb.ToString(),
                    sovb = vanbandenm.sovb.ToString(),
                    mota = vanbandenm.mota.ToString(),
                    ngayden = vanbandenm.ngayden.Date,
                    nguoigui = vanbandenm.nguoigui.ToString(),
                    nguoiky = vanbandenm.nguoiky.ToString(),
                    nguoinhan = vanbandenm.nguoinhan.ToString(),
                    file = vanbandenm.file.ToString(),
                    phanloai = "VanBanDenMem"
                };
                data = JsonConvert.SerializeObject(newvb);
                id = vanbandenm.id;
            }
            //Lưu vết
            History newHistory = new History()
            {
                id_user = id_user,
                id_vanban = id,
                thaotac = "Edit"
            };
            string history = JsonConvert.SerializeObject(newHistory);
            //end Lưu Vết
            _vm.add_history(history);
            _vm.update(data, id);
        }
        public void Delete(int id_user,string Phanloai)
        {
            int id = 0;
            if (Phanloai == "VanBanDenCung")
            {
                var vanbandenc = ContactBindingSource.Current as VanBanDen_C;
                id = vanbandenc.id;

            }
            else if (Phanloai == "VanBanDiCung")
            {
                var vanbandic = ContactBindingSource.Current as VanBanDi_C;
                id = vanbandic.id;
            }
            else if (Phanloai == "VanBanDiMem")
            {
                var vanbandim = ContactBindingSource.Current as VanBanDi_M;
                id = vanbandim.id;
            }
            else if (Phanloai == "VanBanDenMem")
            {
                var vanbandenm = ContactBindingSource.Current as VanBanDen_M;
                id = vanbandenm.id;
            }
            MessageBox.Show(""+id);
            _vm.delete(id);
            //Lưu vết
            History newHistory = new History()
            {
                id_user = id_user,
                id_vanban = id,
                thaotac = "Delete"
            };
            string history = JsonConvert.SerializeObject(newHistory);
            //end Lưu Vết
        }
        public void History(int id)
        {
            ContactBindingSource.ResetBindings(false);
            ContactBindingSource.DataSource = _vm.history(id);
        }

    }
}


