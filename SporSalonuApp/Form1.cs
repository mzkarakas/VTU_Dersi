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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source = LENOVO; Initial Catalog = SporSalonuDataBase; Integrated Security = True");

        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand(@"insert into deneme 
                            (UyeTcNo, UyeAdi, UyeSoyadi, UyeTelefon, UyeMail,UyeTarih)
                            VALUES 
                            ('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "','"+ dateTimePicker1.Value.ToShortDateString()+"')", baglan);

            komut.ExecuteNonQuery();
            baglan.Close();
        }
    }
}
