using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Dairy_Management
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor=Color.FromArgb(100,0,0,0);
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8AE0HFD;Initial Catalog=Dairy_Management;Integrated Security=True;Pooling=False");
        private void button1_Click(object sender, EventArgs e)
        {
            if (usernametb1.Text == "")
            {
                MessageBox.Show("Enter username");
            }
            else if (passwordtb1.Text == "")
            {
                MessageBox.Show("Enter password");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "Select * from LoginTb1 where username='" + usernametb1.Text.Trim() + "' and password='" + passwordtb1.Text.Trim() + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    DataTable dtb1 = new DataTable();
                    sda.Fill(dtb1);
                    if (dtb1.Rows.Count == 1)
                    {
                        Milk_Sales ob = new Milk_Sales();
                        this.Hide();
                        ob.Show();
                    }
                    else
                    {
                        MessageBox.Show("Check username and password");
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
          
        }

        private void label4_Click(object sender, EventArgs e)
        {

            Forgot_Password ob = new Forgot_Password();
            ob.Show();
            this.Hide();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        
    }
}
