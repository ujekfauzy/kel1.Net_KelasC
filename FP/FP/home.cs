using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FP
{
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
        }


        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void dataUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var pegawai = new DataPegawai();
            pegawai.Show();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            var pasien = new DataPasien();
            pasien.Show();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            var kelola = new KelolaPasien();
            kelola.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var admin = new dataAdmin();
            admin.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var kamar = new DataKamar();
            kamar.Show();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            var periksa = new DataPemeriksaan();
            periksa.Show();
        }

        private void biayaPasienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var biayaPasien = new BiayaPasien();
            biayaPasien.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.Close();
            var login = new Login() ;
            login.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
