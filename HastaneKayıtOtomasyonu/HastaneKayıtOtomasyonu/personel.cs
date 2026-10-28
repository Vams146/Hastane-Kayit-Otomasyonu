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
    public partial class personel : Form
    {
        public personel()
        {
            InitializeComponent();
        }
        public void listele()
        {
            MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=hastane2;Uid=root;pwd=root");
            MySqlCommand komut = new MySqlCommand("Select*from personel", baglanti);
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
            MySqlCommand ara = new MySqlCommand("Select*from personel where per_ad like '"+textBox5.Text+"%'", baglanti);
            DataSet ds = new DataSet();
            MySqlDataAdapter kopru = new MySqlDataAdapter(ara);
            kopru.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void personel_Load(object sender, EventArgs e)
        {
            listele();
            MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=hastane2;Uid=root;pwd=root");
            baglanti.Open();
            MySqlCommand getir = new MySqlCommand("Select bransadi from branslar", baglanti);
            MySqlDataReader okuyucu = getir.ExecuteReader();
            while (okuyucu.Read())
            {
                comboBox1.Items.Add(okuyucu["bransadi"].ToString());
                comboBox2.Items.Add(okuyucu["bransadi"].ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=hastane2;Uid=root;pwd=root");
            baglanti.Open();
            MySqlCommand ekle = new MySqlCommand("insert into personel(per_ad,per_soyad,brans,klinik,per_tc,telefon,gorevtarihi,personelresmi)values(@ad,@sad,@bns,@knk,@tc,@tel,@gt,@res)", baglanti);
            ekle.Parameters.AddWithValue("@ad", textBox1.Text);
            ekle.Parameters.AddWithValue("@sad", textBox2.Text);
            ekle.Parameters.AddWithValue("@res", textBox3.Text);
            ekle.Parameters.AddWithValue("@bns", comboBox1.Text);
            ekle.Parameters.AddWithValue("@knk", comboBox2.Text);
            ekle.Parameters.AddWithValue("@tc", maskedTextBox1.Text);
            ekle.Parameters.AddWithValue("@tel", maskedTextBox2.Text);
            ekle.Parameters.AddWithValue("@gt", dateTimePicker1.Value);
            ekle.ExecuteNonQuery();
            MessageBox.Show("Kayıt Başarıyla Eklendi");
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=hastane2;Uid=root;pwd=root");
            baglanti.Open();
            MySqlCommand sil = new MySqlCommand("Delete from personel where idpersonel=@id", baglanti);
            sil.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells["idpersonel"].Value.ToString());
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
            MySqlCommand guncelle = new MySqlCommand("update personel set per_ad=@ad,per_soyad=@sad,brans=@bns,klinik=@knk,per_tc=@tc,telefon=@tel,gorevtarihi=@gt where idpersonel=@id", baglanti);
            guncelle.Parameters.AddWithValue("@ad", textBox1.Text);
            guncelle.Parameters.AddWithValue("@sad", textBox2.Text);
            guncelle.Parameters.AddWithValue("@tc", maskedTextBox1.Text);
            guncelle.Parameters.AddWithValue("@tel", maskedTextBox2.Text);
            guncelle.Parameters.AddWithValue("@bns", comboBox1.Text);
            guncelle.Parameters.AddWithValue("@knk", comboBox2.Text);
            guncelle.Parameters.AddWithValue("@gt", dateTimePicker1.Value);
            guncelle.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells["idpersonel"].Value.ToString());
            guncelle.ExecuteNonQuery();
            MessageBox.Show("Kaydınız Güncellendi");
            listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["per_ad"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["per_soyad"].Value.ToString();
            maskedTextBox1.Text = dataGridView1.CurrentRow.Cells["per_tc"].Value.ToString();
            maskedTextBox2.Text = dataGridView1.CurrentRow.Cells["telefon"].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells["brans"].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells["klinik"].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells["gorevtarihi"].Value.ToString();
            pictureBox1.ImageLocation = dataGridView1.CurrentRow.Cells["personelresmi"].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            arama();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
            textBox3.Text = openFileDialog1.FileName;
        }
    }
}
