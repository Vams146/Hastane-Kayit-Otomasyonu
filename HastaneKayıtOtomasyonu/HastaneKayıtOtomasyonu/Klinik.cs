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
    public partial class Klinik : Form
    {
        public Klinik()
        {
            InitializeComponent();
        }
        public void listele()
        {
            MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=hastane2;Uid=root;pwd=root");
            MySqlCommand komut = new MySqlCommand("Select*from klinik", baglanti);
            DataSet ds = new DataSet();
            MySqlDataAdapter kopru = new MySqlDataAdapter(komut);
            kopru.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        public void arama()
        {
            MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=hastane2;Uid=root;pwd=root");
            if (baglanti.State != ConnectionState.Open)
            {
                baglanti.Open();
            }
            MySqlCommand ara = new MySqlCommand("Select*from klinik where klinikadi like '" + textBox2.Text + "%'", baglanti);
            DataSet ds = new DataSet();
            MySqlDataAdapter kopru = new MySqlDataAdapter(ara);
            kopru.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }


        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=hastane2;Uid=root;pwd=root");
            baglanti.Open();
            MySqlCommand ekle = new MySqlCommand("insert into klinik(klinikadi)values(@ad)", baglanti);
            ekle.Parameters.AddWithValue("@ad", textBox1.Text);
            ekle.ExecuteNonQuery();
            MessageBox.Show("Kayıt Başarıyla Eklendi");
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=hastane2;Uid=root;pwd=root");
            baglanti.Open();
            MySqlCommand sil = new MySqlCommand("Delete from klink where idklinik=@id", baglanti);
            sil.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells["idklinik"].Value.ToString());
            sil.ExecuteNonQuery();
            MessageBox.Show("Kaydınız Başarıyla Silindi");
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=hastane2;Uid=root;pwd=root");
            if (baglanti.State != ConnectionState.Open)
            {
                baglanti.Open();
            }
            MySqlCommand guncelle = new MySqlCommand("update klinik set klinikadi=@ad where idklinik=@id", baglanti);
            guncelle.Parameters.AddWithValue("@ad", textBox1.Text);
            guncelle.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells["idklinik"].Value.ToString());
            guncelle.ExecuteNonQuery();
            MessageBox.Show("Kaydınız Güncellendi");
            listele();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            arama();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["klinikadi"].Value.ToString();
        }

        private void Klinik_Load(object sender, EventArgs e)
        {
            listele();  
        }
    }
}
