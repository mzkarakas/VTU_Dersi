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
    public partial class UrunlerFormu : Form
    {
        public UrunlerFormu()
        {
            InitializeComponent();
            verileriGoster();
        }

        int idUrun = 0;

        SqlConnection baglan = new SqlConnection("Data Source = LENOVO; Initial Catalog = SporSalonuDataBase; Integrated Security = True");

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {


                baglan.Open();
                SqlCommand komut = new SqlCommand(@"insert into urunler 
                            (UrunAdi, Fiyat)
                            VALUES 
                            ('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "')", baglan);

                komut.ExecuteNonQuery();
                baglan.Close();
                verileriGoster();
                MessageBox.Show("Yeni ürün eklendi.");
                textBox1.Text = "";
                textBox2.Text = "";
            }
            else
            {
                MessageBox.Show("ürün ismi boş kaydedilemez");
            }
        }

        private void verileriGoster()                                            // yordam oluşturuluyor
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select * from Urunler", baglan); // y
            SqlDataReader oku = komut.ExecuteReader();                                      // baglanılan tabloyu sonua kadar oku

            while (oku.Read())                                                           // tablo okunduğu müddetçe dön
            {
                ListViewItem ekle = new ListViewItem();

                ekle.Text = oku["UrunID"].ToString();
                ekle.SubItems.Add(oku["UrunAdi"].ToString());
                ekle.SubItems.Add(oku["Fiyat"].ToString());
                listView1.Items.Add(ekle);
            }
            baglan.Close();


        }

        private void BtnDuzelt_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand(@"update Urunler 
                                               set
                                               UrunAdi='" + textBox1.Text.ToString() + "', Fiyat ='" + textBox2.Text.ToString() + "' where UrunID =" + idUrun + "", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verileriGoster();
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            idUrun = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[2].Text;
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("ürün kaydını silinecektir. Emin misiniz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (secenek == DialogResult.Yes)
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("Delete from Urunler where UrunID =(" + idUrun + ")", baglan);
                komut.ExecuteNonQuery();
                baglan.Close();
            }
            else if (secenek == DialogResult.No)
            {
            }
            verileriGoster();
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void BtnArama_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select * from Urunler where UrunAdi ='" + textBox1.Text.ToString() + "'", baglan); // ürün adına göre arama yapılıyor
            SqlDataReader oku = komut.ExecuteReader();                                      // baglanılan tabloyu sonua kadar oku

            while (oku.Read())                                                           // tablo okunduğu müdettçe dön
            {
                ListViewItem ekle = new ListViewItem();

                ekle.Text = oku["UrunID"].ToString();
                ekle.SubItems.Add(oku["UrunAdi"].ToString());
                ekle.SubItems.Add(oku["Fiyat"].ToString());
                listView1.Items.Add(ekle);
            }
            baglan.Close();
        }

        private void UrunlerFormu_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // formun kenarlarını sabitleme
        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
