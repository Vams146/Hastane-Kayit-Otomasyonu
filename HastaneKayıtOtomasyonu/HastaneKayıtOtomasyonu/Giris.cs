using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HastaneKayıtOtomasyonu
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=hastane2;Uid=root;pwd=root");
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand("Select*from uyelik where uye_ad=@ad and sifre=@sif", baglanti);
            komut.Parameters.AddWithValue("@ad", textBox1.Text);
            komut.Parameters.AddWithValue("@sif", textBox2.Text);
            MySqlDataReader oku = komut.ExecuteReader();
            if (oku.HasRows == true)
            {
                Form a = new AnaForm();
                a.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı!");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form a = new siremiunuttum();
            a.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form a = new yenikayit();
            a.ShowDialog();
        }
    }
}
