using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace SporSalonuApp
{
    public partial class YoneticiGirisi : Form
    {
        public YoneticiGirisi()
        {
            InitializeComponent();
            verileriGoster();
            uyeleriGoster();
        }

        int idTc = 0;
        string tcno, ad, soyad, telefon, mail, kullanici, sifre, tur;

        SqlConnection baglan = new SqlConnection("Data Source = LENOVO; Initial Catalog = SporSalonuDataBase; Integrated Security = True");

        private void verileriGoster()                                            // yordam oluşturuluyor
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select * from Yetkililer", baglan); // yetkili_tanimlama tablosuna baglan komutu gönderiliyor
            SqlDataReader oku = komut.ExecuteReader();                                      // baglanılan tabloyu sonua kadar oku

            while (oku.Read())                                                           // tablo okunduğumu müdettçe dön
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["YetkiliTcNo"].ToString();
                ekle.SubItems.Add(oku["YetkiliAdi"].ToString());
                ekle.SubItems.Add(oku["YetkiliSoyadi"].ToString());
                ekle.SubItems.Add(oku["YetkiliTelefon"].ToString());
                ekle.SubItems.Add(oku["YetkiliMail"].ToString());
                ekle.SubItems.Add(oku["YetkiliKullaniciAdi"].ToString());
                ekle.SubItems.Add(oku["YetkiliTuru"].ToString());

                listView1.Items.Add(ekle);
            }
            baglan.Close();
            listViewRenklendir();

        }
        private void verileriAl()
        {
            tcno = textBox1.Text.ToString();
            ad = textBox2.Text.ToString();
            soyad = textBox3.Text.ToString();
            telefon = maskedTextBox1.Text.ToString();
            mail = textBox5.Text.ToString();
            kullanici = textBox6.Text.ToString();
            sifre = textBox7.Text.ToString();
            tur = comboBox1.Text.ToString();
        }

        private void TextBoxlariTemizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            maskedTextBox1.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            comboBox1.Text = "";
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            verileriGoster();
        }

        private void uyeleriGoster()                                            // yordam oluşturuluyor
        {
            listView2.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select * from Uyeler", baglan); // 
            SqlDataReader oku = komut.ExecuteReader();                                      // baglanılan tabloyu sonua kadar oku


            while (oku.Read())                                                           // tablo okunduğu müdettçe dön
            {
                ListViewItem ekle = new ListViewItem();

                ekle.Text = oku["UyeNo"].ToString();
                ekle.SubItems.Add(oku["UyeAdi"].ToString());
                ekle.SubItems.Add(oku["UyeSoyadi"].ToString());
                ekle.SubItems.Add(oku["UyeTelefon"].ToString());
                ekle.SubItems.Add(oku["UyeBorcu"].ToString());
                listView2.Items.Add(ekle);
            }
            baglan.Close();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            verileriAl();
            if (tcno != "")
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand(@"insert into Yetkililer 
                            (YetkiliTcNo, YetkiliAdi, YetkiliSoyadi, YetkiliTelefon, YetkiliMail, YetkiliKullaniciAdi, YetkiliSifre, YetkiliTuru)
                            VALUES 
                            ('" + tcno + "','" + ad + "','" + soyad + "','" + telefon + "','" + mail + "','" + kullanici + "','" + sifre + "','" + tur + "')", baglan);

                komut.ExecuteNonQuery();
                baglan.Close();
                verileriGoster();
                TextBoxlariTemizle();
            }
            else
            {
                MessageBox.Show("T.C. Kimlik No. boş gecilemez. Kayıt Yapılmadı");
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Delete from Yetkililer where YetkiliTcNo =(" + idTc + ")", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verileriGoster();
            TextBoxlariTemizle();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            idTc = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
            maskedTextBox1.Text = listView1.SelectedItems[0].SubItems[3].Text;
            textBox5.Text = listView1.SelectedItems[0].SubItems[4].Text;
            textBox6.Text = listView1.SelectedItems[0].SubItems[5].Text;
            textBox7.Text = listView1.SelectedItems[0].SubItems[6].Text;
  

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            verileriAl();
            baglan.Open();
            SqlCommand komut = new SqlCommand(@"update Yetkililer 
                                               set
                                               YetkiliTcNo ='" + tcno + "', YetkiliAdi='" + ad + "', YetkiliSoyadi ='" + soyad + "', YetkiliTelefon = '" + telefon + "', YetkiliMail='" + mail + "', YetkiliKullaniciAdi ='" + kullanici + "', YetkiliSifre ='" + sifre + "', YetkiliTuru='" + tur + "'  " +
                                               "where YetkiliTcNo =" + idTc + "", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verileriGoster();
            TextBoxlariTemizle();

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //textBoxa metin girişini engelledik.
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }

            //textBoxa girilecek karakter sayısını 11 ile sınırladık
            if (textBox1.TextLength == 11)
            {
                e.Handled = true;
            }

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //textBoxa rakam girişini engelledik
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
            if (textBox2.TextLength == 20)
            {
                e.Handled = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void YoneticiGirisi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                DialogResult = DialogResult.Cancel;

                baglan.Close();
                Application.Exit();
        }

        private void YoneticiGirisi_Load(object sender, EventArgs e)
        {

        }

        private void YoneticiGirisi_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult giriskapanis = MessageBox.Show("Programı kapatmak istediğinizden emin misiniz ? ", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (giriskapanis == DialogResult.No)
            {
                e.Cancel = true;
                return;

            }
            baglan.Close();
            Environment.Exit(0);
         //   Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select * from Uyeler where UyeBorcu !='"+0+"'", baglan); // 
            SqlDataReader oku = komut.ExecuteReader();                                      // baglanılan tabloyu sonua kadar oku


            while (oku.Read())                                                           // tablo okunduğu müdettçe dön
            {
                ListViewItem ekle = new ListViewItem();

                ekle.Text = oku["UyeNo"].ToString();
                ekle.SubItems.Add(oku["UyeAdi"].ToString());
                ekle.SubItems.Add(oku["UyeSoyadi"].ToString());
                ekle.SubItems.Add(oku["UyeTelefon"].ToString());
                ekle.SubItems.Add(oku["UyeBorcu"].ToString());
                listView2.Items.Add(ekle);
            }
            baglan.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            uyeleriGoster();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            BtnArama_Click(sender, e);
        }

        private void BtnArama_Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select * from Uyeler where UyeNo ='" + textBox4.Text.ToString() + "' or UyeAdi ='" + textBox4.Text.ToString() + "' or UyeSoyadi = '" + textBox4.Text.ToString() + "'", baglan); // aynı ad ve soyadtan üye var mı kontrol ediliyor
            SqlDataReader oku = komut.ExecuteReader();                                      // baglanılan tabloyu sonua kadar oku

            while (oku.Read())                                                           // tablo okunduğu müdettçe dön
            {
                ListViewItem ekle = new ListViewItem();

                ekle.Text = oku["UyeNo"].ToString();
                ekle.SubItems.Add(oku["UyeAdi"].ToString());
                ekle.SubItems.Add(oku["UyeSoyadi"].ToString());
                ekle.SubItems.Add(oku["UyeTelefon"].ToString());
                ekle.SubItems.Add(oku["UyeBorcu"].ToString());
                listView2.Items.Add(ekle);
            }

            baglan.Close();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
            if (textBox3.TextLength == 20)
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox5.TextLength == 30)
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox6.TextLength == 20)
            {
                e.Handled = true;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (textBox7.TextLength == 20)
            {
                e.Handled = true;
            }
        }

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
            if (maskedTextBox1.TextLength == 10)
            {
                e.Handled = true;
            }
        }

        private void listViewRenklendir()
        {
            ListView listView = this.listView1;
            int i = 0;
            Color renk = Color.FromArgb(240, 240, 240);
            foreach (ListViewItem item in listView.Items)
            {
                if (i++ % 2 == 1)
                {
                    item.BackColor = Color.LightBlue;
                    item.UseItemStyleForSubItems = true;
                }
                else
                {
                    item.BackColor = Color.Khaki;
                    item.UseItemStyleForSubItems = true;
                }
            }
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.Checked)
                {
                    item.ForeColor = Color.White;
                    item.BackColor = Color.Red;
                }
                else
                {
                    item.ForeColor = Color.SteelBlue;
                    item.BackColor = Color.White;
                }
            }
        }
    }
}
