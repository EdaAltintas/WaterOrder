using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Entity;

namespace WindowsFormsApp1.Model
{
    public class SiparislerModel
    {
        public int id { get; set; }
        public int müsteriId { get; set; }
        public int tutar { get; set; }
        public System.DateTime tarih { get; set; }
        public string durumu { get; set; }
        public bool aktifMi { get; set; }

        public Musteriler musteriler = new Musteriler();
    }
}
