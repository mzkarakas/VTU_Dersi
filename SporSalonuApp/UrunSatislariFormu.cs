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
    public partial class UrunSatislariFormu : Form
    {
        public UrunSatislariFormu()
        {
            InitializeComponent();
            groupBox1.Enabled = false;
   
       
        }
        int idUye = 0, idSatis=0;
        string filtre = "UrunAdi";
        double toplamtutar = 0, uyeborcu = 0;
   

        SqlConnection baglan = new SqlConnection("Data Source = LENOVO; Initial Catalog = SporSalonuDataBase; Integrated Security = True");

        private void UrunSatislariFormu_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'uyereSatisDataSet.Urunler' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.urunlerTableAdapter.Fill(this.uyereSatisDataSet.Urunler);
            uyeleriGoster();
            textBox3.Text = "1"; // adet varsayılan değeri
        }

        private void uyeleriGoster()                                            // yordam oluşturuluyor
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select * from Uyeler", baglan); // yetkili_tanimlama tablosuna baglan komutu gönderiliyor
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

        private void satilanUrunleriGoster()                                            // yordam oluşturuluyor
        {
            listView2.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select * from Satislar where Uye_id='"+idUye+"'", baglan); // yetkili_tanimlama tablosuna baglan komutu gönderiliyor
            SqlDataReader oku = komut.ExecuteReader();                                      // baglanılan tabloyu sonua kadar oku
            while (oku.Read())                                                           // tablo okunduğu müdettçe dön
            {
                ListViewItem ekle = new ListViewItem();


                ekle.Text = oku["SatisID"].ToString();
                ekle.SubItems.Add(oku["UrunAdi"].ToString());
                ekle.SubItems.Add(oku["Fiyat"].ToString());
                ekle.SubItems.Add(oku["Adet"].ToString());
                ekle.SubItems.Add(oku["Tutar"].ToString());
                listView2.Items.Add(ekle);
             //   toplamtutar = toplamtutar + Convert.ToDouble(listView2.Items[0].SubItems[3]);
             }
            baglan.Close();
            textBox7.Text = toplamtutar.ToString();
            textBox9.Text = toplamtutar.ToString();

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
                baglan.Open();
                SqlCommand komut = new SqlCommand(@"insert into Satislar 
                            (Uye_id, UrunAdi, Fiyat, Adet, Tutar)
                            VALUES 
                            ('" + idUye + "','" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "')", baglan);

                komut.ExecuteNonQuery();
                baglan.Close();
                toplamtutar += Convert.ToDouble(textBox4.Text.ToString());
                uyeborcu += Convert.ToDouble(textBox4.Text.ToString()); // satılan ürünü üye borcuna ekle
                textBox9.Text = toplamtutar.ToString();
                textBox7.Text = uyeborcu.ToString();
            }

            uyeBorcunuGuncelle();
            satilanUrunleriGoster();
            uyeleriGoster();

            textBox1.Text = "";
            textBox2.Text = "0";
            textBox3.Text = "1";
            textBox4.Text = "0";

        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            groupBox1.Enabled = true;
            idUye = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            LblAd_Soyad.Text = listView1.SelectedItems[0].SubItems[1].Text.Trim() + " " + listView1.SelectedItems[0].SubItems[2].Text.Trim();
            uyeborcu = Convert.ToDouble(listView1.SelectedItems[0].SubItems[3].Text.Trim());
            textBox8.Text = uyeborcu.ToString(); // üyenin varsa önceki borcunu alıyoruz
            satilanUrunleriGoster();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            String filter_str = filtre + " like'" + textBox5.Text + "%'";   // combobox sız filtre
            urunlerBindingSource.Filter = filter_str;
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
         
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox3_TextChanged(sender, e); // tutar otomatik hesaplansın
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

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            BtnArama_Click(sender, e);
        }

        private void listView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            idSatis = int.Parse(listView2.SelectedItems[0].SubItems[0].Text);

            uyeborcu = uyeborcu- Convert.ToDouble(listView2.SelectedItems[0].SubItems[4].Text.ToString()); // borçtan satışı sil
            textBox7.Text = uyeborcu.ToString();            
            baglan.Open();
            SqlCommand komut = new SqlCommand("Delete from Satislar where SatisID =(" + idSatis + ")", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            uyeBorcunuGuncelle();  // satilan ürün silindikten sonra borç günceleniyor
            satilanUrunleriGoster();
            uyeleriGoster();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            double a, b, c;

            a = double.Parse(textBox2.Text);
            if (textBox3.Text.ToString() == null || textBox3.Text.ToString() == "")
            {
                b = double.Parse("1.0");
            }
            else
            {
                b = double.Parse(textBox3.Text);
            }
            c = a * b;
            textBox4.Text = c.ToString();
        }

    }
}
