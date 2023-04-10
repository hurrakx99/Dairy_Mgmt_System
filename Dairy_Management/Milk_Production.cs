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
    public partial class Milk_Production : Form
    {
        public Milk_Production()
        {
            InitializeComponent();
        }
        private void label13_Click(object sender, EventArgs e)
        {
            Health ob = new Health();
            ob.Show();
            this.Hide();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            Finance ob = new Finance();
            ob.Show();
            this.Hide();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            Dashboard ob = new Dashboard();
            ob.Show();
            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            Manage_Buffalo ob = new Manage_Buffalo();
            ob.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Milk_Sales ob = new Milk_Sales();
            ob.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Product_Details ob=new Product_Details();
            ob.Show();
            this.Hide();
        }

        private void Milk_Production_Load(object sender, EventArgs e)
        {
            disp_data1();
        }
        float qty;
        int total3 = 0, total5 = 0, balance= 0, Paid2=0;
        string Paid1, total4;
        float total1 = 0;
        float total2 = 0;
        float price = 0;
        float fat = 0;
        float Bmilktotal = 0, Cmilktotal = 0;
        float Buffalomilktotal = 0, Cowmilktotal = 0;
        string Bmilk1 , Cmilk1,Buffalomilk,Cowmilk ;
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8AE0HFD;Initial Catalog=Dairy_Management;Integrated Security=True;Pooling=False");
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
        private void FillName()
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
         private void GetData()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select Bmilk,Cmilk,Total,Paid from SupplierTb2 where Name=@Name", con);
            cmd.Parameters.AddWithValue("@Name", NameCb.SelectedValue.ToString());
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Bmilk1 = reader["Bmilk"].ToString();
                Cmilk1 = reader["Cmilk"].ToString();
                total4 = reader["Total"].ToString();
                Paid1 = reader["Paid"].ToString();
            }
            else
            {
                MessageBox.Show("No Data Found");
            }
            con.Close();

        }
         private void GetMilkData()
         {
             con.Open();
             SqlCommand cmd = new SqlCommand("select Buffalo_Milk,Cow_Milk from MilkTb1", con);
             SqlDataReader reader;
             reader = cmd.ExecuteReader();
             if (reader.Read())
             {
                 Buffalomilk = reader["Buffalo_Milk"].ToString();
                 Cowmilk = reader["Cow_Milk"].ToString();
             }
             else
             {
                 MessageBox.Show("No Data Found");
             }
             con.Close();

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
                }

            }
            addSupplier();
        }
        public void addSupplier()
        {
            total3 = Convert.ToInt32(total1) + Convert.ToInt32(total2);
            total5 = total3 + Convert.ToInt32(total4);
            if (CmilkTb.Text != "")
            {
                Cmilktotal = float.Parse(Cmilk1) + float.Parse(CmilkTb.Text);
            }
            if (BmilkTb.Text != "")
            {
                Bmilktotal = float.Parse(Bmilk1) + float.Parse(BmilkTb.Text);
            }
            if (CmilkTb.Text == "")
            {
                Cmilktotal = float.Parse(Cmilk1);
            }
            if (BmilkTb.Text == "")
            {
                Bmilktotal = float.Parse(Bmilk1);
            }
            if (PaidTb.Text != "")
            {
                Paid2 = Convert.ToInt32(Paid1) + int.Parse(PaidTb.Text);
                balance = total5 - Convert.ToInt32(Paid2);
            }
            if (PaidTb.Text == "")
            {
                balance = total5;
            }
            con.Open();
            string query = ("update SupplierTb2 set Bmilk=@Bmilk, Cmilk=@Cmilk, Bmilkfat=@Bmilkfat, Cmilkfat=@Cmilkfat, Total=@Total, Paid=@Paid, Balance=@Balance where Name='"+NameCb.SelectedValue.ToString()+"'");
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Bmilk", Bmilktotal);
            cmd.Parameters.AddWithValue("@Cmilk", Cmilktotal);
            cmd.Parameters.AddWithValue("@Bmilkfat", BmilkfatTb.Text);
            cmd.Parameters.AddWithValue("@Cmilkfat", CmilkfatTb.Text);
            cmd.Parameters.AddWithValue("@Total", total5);
            cmd.Parameters.AddWithValue("@Paid", Paid2);
            cmd.Parameters.AddWithValue("@Balance", balance);
            cmd.ExecuteNonQuery();
            con.Close();
            addMilk();
        }
        public void addMilk()
        {
            if (BmilkTb.Text != "")
            {
                Buffalomilktotal = float.Parse(Buffalomilk) + float.Parse(BmilkTb.Text);
            }
            if (CmilkTb.Text != "")
            {
                Cowmilktotal = float.Parse(Cowmilk) + float.Parse(CmilkTb.Text);
            }
            if (BmilkTb.Text == "")
            {
                Buffalomilktotal = float.Parse(Buffalomilk);
            }
            if (CmilkTb.Text == "")
            {
                Cowmilktotal = float.Parse(Cowmilk);
            }
            con.Open();
            string query = "update MilkTb1 set Buffalo_Milk=@Bmilk,Cow_Milk=@Cmilk";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Bmilk", Buffalomilktotal);
            cmd.Parameters.AddWithValue("@Cmilk", Cowmilktotal);
            cmd.ExecuteNonQuery();
            con.Close();
            expenditure();
            disp_data1();
        }
        public void expenditure()
        {
            total3 = Convert.ToInt32(total1) + Convert.ToInt32(total2);
            total5 = total3 + Convert.ToInt32(total4);
            if (PaidTb.Text != "")
            {
                Paid2 = Convert.ToInt32(Paid1) + int.Parse(PaidTb.Text);
                balance = total5 - Convert.ToInt32(Paid2);
            }
            if (PaidTb.Text == "")
            {
                balance = total5;
            }
            con.Open();
            string query = ("update ExpenditureTb1 set Total=@Total, Paid=@Paid, Balance=@Balance  where Name='" + NameCb.SelectedValue.ToString() + "'");
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Total", total5);
            cmd.Parameters.AddWithValue("@Paid", Paid2);
            cmd.Parameters.AddWithValue("@Balance", balance);
            cmd.ExecuteNonQuery();
            con.Close();
            clearData();
            MessageBox.Show("Milk added");
        }
        

        private void label5_Click(object sender, EventArgs e)
        {
            Login ob = new Login();
            this.Close();
            ob.Show();
        }
        public void clearData()
        {
            BmilkTb.Text = "";
            PaidTb.Text = "";
            CmilkTb.Text = "";
            BmilkfatTb.Text = "";
            CmilkfatTb.Text = "";
            BmilkCb.Checked = false;
            CmilkCb.Checked = false;

        }

        private void NameCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetData();
        }

        private void NameCb_MouseClick(object sender, MouseEventArgs e)
        {
            FillName();
            GetMilkData();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BmilkfatTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            button2.Enabled = true;
        }

        private void CmilkfatTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            button2.Enabled = true;
        }


        
    }
}
