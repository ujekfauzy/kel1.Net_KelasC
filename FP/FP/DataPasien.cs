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
    public partial class DataPasien : Form
    {
        public DataPasien()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (HospitalEntities context = new HospitalEntities())
            {
                int result = (int)(context.GetNewPatientId().FirstOrDefault());
                if (result > -1)
                {
                    try
                    {
                        Patient p = new Patient()
                        {
                            Id_Pasien = result,
                            Nama_Pasien = textBox3.Text,
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
                            ID_Room = System.Convert.ToInt32(textBox1.Text)
                        };


                        PasienController pc = new PasienController();
                        pc.AddPasien(p);

                        //int stat = System.Convert.ToInt32(textBox1.Text);
                        //if (System.Convert.ToInt32(textBox1.Text) != null)
                        //{
                        /*    Kamar k = new Kamar()
                            {
                                Id_Room = System.Convert.ToInt32(textBox1.Text),
                                Status_Kamar = 1
                            };
                         * */
                        RoomController rc = new RoomController();
                        rc.updateStatus(p);
                        //}

                        MessageBox.Show(textBox1.Text);
                    }
                    catch (FormatException fe)
                    {
                        MessageBox.Show("Data harus terisi semua");
                    }
                }
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RoomController rc = new RoomController();
            IEnumerable<Kamar> hasil = rc.showRoom();
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
