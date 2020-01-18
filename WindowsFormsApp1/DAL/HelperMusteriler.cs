using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Entity;

namespace WindowsFormsApp1.DAL
{
    public static class HelperMusteriler
    {
        public static (Musteriler,bool) Add(Musteriler m)
        {
            using (SuSatisEntities1 s=new SuSatisEntities1())
            {
                s.Musteriler.Add(m);
                if (s.SaveChanges()>0)
                {
                    return (m, true);
                }
                else
                {
                    return (m, false);
                }
            }
        }

        public static bool Update(Musteriler m)
        {
            using(SuSatisEntities1 s=new SuSatisEntities1())
            {
                s.Entry(m).State = System.Data.Entity.EntityState.Modified;
                if (s.SaveChanges()>0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool Delete(int Müsteriid)
        {
            using (SuSatisEntities1 s=new SuSatisEntities1())
            {
                var sorgu = s.Musteriler.Where(x => x.id == Müsteriid).FirstOrDefault();
                s.Musteriler.Remove(sorgu);
                if (s.SaveChanges()>0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public static List< Musteriler> GetByName(string MüsteriAd)
        {
            using (SuSatisEntities1 s=new SuSatisEntities1())
            {
                return s.Musteriler.Where(x => x.adi.Contains(MüsteriAd)).ToList();
            }
        }
        public static List<Musteriler> GetBySurname(string MüsteriSoyad)
        {
            using (SuSatisEntities1 s = new SuSatisEntities1())
            {
                return s.Musteriler.Where(x => x.soyadi.Contains(MüsteriSoyad)).ToList();
            }
        }
        public static List<Musteriler> GetByNameSurname(string MüsteriAd,string MüsteriSoyad)
        {
            using (SuSatisEntities1 s = new SuSatisEntities1())
            {
                return s.Musteriler.Where(x => x.adi.Contains(MüsteriAd) && x.soyadi.Contains(MüsteriSoyad)).ToList();
            }
        }

        public static List<Musteriler> GetList()
        {
            using (SuSatisEntities1 s = new SuSatisEntities1())
            {
                return s.Musteriler.ToList();
            }
        }
        public static Musteriler GetByID(int müsteriId)
        {
            using (SuSatisEntities1 m = new SuSatisEntities1())
            {
                return m.Musteriler.Find(müsteriId);
            }
        }
    }
}
