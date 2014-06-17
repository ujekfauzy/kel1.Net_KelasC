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
    public partial class DataPemeriksaan : Form
    {
        public DataPemeriksaan()
        {
            InitializeComponent();
        }

        private void DataPemeriksaan_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            PasienController pc = new PasienController();
            IEnumerable<Patient> hasil = pc.showData();

            dataGridView1.DataSource = hasil.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PeriksaController pc = new PeriksaController();
            IEnumerable<Periksa> hasil = pc.showPemeriksaan();
            dataGridView2.DataSource = hasil.ToList();
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
                    textBox3.Text = row.Cells[1].Value.ToString();
                }
                else //if (row.Cells[1].Value == null)
                {

                    textBox3.Text = "";
                }
                
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[2].Value.ToString();
                textBox3.Text = row.Cells[1].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
                comboBox1.Text = row.Cells[5].Value.ToString();
                textBox6.Text = row.Cells[4].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (HospitalEntities context = new HospitalEntities())
            {
                int result = (int)(context.GetNewPeriksaId().FirstOrDefault());
                if (result > -1)
                {
                    try
                    {
                        Periksa p = new Periksa()
                        {
                            No_Pemeriksaan = result,
                            id_Pegawai = System.Convert.ToInt32(textBox3.Text),
                            id_Pasien = System.Convert.ToInt32(textBox2.Text),
                            Penyakit_Akhir = textBox4.Text,
                            Tarif = System.Convert.ToInt32(textBox6.Text),
                            Status_Rawat = comboBox1.Text
                        };
                        PeriksaController rc = new PeriksaController();
                        rc.addPemeriksaan(p);
                    }
                    catch (FormatException fe)
                    {
                        MessageBox.Show("Data Harus teriisi semua");
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Periksa p = new Periksa()
                {
                    No_Pemeriksaan = System.Convert.ToInt32(textBox1.Text),
                    id_Pegawai = System.Convert.ToInt32(textBox3.Text),
                    id_Pasien = System.Convert.ToInt32(textBox2.Text),
                    Penyakit_Akhir = textBox4.Text,
                    Tarif = System.Convert.ToInt32(textBox6.Text),
                    Status_Rawat = comboBox1.Text
                };
                PeriksaController rc = new PeriksaController();
                rc.Update(p);
            }
            catch (FormatException fe)
            {
                MessageBox.Show("Data harus teriisi semua");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
