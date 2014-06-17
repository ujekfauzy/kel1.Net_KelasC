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
    public partial class DataPegawai : Form
    {
        public DataPegawai()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Tambah_Click(object sender, EventArgs e)
        {
            using (HospitalEntities context = new HospitalEntities())
            {
                try
                {
                    int result = (int)(context.GetNewPegawaiId().FirstOrDefault());
                    if (result > -1)
                    {
                        Pegawai p = new Pegawai()
                        {
                            ID_Pegawai = result,
                            Jenis_Pegawai = comboBox1.Text,
                            Nama_Pegawai = textBox2.Text,
                            Alamat_Pegawai = textBox3.Text,
                            Telp_Pegawai = System.Convert.ToInt32(textBox5.Text),
                            Kota = textBox4.Text,
                            Email = textBox6.Text
                        };
                        PegawaiController pc = new PegawaiController();
                        pc.AddPegawi(p);
                    }
                }
                catch (FormatException fe)
                {
                    MessageBox.Show("Data harus terisi semua ");
                }
            }

            textBox1.Clear();
            textBox2.Clear();
            comboBox1.ResetText();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PegawaiController pc = new PegawaiController();
            IEnumerable<Pegawai> hasil = pc.ShowData();
            dataGridView1.DataSource = hasil.ToList();

            textBox1.Clear();
            textBox2.Clear();
            comboBox1.ResetText();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                textBox1.Text = row.Cells[0].Value.ToString();
                comboBox1.Text = row.Cells[1].Value.ToString();
                textBox2.Text = row.Cells[2].Value.ToString();
                textBox3.Text = row.Cells[3].Value.ToString();
                textBox5.Text = row.Cells[4].Value.ToString();
                textBox4.Text = row.Cells[5].Value.ToString();
                textBox6.Text = row.Cells[6].Value.ToString();

            }
 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Pegawai p = new Pegawai()
                {
                    ID_Pegawai = System.Convert.ToInt32(textBox1.Text),
                    Jenis_Pegawai = comboBox1.Text,
                    Nama_Pegawai = textBox2.Text,
                    Alamat_Pegawai = textBox3.Text,
                    Telp_Pegawai = System.Convert.ToInt32(textBox5.Text),
                    Kota = textBox4.Text,
                    Email = textBox6.Text
                };
                PegawaiController pc = new PegawaiController();
                pc.updatePegawai(p);
            }
            catch (FormatException fe)
            {
                MessageBox.Show("Data Harus Terisi semua");
            }
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.ResetText();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                PegawaiController pc = new PegawaiController();
                pc.deletePegawai(System.Convert.ToInt32(textBox1.Text));
            }
            catch (FormatException fe)
            {
                MessageBox.Show("Pilih Data yang akan Dihapus");
            }
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.ResetText();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
