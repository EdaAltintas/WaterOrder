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

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        int id;
        string ad = null, soyad = null, tel = null, adres = null;
        Musteriler m;
        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 f1 = (Form1)Application.OpenForms["Form1"];
            f1.SiparisYenile();
            f1.Yenile();
        }

        public Form4()
        {
            
            InitializeComponent();
        }
        public Form4(Musteriler m)
        {
            this.m = m;
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            textBox1.Text = m.adi;
            textBox2.Text = m.soyadi;
            textBox4.Text = m.adres;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Siparisler s = new Siparisler();
            s.tutar = Convert.ToInt32(textBox3.Text);
            s.müsteriId = m.id;
            s.tarih = DateTime.Now;
            s.durumu = 0;
            s.aktifMi = true;
            var a = HelperSiparisler.CUD(s, System.Data.Entity.EntityState.Added);
            if (a.Item2)
            {
                MessageBox.Show("Sipariş ekleme başarılı.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Sipariş ekleme yapılamadı.");
            }
        }
    }
}
