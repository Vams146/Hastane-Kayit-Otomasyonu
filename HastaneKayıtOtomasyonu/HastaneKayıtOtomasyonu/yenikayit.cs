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
    public partial class yenikayit : Form
    {
        public yenikayit()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=hastane2;Uid=root;pwd=root");
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand("insert into uyelik(uye_ad,uye_soyad,email,sifre,guv_soru,cevap)values(@ad,@sad,@mail,@sifre,@guv,@cvp)", baglanti);
            komut.Parameters.AddWithValue("@ad", textBox1.Text);
            komut.Parameters.AddWithValue("@sad", textBox2.Text);
            komut.Parameters.AddWithValue("@mail", textBox3.Text);
            komut.Parameters.AddWithValue("@sifre", textBox4.Text);
            komut.Parameters.AddWithValue("@guv", comboBox1.Text);
            komut.Parameters.AddWithValue("@cvp", textBox5.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Kaydınız Yapıldı");
    }

        private void yenikayit_Load(object sender, EventArgs e)
        {
            MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=hastane2;Uid=root;pwd=root");
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand("select guv_soru from guvenlik", baglanti);
            MySqlDataReader okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                comboBox1.Items.Add(okuyucu["guv_soru"].ToString());
            }
        }
    }
}
