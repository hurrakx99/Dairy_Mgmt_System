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
    public partial class Forgot_Password : Form
    {
        public Forgot_Password()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
   
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8AE0HFD;Initial Catalog=Dairy_Management;Integrated Security=True;Pooling=False");
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from LoginTb1 where username='" +usernametb2.Text.Trim()+ "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dtb1 = new DataTable();
                if (dr.Read())
                {
                    usernametb2.Enabled = false;
                    con.Close();  
                    MessageBox.Show("User is verified");
                    passwordtb1.Enabled = true;
                    passwordtb2.Enabled = true;
                    button1.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Such user not exist");
                }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            String password = passwordtb1.Text;
            String cpassword = passwordtb2.Text;
            if (password == "")
            {
                MessageBox.Show("Enter a New Password");
            }
            else if (password == "")
            {
                MessageBox.Show("Enter a confirm Password");
            }
            else if (password != cpassword)
            {
                MessageBox.Show("Does not match");
            }
            else if (password.Length<8)
            {
                MessageBox.Show("Password must have 8 character");
            }
            else 
            {
                try
                {

                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update LoginTb1 set password='" + passwordtb1.Text.Trim() + "' where username='" + usernametb2.Text + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Password successfully Updated");
                    Login ob = new Login();
                    ob.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Login ob = new Login();
            ob.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
