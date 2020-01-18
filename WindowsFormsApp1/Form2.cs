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
    public partial class Form2 : Form
    {
        public Form1 frm1;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Musteriler a = new Musteriler()
            {
                adi = textBox1.Text,
                soyadi = textBox2.Text,
                telefon = maskedTextBox1.Text,
                adres = textBox4.Text,
                aktifMi=true
            };
            var ekle = HelperMusteriler.Add(a);
            if (ekle.Item2==true)
            {
                MessageBox.Show("Müşteri Başarıyla eklendi.");
            }
            else
            {
                MessageBox.Show("Eklenemedi.");
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 f1 = (Form1)Application.OpenForms["Form1"];
            f1.Yenile();
        }
    }
}
