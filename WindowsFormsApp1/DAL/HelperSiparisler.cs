using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Entity;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1.DAL
{
    public static class HelperSiparisler
    {
        public static (Siparisler,bool) CUD(Siparisler s,EntityState state)
        {
            using (SuSatisEntities1 sm=new SuSatisEntities1())
            {
                sm.Entry(s).State = state;
                if (sm.SaveChanges()>0)
                {
                    return (s, true);
                }
                else
                {
                    return (s, false);
                }
            }
        }
        public static List<Siparisler> GetList()
        {
            using (SuSatisEntities1 s = new SuSatisEntities1())
            {
                return s.Siparisler.ToList();
            }
        }
        public static Siparisler GetByID(int siparisID)
        {
            using (SuSatisEntities1 m = new SuSatisEntities1())
            {
                return m.Siparisler.Find(siparisID);
            }
        }
        public static List<SiparislerModel> GetList1()
        {
            List<SiparislerModel> sml = new List<SiparislerModel>();
            Musteriler mus = new Musteriler();
            using (SuSatisEntities1 s = new SuSatisEntities1())
            {
                var p = s.Siparisler.ToList();
                foreach (var item in p)
                {
                    SiparislerModel sm = new SiparislerModel();
                    sm.id = item.id;
                    sm.musteriler.adi = item.Musteriler.adi;
                    sm.musteriler.soyadi = item.Musteriler.soyadi;
                    sm.musteriler.adres = item.Musteriler.adres;
                    sm.tutar = item.tutar;
                    sm.tarih = item.tarih;
                    if (item.durumu==0)
                    {
                        sm.durumu ="Hazırlanıyor" ;
                    }
                    else if (item.durumu==1)
                    {
                        sm.durumu = "Yola çıktı";
                    }
                    else if (item.durumu==2)
                    {
                        sm.durumu = "Sipariş teslim edildi.";
                    }
                    sm.aktifMi = item.aktifMi;
                    sml.Add(sm);
                }
                return sml;
            }
        }

    }
}
