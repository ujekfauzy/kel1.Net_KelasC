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
    public partial class KelolaPasien : Form
    {
        public KelolaPasien()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
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
                textBox2.Text = row.Cells[0].Value.ToString();
                if (row.Cells[1].Value != null)
                {
                    textBox10.Text = row.Cells[1].Value.ToString();
                }
                else
                {
                    
                    textBox10.Text = "";
                }
                //textBox10.Text = row.Cells[1].Value.ToString();
                textBox1.Text = row.Cells[2].Value.ToString();
                textBox3.Text = row.Cells[3].Value.ToString();
                textBox9.Text = row.Cells[4].Value.ToString();
                comboBox3.Text = row.Cells[5].Value.ToString();
                comboBox2.Text = row.Cells[6].Value.ToString();
                comboBox1.Text = row.Cells[7].Value.ToString();
                dateTimePicker2.Text = row.Cells[8].Value.ToString();
                textBox4.Text = row.Cells[9].Value.ToString();
                textBox5.Text = row.Cells[10].Value.ToString();
                textBox8.Text = row.Cells[11].Value.ToString();
                textBox7.Text = row.Cells[12].Value.ToString();
                textBox6.Text = row.Cells[13].Value.ToString();
                dateTimePicker3.Text = row.Cells[14].Value.ToString();
                if (row.Cells[15].Value != null)
                {
                    dateTimePicker4.Text = row.Cells[15].Value.ToString();
                    
                }
                else
                {
                    dateTimePicker4.Text = "";
                }
                if (row.Cells[16].Value != null)
                {
                    textBox11.Text = row.Cells[16].Value.ToString();
                }
                else
                {

                    textBox11.Text = "";
                }
                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Patient p = new Patient()
                {
                    Id_Pasien = System.Convert.ToInt32(textBox2.Text),
                    ID_Pegawai = System.Convert.ToInt32(textBox10.Text),
                    Nama_Pasien = textBox9.Text,
                    Penyakit = textBox9.Text,
                    Jenis_pasien = comboBox3.Text,
                    Golongan_Darah = comboBox2.Text,
                    Jenis_Kelamin = comboBox1.Text,
                    Tgl_Lahir = dateTimePicker2.Value,
                    Alamat_Pasien = textBox4.Text,
                    Kota_Pasien = textBox5.Text,
                    No_KTP = System.Convert.ToInt32(textBox8.Text),
                    No_Hp = System.Convert.ToInt32(textBox7.Text),
                    Pekerjaan = textBox6.Text,
                    Tgl_Masuk = dateTimePicker3.Value,
                    Tgl_Keluar = dateTimePicker4.Value,
                    ID_Room = System.Convert.ToInt32(textBox1.Text),
                    Tarif_total = System.Convert.ToInt32(textBox11.Text)
                };
                PasienController pc = new PasienController();
                pc.updatePasien(p);
            }
            catch (FormatException fe)
            {
                MessageBox.Show("semua data harus terisi");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PegawaiController pc = new PegawaiController();
            IEnumerable<Pegawai> hasil = pc.ShowDokter();
            dataGridView2.DataSource = hasil.ToList();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                textBox10.Text = row.Cells[0].Value.ToString();
                

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                PasienController pc = new PasienController();
                pc.deletePasien(System.Convert.ToInt32(textBox2.Text));
            }
            catch (FormatException fe)
            {
                MessageBox.Show("Pilih Data Yang akan Dihapus");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                Patient p = new Patient()
                {
                    Id_Pasien = System.Convert.ToInt32(textBox2.Text),
                    ID_Room = System.Convert.ToInt32(textBox1.Text)
                };

                RoomController rc = new RoomController();
                rc.updateFreeStatus(p);
            }
            catch (FormatException fe)
            {
                MessageBox.Show("Pilih Pasien yang akan dikeluarkan");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
