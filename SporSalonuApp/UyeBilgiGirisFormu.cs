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
    public partial class UyeBilgiGirisFormu : Form
    {
        public UyeBilgiGirisFormu()
        {
            InitializeComponent();
            verileriGoster();
            ButonlariPasifYap();
            UyeGirisiniPasifYap();

        }

        int idUye = 0;
        int uyeSonId;          //yeni üye kaydi için yeni son üye numarasını belirleme
        string uyeno, ad, soyad, cinsiyet, dtarihi, uyetarihi, telefon, mail;
        int sayac = 0;

            SqlConnection baglan = new SqlConnection("Data Source = LENOVO; Initial Catalog = SporSalonuDataBase; Integrated Security = True");

        private void TextBoxlariTemizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
            maskedTextBox3.Clear();
            textBox4.Clear();
        }

        private void degiskenleriTemizle()
        {
            uyeno = "";
            ad = "";
            soyad = "";
            cinsiyet = "";
            dtarihi = "";
            uyetarihi = "";
            telefon = "";
            mail = "";
        }

        private void ButonlariPasifYap()
        {
            BtnEkle.Enabled = false;
            BtnDuzelt.Enabled = false;
            BtnSil.Enabled = false;
            BtnIptal.Enabled = false;
        }

        private void UyeGirisiniPasifYap()
        {
            textBox1.Enabled=false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            maskedTextBox1.Enabled = false;
            maskedTextBox2.Enabled = false;
            maskedTextBox3.Enabled = false;
            textBox4.Enabled = false;
        }

        private void UyeGirisiniAktifYap()
        {
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            maskedTextBox1.Enabled = true;
            maskedTextBox2.Enabled = true;
            maskedTextBox3.Enabled = true;
            textBox4.Enabled = true;
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            maskedTextBox1.Text = dateTimePicker1.Value.ToShortDateString();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            maskedTextBox2.Text = dateTimePicker2.Value.ToShortDateString();
        }

        // listview de satır çift tıklandığında veriler textboxlara aktrılıyor
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            idUye = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
            maskedTextBox1.Text = listView1.SelectedItems[0].SubItems[4].Text;
            maskedTextBox2.Text = listView1.SelectedItems[0].SubItems[5].Text;
            maskedTextBox3.Text = listView1.SelectedItems[0].SubItems[6].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[7].Text;
            BtnDuzelt.Enabled = true;
            BtnSil.Enabled = true;
            BtnIptal.Enabled = true;
            UyeGirisiniAktifYap();
        }

        private void BtnYeni_Click(object sender, EventArgs e)
        {
            verileriGoster();
            UyeGirisiniAktifYap();
            TextBoxlariTemizle();
            degiskenleriTemizle();
            BtnEkle.Enabled = true;
            BtnIptal.Enabled = true;
            uyeSonId = uyeSonId + 1;    // yeni kayit için son üye Id' sini 1 artırarak yeni üye no yapıyoruz 
            textBox1.Text = uyeSonId.ToString();
        }

        private void UyeBilgiGirisFormu_Load(object sender, EventArgs e)
        {
           // TODO: Bu kod satırı 'sporSalonuDataBaseDataSet.Uyeler' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.uyelerTableAdapter.Fill(this.sporSalonuDataBaseDataSet.Uyeler);
       }

        private void BtnIptal_Click(object sender, EventArgs e)
        {
            TextBoxlariTemizle();
            UyeGirisiniPasifYap();
            ButonlariPasifYap();
            MessageBox.Show("Kayıt İşlemi iptal edildi");
        }

        private void verileriAl()
        {
            uyeno = textBox1.Text.ToString();
            ad = textBox2.Text.ToString();
            soyad = textBox3.Text.ToString();
            if (radioButton1.Checked)
            {
                cinsiyet = radioButton1.Text;
            }
            else
            {
                cinsiyet = radioButton2.Text;
            }
            dtarihi = dateTimePicker1.Value.ToShortDateString();
            uyetarihi = dateTimePicker2.Value.ToShortDateString();
            telefon = maskedTextBox3.Text.ToString();
            mail = textBox4.Text.ToString();
        }

        private void verileriGoster()                                            // yordam oluşturuluyor
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select * from Uyeler", baglan); // yetkili_tanimlama tablosuna baglan komutu gönderiliyor
            SqlDataReader oku = komut.ExecuteReader();                                      // baglanılan tabloyu sonua kadar oku

               
            while (oku.Read())                                                           // tablo okunduğu müdettçe dön
            {
                ListViewItem ekle = new ListViewItem();

                uyeSonId = Convert.ToInt32( oku["UyeId"].ToString());                  // enson UyeID numarasını almak için

                ekle.Text = oku["UyeNo"].ToString();
                ekle.SubItems.Add(oku["UyeAdi"].ToString());
                ekle.SubItems.Add(oku["UyeSoyadi"].ToString());
                ekle.SubItems.Add(oku["UyeCinsiyet"].ToString());
                ekle.SubItems.Add(oku["UyeDogumTarihi"].ToString());
                ekle.SubItems.Add(oku["UyeKayitTarihi"].ToString());
                ekle.SubItems.Add(oku["UyeTelefon"].ToString());
                ekle.SubItems.Add(oku["UyeMail"].ToString());
                listView1.Items.Add(ekle);
             }
            baglan.Close();
            listViewRenklendir();
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

                uyeSonId = Convert.ToInt32(oku["UyeId"].ToString());                  // enson UyeID numarasını almak için

                ekle.Text = oku["UyeNo"].ToString();
                ekle.SubItems.Add(oku["UyeAdi"].ToString());
                ekle.SubItems.Add(oku["UyeSoyadi"].ToString());
                ekle.SubItems.Add(oku["UyeCinsiyet"].ToString());
                ekle.SubItems.Add(oku["UyeDogumTarihi"].ToString());
                ekle.SubItems.Add(oku["UyeKayitTarihi"].ToString());
                ekle.SubItems.Add(oku["UyeTelefon"].ToString());
                ekle.SubItems.Add(oku["UyeMail"].ToString());
                listView1.Items.Add(ekle);
            }

            baglan.Close();
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            BtnArama_Click(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UrunlerFormu frm_urun = new UrunlerFormu();
            frm_urun.ShowDialog();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
    
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        // viewi satırlarını renklendirme
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

        private void uyeAdiKontrolEt(string isim, string soyisim)
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select * from Uyeler where UyeAdi ='"+isim+"' and UyeSoyadi = '"+ soyisim+ "'", baglan); // aynı ad ve soyadtan üye var mı kontrol ediliyor
            SqlDataReader oku = komut.ExecuteReader();                                      // baglanılan tabloyu sonua kadar oku

            sayac = 0;
            while (oku.Read())                                                           // tablo okunduğu müdettçe dön
            {
                ListViewItem ekle = new ListViewItem();

                uyeSonId = Convert.ToInt32(oku["UyeId"].ToString());                  // enson UyeID numarasını almak için

                ekle.Text = oku["UyeNo"].ToString();
                ekle.SubItems.Add(oku["UyeAdi"].ToString());
                ekle.SubItems.Add(oku["UyeSoyadi"].ToString());
                ekle.SubItems.Add(oku["UyeCinsiyet"].ToString());
                ekle.SubItems.Add(oku["UyeDogumTarihi"].ToString());
                ekle.SubItems.Add(oku["UyeKayitTarihi"].ToString());
                ekle.SubItems.Add(oku["UyeTelefon"].ToString());
                ekle.SubItems.Add(oku["UyeMail"].ToString());
                listView1.Items.Add(ekle);
                sayac = sayac + 1;
            }

            baglan.Close();

        }
        private void yeniUyekaydet()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand(@"insert into Uyeler 
                            (UyeNo, UyeAdi, UyeSoyadi, UyeCinsiyet, UyeDogumTarihi, UyeKayitTarihi, UyeTelefon, UyeMail)
                            VALUES 
                            ('" + uyeno + "','" + ad + "','" + soyad + "','" + cinsiyet + "','" + dtarihi + "','" + uyetarihi + "','" + telefon + "','" + mail + "')", baglan);

            komut.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("Yeni üye kaydı oluşturuldu.");
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            verileriGoster();
            verileriAl();
            uyeAdiKontrolEt(textBox2.Text.ToString(), textBox3.Text.ToString());

            if (sayac !=0)
            {
                
                DialogResult secenek = MessageBox.Show("Aynı isimde üye kaydı var. Listeden bilgileri kontrol ediniz. " +
                                                        "Yine de Kaydetmek istiyor musunuz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (secenek == DialogResult.Yes)
                {
                    yeniUyekaydet();
                }
                else if (secenek == DialogResult.No)
                {
                    MessageBox.Show("Kayıt Yapılmadı.");
                }
            }
            else
            {
                yeniUyekaydet();
            }

            

            verileriGoster();
            TextBoxlariTemizle();
            degiskenleriTemizle();
            ButonlariPasifYap();
            UyeGirisiniPasifYap();
        }

        private void BtnDuzelt_Click(object sender, EventArgs e)
        {
            verileriAl();
            baglan.Open();
            SqlCommand komut = new SqlCommand(@"update Uyeler 
                                               set
                                               UyeAdi='" + ad + "', UyeSoyadi ='" + soyad + "', UyeCinsiyet='"+cinsiyet+"', UyeDogumTarihi='"+dtarihi+"', UyeKayitTarihi='"+uyetarihi+"', UyeTelefon = '" + telefon + "', UyeMail='" + mail + "' where UyeNo =" + idUye + "", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();

            verileriGoster();
            TextBoxlariTemizle();
            degiskenleriTemizle();
            ButonlariPasifYap();
            UyeGirisiniPasifYap();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Üye kaydını silinecektir. Emin misiniz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (secenek == DialogResult.Yes)
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("Delete from Uyeler where UyeNo =(" + idUye + ")", baglan);
                komut.ExecuteNonQuery();
                baglan.Close();
            }
            else if (secenek == DialogResult.No)
            {
            }
            verileriGoster();
            TextBoxlariTemizle();
            ButonlariPasifYap();
        }
    }
}
