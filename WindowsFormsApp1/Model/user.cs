using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model
{
    [Serializable]
    class user
    {
        public int Id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int Id_profile { get; set; }
    }
}
