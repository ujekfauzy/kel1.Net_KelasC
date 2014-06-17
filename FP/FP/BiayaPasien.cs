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
    public partial class BiayaPasien : Form
    {
        public BiayaPasien()
        {
            InitializeComponent();
        }

        private void BiayaPasien_Load(object sender, EventArgs e)
        {

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PasienController pc = new PasienController();
            IEnumerable<Patient> hasil = pc.showData();
            dataGridView1.DataSource = hasil.ToList();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                textBox1.Text = row.Cells[0].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Patient p = new Patient()
                {

                    Id_Pasien = System.Convert.ToInt32(textBox1.Text)
                };
           

            PeriksaController pc = new PeriksaController();
            int hargaPeriksa = pc.TotalPeriksa(p);

            PasienController pac = new PasienController();
            int hari = pac.HariKamar(p);

            RoomController rc = new RoomController();
            int harga = rc.HargaKamar(p);

            int total = hargaPeriksa + (harga * hari);
            textBox2.Text = total.ToString();

            Patient a = new Patient()
            {
                Id_Pasien = System.Convert.ToInt32(textBox1.Text),
                Tarif_total = System.Convert.ToInt32(textBox2.Text)
            };
            //PasienController pc = new PasienController();
            pac.updateTarifPasien(a);
            }
            catch (FormatException)
            {
                MessageBox.Show("Id Harus Terisi");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
