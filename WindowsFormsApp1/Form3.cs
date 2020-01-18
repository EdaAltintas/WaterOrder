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
    public partial class Form3 : Form
    {
        Musteriler m = new Musteriler();

        public Form3(Musteriler m)
        {
            InitializeComponent();
            this.m = m;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            textBox1.Text = m.adi;
            textBox2.Text = m.soyadi;
            maskedTextBox1.Text = m.telefon;
            textBox4.Text = m.adres;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m.adi = textBox1.Text;
            m.soyadi = textBox2.Text;
            m.telefon = maskedTextBox1.Text;
            m.adres = textBox4.Text;
            var ab = HelperMusteriler.Update(m);
            if (ab)
            {
                MessageBox.Show("Güncelleme yapıldı.");
            }
            else
            {
                MessageBox.Show("Güncelleme başarısız.");
            }
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 f1 = (Form1)Application.OpenForms["Form1"];
            f1.Yenile();
        }
    }
}
