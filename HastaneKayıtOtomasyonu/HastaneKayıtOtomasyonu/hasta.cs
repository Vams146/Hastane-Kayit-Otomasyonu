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
    public partial class hasta : Form
    {
        public hasta()
        {
            InitializeComponent();
        }
        public void listele()
        {
            MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=hastane2;Uid=root;pwd=root");
            MySqlCommand komut = new MySqlCommand("Select*from hastalar", baglanti);
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
            MySqlCommand ara = new MySqlCommand("Select*from hastalar where ad like '" + textBox3.Text + "%'", baglanti);
            DataSet ds = new DataSet();
            MySqlDataAdapter kopru = new MySqlDataAdapter(ara);
            kopru.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

            private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=hastane2;Uid=root;pwd=root");
            baglanti.Open();
            MySqlCommand sil = new MySqlCommand("Delete from hastalar where idhastalar=@id", baglanti);
            sil.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells["idhastalar"].Value.ToString());
            sil.ExecuteNonQuery();
            MessageBox.Show("Kaydınız Başarıyla Silindi");
            listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=hastane2;Uid=root;pwd=root");
            baglanti.Open();
            MySqlCommand ekle = new MySqlCommand("insert into hastalar(tckimlik,ad,soyad,mail,telefon,cinsiyet)values(@tc,@ad,@sad,@mail,@tel,@cnt)", baglanti);
            ekle.Parameters.AddWithValue("@ad", textBox1.Text);
            ekle.Parameters.AddWithValue("@sad", textBox2.Text);
            ekle.Parameters.AddWithValue("@cnt", comboBox1.Text);
            ekle.Parameters.AddWithValue("@tc", maskedTextBox1.Text);
            ekle.Parameters.AddWithValue("@mail", maskedTextBox2.Text);
            ekle.Parameters.AddWithValue("@tel", maskedTextBox3.Text);
            ekle.ExecuteNonQuery();
            MessageBox.Show("Kayıt Başarıyla Eklendi");
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=hastane2;Uid=root;pwd=root");
            if (baglanti.State != ConnectionState.Open)
            {
                baglanti.Open();
            }
            MySqlCommand guncelle = new MySqlCommand("update hastalar set ad=@ad,soyad=@sad,cinsiyet=@cnt,tckimlik=@tc,mail=@mail,telefon=@tel where idhastalar=@id", baglanti);
            guncelle.Parameters.AddWithValue("@ad", textBox1.Text);
            guncelle.Parameters.AddWithValue("@sad", textBox2.Text);
            guncelle.Parameters.AddWithValue("@cnt", comboBox1.Text);
            guncelle.Parameters.AddWithValue("@tc", maskedTextBox1.Text);
            guncelle.Parameters.AddWithValue("@mail", maskedTextBox2.Text);
            guncelle.Parameters.AddWithValue("@tel", maskedTextBox3.Text);
            guncelle.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells["idhastalar"].Value.ToString());
            guncelle.ExecuteNonQuery();
            MessageBox.Show("Kaydınız Güncellendi");
            listele();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            arama();
        }

        private void hasta_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            maskedTextBox1.Text = dataGridView1.CurrentRow.Cells["tckimlik"].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells["ad"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["soyad"].Value.ToString();
            maskedTextBox2.Text = dataGridView1.CurrentRow.Cells["mail"].Value.ToString();
            maskedTextBox3.Text = dataGridView1.CurrentRow.Cells["telefon"].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells["cinsiyet"].Value.ToString();
        }
    }
}
