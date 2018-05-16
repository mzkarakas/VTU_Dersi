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
    public partial class SporAktiviteGunlugu : Form
    {
        public SporAktiviteGunlugu()
        {
            InitializeComponent();
            BtnKaydet.Enabled = false;
        }

        string filtre = "UyeAdi";
        bool result = false;
        string gelisTarihi = "";
        int idUye = 0;
        int sporId = 0;
        int sayac = 0;
        string cikis, boy, kilo, gogus, bel, kalca, baldir, bilek, pazu ;
 //       double ucretToplami = 0;

        SqlConnection baglan = new SqlConnection("Data Source = LENOVO; Initial Catalog = SporSalonuDataBase; Integrated Security = True");

        private void SporAktiviteGunlugu_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'sporSalonuDataBaseDataSet.Uyeler' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.uyelerTableAdapter.Fill(this.sporSalonuDataBaseDataSet.Uyeler);
          
        }
        private void verileriGoster()                                            // yordam oluşturuluyor
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select * from SporGunlugu where Uye_id =(" + idUye + ")", baglan); // yetkili_tanimlama tablosuna baglan komutu gönderiliyor
            SqlDataReader oku = komut.ExecuteReader();                                      // baglanılan tabloyu sonua kadar oku
             while (oku.Read())                                                           // tablo okunduğu müdettçe dön
            {
                ListViewItem ekle = new ListViewItem();

                ekle.Text = oku["SporID"].ToString();
                ekle.SubItems.Add(oku["Uye_id"].ToString());
                ekle.SubItems.Add(oku["Tarih"].ToString());
                ekle.SubItems.Add(oku["GelisSaati"].ToString());
                ekle.SubItems.Add(oku["CikisSaati"].ToString());
                ekle.SubItems.Add(oku["Boy"].ToString());
                ekle.SubItems.Add(oku["Kilo"].ToString());
                ekle.SubItems.Add(oku["Gogus"].ToString());
                ekle.SubItems.Add(oku["Bel"].ToString());
                ekle.SubItems.Add(oku["Kalca"].ToString());
                ekle.SubItems.Add(oku["Baldir"].ToString());
                ekle.SubItems.Add(oku["Bilek"].ToString());
                ekle.SubItems.Add(oku["Pazu"].ToString());

                listView1.Items.Add(ekle);
             }
            baglan.Close();
         //   listViewRenklendir();
        }

        private void verileriAl()
        {
            cikis = maskedTextBox10.Text.ToString();
            boy = maskedTextBox1.Text.ToString();
            kilo = maskedTextBox2.Text.ToString();
            gogus = maskedTextBox3.Text.ToString();
            bel = maskedTextBox4.Text.ToString();
            kalca = maskedTextBox5.Text.ToString();
            baldir = maskedTextBox6.Text.ToString();
            bilek = maskedTextBox7.Text.ToString();
            pazu = maskedTextBox8.Text.ToString();

        }

        private void degiskenleriTemizle()
        {
            cikis ="";
            boy = "";
            kilo = "";
            gogus = "";
            bel = "";
            kalca = "";
            baldir = "";
            bilek = "";
            pazu = "";
        }
        private void KontrolEt()
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select * from SporGunlugu where Tarih like '%" + gelisTarihi + "%' and Uye_id =(" + idUye + ")", baglan); // 
            SqlDataReader oku = komut.ExecuteReader();                                      // baglanılan tabloyu sonua kadar oku

            sayac = 0;          // aynı tarihten var mı yok mu kontrol etmek için
            while (oku.Read())                                                           // tablo okunduğu müdettçe dön
            {
                ListViewItem ekle = new ListViewItem();

                ekle.Text = oku["SporID"].ToString();
                ekle.SubItems.Add(oku["Uye_id"].ToString());
                ekle.SubItems.Add(oku["Tarih"].ToString());
                ekle.SubItems.Add(oku["GelisSaati"].ToString());
                ekle.SubItems.Add(oku["CikisSaati"].ToString());
                ekle.SubItems.Add(oku["Boy"].ToString());
                ekle.SubItems.Add(oku["Kilo"].ToString());
                ekle.SubItems.Add(oku["Gogus"].ToString());
                ekle.SubItems.Add(oku["Bel"].ToString());
                ekle.SubItems.Add(oku["Kalca"].ToString());
                ekle.SubItems.Add(oku["Baldir"].ToString());
                ekle.SubItems.Add(oku["Bilek"].ToString());
                ekle.SubItems.Add(oku["Pazu"].ToString());
                listView1.Items.Add(ekle);
                sayac += 1;
            }
            baglan.Close();
            if (sayac != 0)
            {
                result = true;   // aynı tarihten kayıt var 
            }
            else
            {
                result = false; // aynı tarihten kayıt yok
            }
 
            //   listViewRenklendir();
        }


        private void TextBoxlariTemizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
            maskedTextBox3.Clear();
            maskedTextBox4.Clear();
            maskedTextBox5.Clear();
            maskedTextBox6.Clear();
            maskedTextBox7.Clear();
            maskedTextBox8.Clear();
            maskedTextBox9.Clear();
            maskedTextBox10.Clear();
        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            baglan.Close();
            Application.Exit();
        }

        private void BtnIptal_Click(object sender, EventArgs e)
        {
            TextBoxlariTemizle();
            degiskenleriTemizle();
            MessageBox.Show("Kayıt İşlemi iptal edildi");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            String filter_str = filtre + " like'" + textBox1.Text + "%'";   // combobox sız filtre
         //   MessageBox.Show(filter_str);
            uyelerBindingSource.Filter = filter_str;
        }

         private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox2.Text = dateTimePicker1.Value.ToShortDateString();
            maskedTextBox9.Text = dateTimePicker1.Value.ToShortTimeString();
        }

          private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            idUye = (int)dataGridView1.SelectedRows[0].Cells[0].Value; // aynı üye üzerine spor kartı açmak üzere 
            LblAd_Soyad.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString().Trim()+" " + dataGridView1.SelectedRows[0].Cells[2].Value.ToString().Trim();

            verileriGoster();
            BtnKaydet.Enabled = true;

        }

        private void BtnDuzelt_Click(object sender, EventArgs e)
        {
            verileriAl();
            baglan.Open();
            SqlCommand komut = new SqlCommand(@"update SporGunlugu 
                                               set
                                               CikisSaati='" +cikis+ "', Boy ='" +boy+ "', Kilo='" + kilo + "', Gogus='" + gogus+ "', Bel='" +bel+ "', Kalca='" +kalca+ "', Baldir = '"+baldir+ "', Bilek ='" +bilek+ "', Pazu = '" + pazu + "' " +
                                               "where SporID =" + sporId + " ", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();

            verileriGoster();
            TextBoxlariTemizle();
            degiskenleriTemizle();
            textBox2.Enabled = true;
            maskedTextBox9.Enabled = true;
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            gelisTarihi = textBox2.Text.ToString();

            if (gelisTarihi != "")
            {
                KontrolEt();

                if (!result)
                {
                    SporSalonuDataBaseDataSet1.SporGunluguRow ss = sporSalonuDataBaseDataSet1.SporGunlugu.NewSporGunluguRow();
                    ss.Uye_id = idUye;
                    ss.Tarih = textBox2.Text;
                    ss.GelisSaati = maskedTextBox9.Text;
                    ss.CikisSaati = maskedTextBox10.Text;
                    ss.Boy = maskedTextBox1.Text;
                    ss.Kilo = maskedTextBox2.Text;
                    ss.Gogus = maskedTextBox3.Text;
                    ss.Bel = maskedTextBox4.Text;
                    ss.Kalca = maskedTextBox5.Text;
                    ss.Baldir = maskedTextBox6.Text;
                    ss.Bilek = maskedTextBox7.Text;
                    ss.Pazu = maskedTextBox8.Text;
                    sporSalonuDataBaseDataSet1.SporGunlugu.AddSporGunluguRow(ss);
                    sporGunluguTableAdapter.Update(ss);
                    verileriGoster();
                    TextBoxlariTemizle();
                    MessageBox.Show("Başarıyla kaydedildi.");
                }
                else
                {
                    MessageBox.Show("Üyenin " + gelisTarihi + " tarihli girişi vardir. Aynı tarihe kayit yapılamaz.");
                }
            }
            else
            {
                MessageBox.Show("Geliş tarihi boş geçilemez.");
            }
            verileriGoster();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            maskedTextBox10.Text = dateTimePicker2.Value.ToShortTimeString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            sporId = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox2.Text = listView1.SelectedItems[0].SubItems[2].Text;
            maskedTextBox9.Text = listView1.SelectedItems[0].SubItems[3].Text;
            maskedTextBox10.Text = listView1.SelectedItems[0].SubItems[4].Text;
            maskedTextBox1.Text = listView1.SelectedItems[0].SubItems[5].Text;
            maskedTextBox2.Text = listView1.SelectedItems[0].SubItems[6].Text;
            maskedTextBox3.Text = listView1.SelectedItems[0].SubItems[7].Text;
            maskedTextBox4.Text = listView1.SelectedItems[0].SubItems[8].Text;
            maskedTextBox5.Text = listView1.SelectedItems[0].SubItems[9].Text;
            maskedTextBox6.Text = listView1.SelectedItems[0].SubItems[10].Text;
            maskedTextBox7.Text = listView1.SelectedItems[0].SubItems[11].Text;
            maskedTextBox8.Text = listView1.SelectedItems[0].SubItems[12].Text;
            textBox2.Enabled = false;
            maskedTextBox9.Enabled = false;
        }
    }
}
