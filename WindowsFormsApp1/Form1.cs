using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.DAL;
using WindowsFormsApp1.Entity;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form2 frm2=new Form2();
        public Form1()
        {
            InitializeComponent();
        }
        SuSatisEntities1 s = new SuSatisEntities1();
        private void Form1_Load(object sender, EventArgs e)
        {
            Yenile();
            SiparisYenile();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frm2 = new Form2();
            frm2.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Musteriler> musteriler = new List<Musteriler>();
            string ad = textBox1.Text;
            string soyad = textBox2.Text;
            if (!String.IsNullOrEmpty(ad)&&!String.IsNullOrEmpty(soyad))
            {
                musteriler= HelperMusteriler.GetByNameSurname(ad, soyad);
            }
            else if (!String.IsNullOrEmpty(ad) && String.IsNullOrEmpty(soyad))
            {
                musteriler= HelperMusteriler.GetByName(ad);
            }
            else if (String.IsNullOrEmpty(ad) && !String.IsNullOrEmpty(soyad))
            {
                musteriler = HelperMusteriler.GetBySurname(soyad);
            }
            else
            {
                musteriler = HelperMusteriler.GetList();
            }

            dataGridView1.Rows.Clear();
            foreach (var item in musteriler)
            {
                if (item.aktifMi==true)
                {
                    dataGridView1.Rows.Add(item.id, item.adi, item.soyadi, item.telefon, item.adres);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Musteriler m = HelperMusteriler.GetByID(Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value));
            Form3 frm3 = new Form3(m);
            frm3.Show();

        }
        public void Yenile()
        {
            dataGridView1.Rows.Clear();
            List<Musteriler> musteri = HelperMusteriler.GetList();
            foreach (var item in musteri)
            {
                if (item.aktifMi==true)
                {
                    dataGridView1.Rows.Add(item.id, item.adi, item.soyadi, item.telefon, item.adres);
                }
            }
        }
        public void SiparisYenile()
        {
            dataGridView2.Rows.Clear();
            List<SiparislerModel> model = HelperSiparisler.GetList1(); 
            foreach (var item in model)
            {
                if (item.aktifMi == true)
                {
                    dataGridView2.Rows.Add(item.id,item.musteriler.adi,item.musteriler.soyadi,item.durumu,item.musteriler.adres,item.tutar);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var a = MessageBox.Show(" Silmek istediğinize emin misiniz?", "Bilgilendirme", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (a==DialogResult.Yes)
            {
                Musteriler m = HelperMusteriler.GetByID(Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value));
                m.aktifMi = false;
                var b = HelperMusteriler.Update(m);
            }
            Yenile();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4(HelperMusteriler.GetByID(Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value)));
            frm4.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Siparisler sp =HelperSiparisler.GetByID(Convert.ToInt32(dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0].Value));
            sp.durumu = 1;
            var aaa = HelperSiparisler.CUD(sp, System.Data.Entity.EntityState.Modified);
            if (aaa.Item2)
            {
                MessageBox.Show("Durum güncellendi.");
            }
            else
            {
                MessageBox.Show("Durum güncelenemedi.");
            }
            SiparisYenile();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Siparisler sp = HelperSiparisler.GetByID(Convert.ToInt32(dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0].Value));
            sp.durumu = 2;
            var aaa = HelperSiparisler.CUD(sp, System.Data.Entity.EntityState.Modified);
            if (aaa.Item2)
            {
                MessageBox.Show("Durum güncellendi.");
            }
            else
            {
                MessageBox.Show("Durum güncelenemedi.");
            }
            SiparisYenile();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            List<SiparislerModel> model = HelperSiparisler.GetList1();
            foreach (var item in model)
            {
                if (item.aktifMi == true && item.tarih.Day==DateTime.Now.Day)
                {
                    dataGridView2.Rows.Add(item.id, item.musteriler.adi, item.musteriler.soyadi, item.durumu, item.musteriler.adres, item.tutar);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Siparisler sp = HelperSiparisler.GetByID(Convert.ToInt32(dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0].Value));
            sp.aktifMi = false;
            var aaa = HelperSiparisler.CUD(sp, System.Data.Entity.EntityState.Modified);
            if (aaa.Item2)
            {
                MessageBox.Show("Kayıt silindi.");
            }
            else
            {
                MessageBox.Show("Kayıt silinmedi.");
            }
            SiparisYenile();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int a=  dataGridView2.RowCount;
            int i = 0;
            for (;;)
            {
                if (i>=a)
                {
                    break;
                }
                Siparisler sp = HelperSiparisler.GetByID(Convert.ToInt32(dataGridView2.Rows[i].Cells[0].Value));
                sp.aktifMi = false;
                HelperSiparisler.CUD(sp, System.Data.Entity.EntityState.Modified);
                i++;
            }
            SiparisYenile();
        }
    }
}
