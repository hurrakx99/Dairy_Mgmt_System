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
    public partial class Dashboard : Form
    {
     
        public Dashboard()
        {
            InitializeComponent();
        }
        float qty;
        int total = 0, balance = 0;
        float total1 = 0;
        float total2 = 0;
        float price = 0;
        float fat = 0;
       int Bmilkcost;
        int Cmilkcost ;
        private void label11_Click_1(object sender, EventArgs e)
        {
            Milk_Sales ob = new Milk_Sales();
            ob.Show();
            this.Hide();
        }

        private void label12_Click_1(object sender, EventArgs e)
        {
            Milk_Production ob = new Milk_Production();
            ob.Show();
            this.Hide();
        }

        private void label13_Click_1(object sender, EventArgs e)
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

        private void label16_Click(object sender, EventArgs e)
        {
            Finance ob = new Finance();
            ob.Show();
            this.Hide();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8AE0HFD;Initial Catalog=Dairy_Management;Integrated Security=True;Pooling=False");
        public void addSupplier1()
        {
            try{
            total = Convert.ToInt32(total1) + Convert.ToInt32(total2);
            con.Open();
            string query = "Insert into SupplierTb1(Name,Bmilk,Cmilk,Bmilkfat,Cmilkfat,Bmilk_cost,Cmilk_cost,Total)values(@Name,@Bmilk,@Cmilk,@Bmilkfat,@Cmilkfat,@Bmilk_cost,@Cmilk_cost,@Total) ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Name", NameTb1.Text);
            cmd.Parameters.AddWithValue("@Bmilk",float.Parse(BmilkTb.Text));
            cmd.Parameters.AddWithValue("@Cmilk", float.Parse(CmilkTb.Text));
            cmd.Parameters.AddWithValue("@Bmilkfat", BmilkfatTb.Text);
            cmd.Parameters.AddWithValue("@Cmilkfat", CmilkfatTb.Text);
            cmd.Parameters.AddWithValue("@Bmilk_cost",Bmilkcost);
            cmd.Parameters.AddWithValue("@Cmilk_cost",Cmilkcost);
            cmd.Parameters.AddWithValue("@Total",total);
            cmd.ExecuteNonQuery();
            con.Close();
            addSupplier2();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
        public void addSupplier2()
        {
            try
            {
            total = Convert.ToInt32(total1) + Convert.ToInt32(total2);
            if (PaidTb.Text != "")
            {
                balance = total - int.Parse(PaidTb.Text);
            }
            if (PaidTb.Text == "")
            {
                balance = total;
            }
            con.Open();
            string query = "Insert into SupplierTb2(Name,Bmilk,Cmilk,Bmilkfat,Cmilkfat,Bmilk_cost,Cmilk_cost,Total,Paid,Balance)values(@Name,@Bmilk,@Cmilk,@Bmilkfat,@Cmilkfat,@Bmilk_cost,@Cmilk_cost,@Total,@Paid,@Balance) ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Name", NameTb1.Text);
            cmd.Parameters.AddWithValue("@Bmilk", float.Parse(BmilkTb.Text));
            cmd.Parameters.AddWithValue("@Cmilk", float.Parse(CmilkTb.Text));
            cmd.Parameters.AddWithValue("@Bmilkfat", BmilkfatTb.Text);
            cmd.Parameters.AddWithValue("@Cmilkfat", CmilkfatTb.Text);
            cmd.Parameters.AddWithValue("@Bmilk_cost", Bmilkcost);
            cmd.Parameters.AddWithValue("@Cmilk_cost",Cmilkcost);
            cmd.Parameters.AddWithValue("@Total", total);
            cmd.Parameters.AddWithValue("@Paid", PaidTb.Text);
            cmd.Parameters.AddWithValue("@Balance", balance);
            cmd.ExecuteNonQuery();
            con.Close();
            addexpenditure();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void addexpenditure()
        {
            try
            {
                total = Convert.ToInt32(total1) + Convert.ToInt32(total2);
                if (PaidTb.Text != "")
                {
                    balance = total - int.Parse(PaidTb.Text);
                }
                if (PaidTb.Text == "")
                {
                    balance = total;
                }
                con.Open();
                string query = "Insert into expenditureTb1(Name,Total,Paid,Balance)values(@name,@total,@paid,@balance) ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", NameTb1.Text);
                cmd.Parameters.AddWithValue("@total", total);
                cmd.Parameters.AddWithValue("@paid", PaidTb.Text);
                cmd.Parameters.AddWithValue("@balance",balance);
                cmd.ExecuteNonQuery();
                con.Close();
                disp_data1();
                addMilk();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            
            if (BmilkCb.Checked)
            {
                
                    if (BmilkTb.Text == "")
                    {
                        MessageBox.Show("Enter Buffalo milk litre");
                    }

                    if (BmilkfatTb.Text == "")
                    {
                        MessageBox.Show("Enter Buffalo milk fat");
                    }
                    else
                    {
                        fat = 100 / float.Parse(BmilkfatTb.Text);
                        price = 4000 / fat;
                        qty = float.Parse(BmilkTb.Text);
                        total1 = price * qty;
                        Bmilkcost = 45;
                    }
              
            }
            if (CmilkCb.Checked)
            {
                
                    if (CmilkTb.Text == "")
                    {
                        MessageBox.Show("Enter Cow milk litre");
                    }

                    if (CmilkfatTb.Text == "")
                    {
                        MessageBox.Show("Enter Cow milk fat");
                    }
                    else
                    {
                        fat = 100 / float.Parse(CmilkfatTb.Text);
                        price = 3500 / fat;
                        qty = float.Parse(CmilkTb.Text);
                        total2 = price * qty;
                        Cmilkcost = 35;
                    }
                
            }
            addSupplier1();
        }
        public void disp_data1()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = new CommandType();
            cmd.CommandText = "select * from SupplierTb2";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }
        public void addMilk()
        {
            try{
            con.Open();
            string query = "Insert into MilkTb1(Buffalo_Milk,Cow_Milk,Curd,Paneer,Butter,Ghee)values(@Bmilk,@Cmilk,@Curd,@Paneer,@Butter,@Ghee) ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Bmilk", float.Parse(BmilkTb.Text));
            cmd.Parameters.AddWithValue("@Cmilk", float.Parse(CmilkTb.Text));
            cmd.Parameters.AddWithValue("@Curd",0);
            cmd.Parameters.AddWithValue("@Paneer",0);
            cmd.Parameters.AddWithValue("@Butter", 0);
            cmd.Parameters.AddWithValue("@Ghee", 0);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("New Supplier Added");
            disp_data1();
            clearData();
             }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Dashboard_Load(object sender, EventArgs e)
        {
            disp_data1();
        
        }
        private void Deletebtn_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "Delete from  SupplierTb2 where Name='" + NameCb.SelectedValue.ToString() + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                Deletefinance();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
        public void Deletefinance()
        {
            try
            {
                con.Open();
                string query = "Delete from expenditureTb1 where Name='" + NameCb.SelectedValue.ToString() + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record deleted successfully");
                con.Close();
                disp_data1();
                clearData();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void clearData()
        {
            NameTb1.Text = "";
            NameTb1.Text = "";
            BmilkTb.Text = "";
            BmilkfatTb.Text = "";
            CmilkTb.Text = "";
            CmilkfatTb.Text = "";
            PaidTb.Text = "";
            BmilkCb.Checked = false;
            CmilkCb.Checked = false;

        }
        private void GetName()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select Name from SupplierTb2", con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Load(Rdr);
            NameCb.ValueMember = "Name";
            NameCb.DataSource = dt;
            con.Close();
        }

        private void Clearbtn_Click(object sender, EventArgs e)
        {
            clearData();
        }

        private void NameCb_MouseHover(object sender, EventArgs e)
        {
            GetName();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Login ob = new Login();
            this.Hide();
            ob.Show();
        }
        private void pictureBox12_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

    }
}
