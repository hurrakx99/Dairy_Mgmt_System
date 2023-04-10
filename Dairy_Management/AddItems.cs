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
    public partial class AddItems : Form
    {
        public AddItems()
        {
            InitializeComponent();
            disp_data();
            GetMilkData();
        }
        string Curd, Paneer, Butter, Ghee;
        float curdtotal = 0, paneertotal = 0, buttertotal = 0, gheetotal = 0;
        float qty1, qty2, qty3, qty4;
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8AE0HFD;Initial Catalog=Dairy_Management;Integrated Security=True;Pooling=False");
        public void disp_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = new CommandType();
            cmd.CommandText = "select * from MilkTb1";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView.DataSource = dt;
            con.Close();

        }
        private void GetMilkData()
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("select Curd,Paneer,Butter,Ghee from MilkTb1", con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Curd = reader["Curd"].ToString();
                Paneer = reader["Paneer"].ToString();
                Butter = reader["Butter"].ToString();
                Ghee = reader["Ghee"].ToString();
            }
            else
            {
                MessageBox.Show("No Data Found");
            }
            con.Close();

        }
        private void Addbtn_Click(object sender, EventArgs e)
        {
            if (CurdCb.Checked)
            {
                if (CurdTb.Text == "")
                {
                    MessageBox.Show("Enter Curd value");
                }
                else
                {
                    qty1 = float.Parse(CurdTb.Text);
                }
            }
            if (PaneerCb.Checked)
            {
                if (PaneerTb.Text == "")
                {
                    MessageBox.Show("Enter Paneer value");
                }
                else
                {
                    qty2 = float.Parse(PaneerTb.Text);
                }
            }
            if (ButterCb.Checked)
            {
                if (ButterTb.Text == "")
                {
                    MessageBox.Show("Enter Butter value");
                }
                else
                {
                    qty3 = float.Parse(ButterTb.Text);
                }
            }
            if (GheeCb.Checked)
            {
                if (GheeTb.Text == "")
                {
                    MessageBox.Show("Enter Ghee value");
                }
                else
                {
                    qty4 = float.Parse(GheeTb.Text);
                }
            }
            additems();
        }
        public void additems()
        {
            if (CurdTb.Text != "")
            {
                curdtotal = Convert.ToInt32(Curd) + Convert.ToInt32(qty1);
            }
            if (PaneerTb.Text != "")
            {
                paneertotal = Convert.ToInt32(Paneer) + Convert.ToInt32(qty2);
            }
            if (CurdTb.Text == "")
            {
                curdtotal = Convert.ToInt32(Curd);
            }
            if (PaneerTb.Text == "")
            {
                paneertotal = Convert.ToInt32(Paneer);
            }

            if (ButterTb.Text != "")
            {
                buttertotal = Convert.ToInt32(Butter) + Convert.ToInt32(qty3);
            }
            if (GheeTb.Text != "")
            {
                gheetotal = Convert.ToInt32(Ghee) + Convert.ToInt32(qty4);
            }
            if (ButterTb.Text == "")
            {
                buttertotal = Convert.ToInt32(Butter);
            }
            if (GheeTb.Text == "")
            {
                gheetotal = Convert.ToInt32(Ghee);
            }
            con.Open();
            string query = "update MilkTb1 set Curd=@curd,Paneer=@paneer,Butter=@butter,Ghee=@ghee";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@curd", curdtotal);
            cmd.Parameters.AddWithValue("@paneer", paneertotal);
            cmd.Parameters.AddWithValue("@butter", buttertotal);
            cmd.Parameters.AddWithValue("@ghee", gheetotal);
            cmd.ExecuteNonQuery();
            con.Close();
            disp_data();
            MessageBox.Show("Item Added");
            clearData();
        }
        public void clearData()
        {
            GheeTb.Text = "";
            GheeCb.Checked = false;
            ButterTb.Text = "";
            ButterCb.Checked = false;
            PaneerTb.Text = "";
            PaneerCb.Checked = false;
            CurdCb.Checked = false;
            CurdTb.Text = "";
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Product_Details ob = new Product_Details();
            ob.Show();
            this.Hide();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void CurdTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            Addbtn.Enabled = true;
        }

        private void PaneerTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            Addbtn.Enabled = true;
        }

        private void ButterTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            Addbtn.Enabled = true;
        }

        private void GheeTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            Addbtn.Enabled = true;
        }
    }
}
