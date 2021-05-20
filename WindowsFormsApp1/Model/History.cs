using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model
{
    [Serializable]
    class History
    {
        public int id { get; set; }
        public int id_user { get; set; }
        public int id_vanban { get; set; }
        public string thaotac { get; set; }
        public DateTime thoigian { get; set; }
        public List<user> NameUser { get; set; } = new List<user>();
    }
}
