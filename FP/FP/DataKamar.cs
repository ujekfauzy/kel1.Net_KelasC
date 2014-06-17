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
    public partial class DataKamar : Form
    {
        public DataKamar()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RoomController rc = new RoomController();
            IEnumerable<Kamar> hasil = rc.showRoom();
            dataGridView1.DataSource = hasil.ToList();

            textBox1.Clear();
            textBox2.Clear();
            textBox5.Clear();
            comboBox1.ResetText();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (HospitalEntities context = new HospitalEntities())
                {

                    int result = (int)(context.GetNewKamarId().FirstOrDefault());
                    if (result > -1)
                    {
                        Kamar p = new Kamar()
                        {
                            Id_Room = result,
                            Nama_Kamar = textBox2.Text,
                            Harga_Sewa = System.Convert.ToInt32(textBox5.Text),
                            Status_Kamar = System.Convert.ToByte(comboBox1.Text)
                        };
                        RoomController rc = new RoomController();
                        rc.addRoom(p);
                    }
                }
            }
            catch (FormatException fe)
            {
                MessageBox.Show("Data Harus Terisi semua");
            }

            textBox1.Clear();
            textBox2.Clear();
            textBox5.Clear();
            comboBox1.ResetText();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Kamar p = new Kamar()
                {
                    Id_Room = System.Convert.ToInt32(textBox1.Text),
                    Nama_Kamar = textBox2.Text,
                    Harga_Sewa = System.Convert.ToInt32(textBox5.Text),
                    Status_Kamar = System.Convert.ToByte(comboBox1.Text)
                };
                RoomController rc = new RoomController();
                rc.Update(p);
            }
            catch (FormatException fe)
            {
                MessageBox.Show("Data harus teriisi semua");
            }
            textBox1.Clear();
            textBox2.Clear();
            textBox5.Clear();
            comboBox1.ResetText();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox5.Text = row.Cells[2].Value.ToString();
                comboBox1.Text = row.Cells[3].Value.ToString();

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                RoomController rc = new RoomController();
                rc.Delete(System.Convert.ToInt32(textBox1.Text));
                textBox1.Clear();
                textBox2.Clear();
                textBox5.Clear();
                comboBox1.ResetText();
            }
            catch (FormatException fe)
            {
                MessageBox.Show("Pilih Data yang akan dihapus");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
