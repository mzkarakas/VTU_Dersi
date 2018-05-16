using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SporSalonuApp
{
    public partial class TahsilatFormu : Form
    {
        public TahsilatFormu()
        {
            InitializeComponent();
            verileriGoster();
            textBox1.Enabled = false;
            textBox2.Enabled = false;
        }

        int idUye = 0;
        double uyeborcu = 0;


        SqlConnection baglan = new SqlConnection("Data Source = LENOVO; Initial Catalog = SporSalonuDataBase; Integrated Security = True");

        private void verileriGoster()                                            // yordam oluşturuluyor
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select * from Uyeler", baglan); // 
            SqlDataReader oku = komut.ExecuteReader();                                      // baglanılan tabloyu sonua kadar oku


            while (oku.Read())                                                           // tablo okunduğu müdettçe dön
            {
                ListViewItem ekle = new ListViewItem();

                ekle.Text = oku["UyeNo"].ToString();
                ekle.SubItems.Add(oku["UyeAdi"].ToString());
                ekle.SubItems.Add(oku["UyeSoyadi"].ToString());
                ekle.SubItems.Add(oku["UyeBorcu"].ToString());

                listView1.Items.Add(ekle);
            }
            baglan.Close();
        }
        private void odemeGecmisiniGoster()
        {
            listView2.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select * from Odemeler", baglan); // 
            SqlDataReader oku = komut.ExecuteReader();                                      // baglanılan tabloyu sonua kadar oku


            while (oku.Read())                                                           // tablo okunduğu müdettçe dön
            {
                ListViewItem ekle = new ListViewItem();

                ekle.Text = oku["OdemeID"].ToString();
                ekle.SubItems.Add(oku["OdemeTarihi"].ToString());
                ekle.SubItems.Add(oku["OdemeTutari"].ToString());
                listView2.Items.Add(ekle);
            }
            baglan.Close();
        }
        private void BtnArama_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select * from Uyeler where UyeNo ='" + textBox6.Text.ToString() + "' or UyeAdi ='" + textBox6.Text.ToString() + "' or UyeSoyadi = '" + textBox6.Text.ToString() + "'", baglan); // aynı ad ve soyadtan üye var mı kontrol ediliyor
            SqlDataReader oku = komut.ExecuteReader();                                      // baglanılan tabloyu sonua kadar oku

            while (oku.Read())                                                           // tablo okunduğu müdettçe dön
            {
                ListViewItem ekle = new ListViewItem();

                ekle.Text = oku["UyeNo"].ToString();
                ekle.SubItems.Add(oku["UyeAdi"].ToString());
                ekle.SubItems.Add(oku["UyeSoyadi"].ToString());
                ekle.SubItems.Add(oku["UyeBorcu"].ToString());
                listView1.Items.Add(ekle);
            }

            baglan.Close();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            idUye = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            LblAd_Soyad.Text = listView1.SelectedItems[0].SubItems[1].Text.Trim() + " " + listView1.SelectedItems[0].SubItems[2].Text.Trim();
            uyeborcu = Convert.ToDouble(listView1.SelectedItems[0].SubItems[3].Text.Trim());
            odemeGecmisiniGoster();
            if (uyeborcu > 0)
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Text = uyeborcu.ToString();
            }
            else
            {
                MessageBox.Show("Üyenin borcu bulunmamaktadır.");
                 textBox1.Text = "";
                 textBox2.Text = "";
                textBox3.Text = "";
                LblAd_Soyad.Text = "Üye Seçiniz....";
             }

        }

        private void uyeBorcunuGuncelle()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand(@"update Uyeler 
                                               set
                                               UyeBorcu ='" + uyeborcu + "' where UyeNo =" + idUye + "", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                BtnEkle.Enabled = true;

                baglan.Open();
                SqlCommand komut = new SqlCommand(@"insert into Odemeler 
                            (Uye_id, OdemeTarihi, OdemeTutari)
                            VALUES 
                            ('" + idUye + "','" + textBox2.Text.ToString().Trim() + "','" + textBox1.Text.ToString().Trim() + "')", baglan);

                komut.ExecuteNonQuery();
                baglan.Close();
                uyeborcu = uyeborcu - Convert.ToDouble(textBox1.Text.ToString());  // odenen tutar, uye borcundan düşülüyor
                textBox3.Text = uyeborcu.ToString(); // kalan borç
            }

            uyeBorcunuGuncelle();
            odemeGecmisiniGoster();
            verileriGoster();

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            LblAd_Soyad.Text = "Üye Seçiniz....";
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            BtnEkle.Enabled = false;

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox2.Text= dateTimePicker1.Value.ToShortDateString();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            BtnArama_Click(sender, e);
        }
    }
}
