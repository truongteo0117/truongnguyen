using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model
{
    [Serializable]
    class VanBanDen_C
    {
        public int id { get; set; }
        public int id_loaivanban { get; set; } 
        public string ma_vb { get; set; }
        public string tenvb { get; set; }
        public string sovb { get; set; }
        public string mota { get; set; }
        public DateTime ngayden { get; set; }
        public string nguoiky { get; set; }
        public string nguoinhan { get; set; }
        public string nguoigui { get; set; }
        public string phanloai { get; set; }
    }
}
