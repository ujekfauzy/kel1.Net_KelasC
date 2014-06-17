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
    public partial class dataAdmin : Form
    {
        public dataAdmin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (HospitalEntities context = new HospitalEntities())
            {
                try
                {
                    int result = (int)(context.GetNewAdminId().FirstOrDefault());
                    if (result > -1)
                    {
                        Admin p = new Admin()
                        {
                            Id_Admin = result,
                            Id_pegawai = System.Convert.ToInt32(textBox2.Text),
                            User_name = textBox3.Text,
                            Password = textBox4.Text,

                        };
                        AdminController pc = new AdminController();
                        pc.addAdmin(p);
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Data harus teriisi semua");
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                textBox2.Text = row.Cells[0].Value.ToString();
                

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PegawaiController pc = new PegawaiController();
            IEnumerable<Pegawai> hasil = pc.ShowData();
            dataGridView1.DataSource = hasil.ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AdminController pc = new AdminController();
            IEnumerable<Admin> hasil = pc.ShowData();
            dataGridView2.DataSource = hasil.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Admin p = new Admin()
                {
                    Id_Admin = System.Convert.ToInt32(textBox1.Text),
                    Id_pegawai = System.Convert.ToInt32(textBox2.Text),
                    User_name = textBox3.Text,
                    Password = textBox4.Text,

                };
                AdminController pc = new AdminController();
                pc.updateAdmin(p);
            }
            catch (FormatException fe)
            {
                MessageBox.Show("Data harus terisi semua");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                AdminController pc = new AdminController();
                pc.Delete(System.Convert.ToInt32(textBox1.Text));
            }
            catch (FormatException fe)
            {
                MessageBox.Show("Pilih Data yang akan dipilih");
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
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();


            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
