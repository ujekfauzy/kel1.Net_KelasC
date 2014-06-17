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
    public partial class Login : Form 
    {
        
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminController lg = new AdminController();
            try
            {
                if (lg.SearchID(textBox1.Text, textBox2.Text))
                {
                    this.Hide();
                    var homeform = new home();

                    homeform.Show();
                }
                else
                {
                    MessageBox.Show("username atau password salah");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Eror");
                MessageBox.Show(ex.InnerException.InnerException.Message);
            }
            
            

        }
    }
}
