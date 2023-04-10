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
    public partial class Finance : Form
    {
        public Finance()
        {
            InitializeComponent();
            disp_data1();
            disp_data2();
            disp_data3();
        }
        string Paid,balance,total;
        int Paid2=0,balance2=0;
        private void label11_Click(object sender, EventArgs e)
        {
            Milk_Sales ob = new Milk_Sales();
            ob.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Milk_Production ob = new Milk_Production();
            ob.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Health ob = new Health();
            ob.Show();
            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            Manage_Buffalo ob = new Manage_Buffalo();
            ob.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Product_Details ob = new Product_Details();
            ob.Show();
            this.Hide();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            Dashboard ob = new Dashboard();
            ob.Show();
            this.Hide();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            Login ob = new Login();
            this.Hide();
            ob.Show();
            
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8AE0HFD;Initial Catalog=Dairy_Management;Integrated Security=True;Pooling=False");
        public void disp_data1()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = new CommandType();
            cmd.CommandText = "select * from expenditureTb1";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }
        public void disp_data2()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = new CommandType();
            cmd.CommandText = "select * from ExpenditureTb2";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            healthdatagridView.DataSource = dt;
            con.Close();

        }
        public void disp_data3()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = new CommandType();
            cmd.CommandText = "select * from ProductAmtTb1";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();

        }
        private void FillName()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select Name from expenditureTb1", con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Load(Rdr);
            NameCb.ValueMember = "Name";
            NameCb.DataSource = dt;
            con.Close();
        }
        private void GetData()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select Total, Paid, Balance from expenditureTb1 where Name=@Name", con);
            cmd.Parameters.AddWithValue("@Name", NameCb.SelectedValue.ToString());
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                total = reader["Total"].ToString();
                Paid = reader["Paid"].ToString();
                balance = reader["Balance"].ToString();
            }
            else
            {
                MessageBox.Show("No Data Found");
            }
            con.Close();

        }
        private void button4_Click(object sender, EventArgs e)
        {
            expenditure();
        }

        private void NameCb_MouseEnter(object sender, EventArgs e)
        {
            FillName();
        }
        public void expenditure()
        {
            if (PaidTb.Text == "")
            {
                balance2 = Convert.ToInt32(balance);
            }
            Paid2 = Convert.ToInt32(Paid) + int.Parse(PaidTb.Text);
            balance2 = Convert.ToInt32(total) - Convert.ToInt32(Paid2);
            con.Open();
            string query = ("update expenditureTb1 set Paid=@Paid, Balance=@Balance  where Name='" + NameCb.SelectedValue.ToString() + "'");
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Paid", Paid2);
            cmd.Parameters.AddWithValue("@Balance", balance2);
            cmd.ExecuteNonQuery();
            con.Close();
            disp_data1();
            expenditure2();
        }
        public void expenditure2()
        {
            if (PaidTb.Text == "")
            {
                balance2 = Convert.ToInt32(balance);
            }
            Paid2 = Convert.ToInt32(Paid) + int.Parse(PaidTb.Text);
            balance2 = Convert.ToInt32(total) - Convert.ToInt32(Paid2);
            con.Open();
            string query = ("update SupplierTb2  set Paid=@Paid, Balance=@Balance  where Name='" + NameCb.SelectedValue.ToString() + "'");
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Paid", Paid2);
            cmd.Parameters.AddWithValue("@Balance", balance2);
            cmd.ExecuteNonQuery();
            con.Close();
            disp_data1();
            MessageBox.Show("Amount Paid");
            PaidTb.Text = "";
            NameCb.Text = "";
        }
        private void NameCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetData();
        }

        private void Searchbtn_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Finance_Load(object sender, EventArgs e)
        {

        }
      
    }
}
