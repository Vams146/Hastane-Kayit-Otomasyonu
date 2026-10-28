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
    public partial class siremiunuttum : Form
    {
        public siremiunuttum()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=hastane2;Uid=root;pwd=root");
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand("select sifre from uyelik where uye_ad=@ad and guv_soru=@soru and cevap=@cev", baglanti);
            komut.Parameters.AddWithValue("@ad", textBox1.Text);
            komut.Parameters.AddWithValue("@soru", comboBox1.Text);
            komut.Parameters.AddWithValue("@cev", textBox2.Text);
            MySqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                label5.Text = oku["sifre"].ToString();
            }
        }

        private void siremiunuttum_Load(object sender, EventArgs e)
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
