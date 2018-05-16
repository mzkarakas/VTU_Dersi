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
    public partial class KullaniciGirisFormu : Form
    {
        public KullaniciGirisFormu()
        {
            InitializeComponent();
        }
        YoneticiGirisi yon = new YoneticiGirisi();
        SekreterGirisFormu sek = new SekreterGirisFormu();
        SporAktiviteGunlugu spor = new SporAktiviteGunlugu();

        SqlConnection baglanti = new SqlConnection(@"Data Source=LENOVO;Initial Catalog=SporSalonuDataBase;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
    
            baglanti.Open();
            string sql = "select * from Yetkililer where YetkiliKullaniciAdi=@adi AND YetkiliSifre=@sifre AND YetkiliTuru=@tur";
            SqlParameter prm1 = new SqlParameter("adi", textBox1.Text.Trim()); // kullanici adinda boşlukları yok etmek için trim kullanildi
            SqlParameter prm2 = new SqlParameter("sifre", textBox2.Text.Trim());
            SqlParameter prm3 = new SqlParameter("tur", comboBox1.Text.Trim());
            SqlCommand komut = new SqlCommand(sql, baglanti);      // Yetkililer tablosuna bağlantı kur
            komut.Parameters.Add(prm1);
            komut.Parameters.Add(prm2);
            komut.Parameters.Add(prm3);
            DataTable dt = new DataTable();         // sanal datatablo oluşturuldu
            SqlDataAdapter da = new SqlDataAdapter(komut);      // sql datatablosuna adaptör ve komut  ile bağlanma 
            da.Fill(dt);            // tablonun içini sanal tablo ile dolduruyoruz

            if (dt.Rows.Count > 0)    // sanal tablodaki satırlar ilgili alanla birbirini tutuyor mu
            {
         
                if (comboBox1.Text.ToString() == "Admin")
                {
                    baglanti.Close();
                    this.Hide();
                    yon.ShowDialog();
                }
                if (comboBox1.Text.ToString() == "Sekreter")
                {
                    baglanti.Close();
                    this.Hide();
                    sek.ShowDialog();
                }
                if (comboBox1.Text.ToString() == "Hoca")
                {
                    baglanti.Close();
                    this.Hide();
                    spor.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Kullanici Adi, Şifre ya da Yetki Türü hatali!");
            baglanti.Close();
             }
   

        }

        private void KullaniciGirisFormu_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // TODO: Bu kod satırı 'sporSalonuDataBaseDataSet.Uyeler' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.uyelerTableAdapter.Fill(this.sporSalonuDataBaseDataSet.Uyeler);

        }

        private void KullaniciGirisFormu_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult giriskapanis = MessageBox.Show("Programı kapatmak istediğinizden emin misiniz ? ", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (giriskapanis == DialogResult.No)
            {
                e.Cancel = true;
                return;

            }
            baglanti.Close();
            //   Environment.Exit(0);
                Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void KullaniciGirisFormu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                DialogResult = DialogResult.Cancel;
        }
    }
}
