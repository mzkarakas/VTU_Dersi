using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SporSalonuApp
{
    public partial class SekreterGirisFormu : Form
    {
        public SekreterGirisFormu()
        {
            InitializeComponent();
        }

        private void uyeBilgileriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UyeBilgiGirisFormu frm = new UyeBilgiGirisFormu();
            frm.ShowDialog();
        }

        private void urunGirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UrunlerFormu frm_urun = new UrunlerFormu();
            frm_urun.ShowDialog();
        }

        private void satislarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UrunSatislariFormu frm = new UrunSatislariFormu();
            frm.ShowDialog();
        }

        private void tahsilatarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TahsilatFormu frm = new TahsilatFormu();
            frm.ShowDialog();
        }

        private void SekreterGirisFormu_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult giriskapanis = MessageBox.Show("Programı kapatmak istediğinizden emin misiniz ? ", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (giriskapanis == DialogResult.No)
            {
                e.Cancel = true;
                return;

            }
            Environment.Exit(0);
            //     Application.Exit();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
             Environment.Exit(0);
            //     Application.Exit();
        }
    }
}
