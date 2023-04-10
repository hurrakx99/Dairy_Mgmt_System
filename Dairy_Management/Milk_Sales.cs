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
    public partial class Milk_Sales : Form
    {
        public Milk_Sales()
        {
            InitializeComponent();
            GetMilkData();
            GetAmtMilkData();
            GetSalesMilkData();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8AE0HFD;Initial Catalog=Dairy_Management;Integrated Security=True;Pooling=False");
        SqlCommand cmd1;
        SqlCommand cmd2;
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
        private void label5_Click(object sender, EventArgs e)
        {
            Login ob= new Login();
            this.Hide();
            ob.Show();
        }
        float total1 = 0, total2 = 0, total3 = 0, total4 = 0, total5 = 0, total6 = 0;
        string Bmilk, Cmilk, Curd, Paneer, Butter, Ghee;
        float bmilktotal = 0, cmilktotal = 0, curdtotal = 0, paneertotal = 0, buttertotal = 0, gheetotal = 0;
        string Bmilk2, Cmilk2, Curd2, Paneer2, Butter2, Ghee2;
        float bmilktotal2 = 0, cmilktotal2 = 0, curdtotal2 = 0, paneertotal2 = 0, buttertotal2 = 0, gheetotal2 = 0;
        string Bmilk3, Cmilk3, Curd3, Paneer3, Butter3, Ghee3;
        float bmilktotal3 = 0, cmilktotal3 = 0, curdtotal3 = 0, paneertotal3 = 0, buttertotal3 = 0, gheetotal3 = 0;
        private void GetMilkData()
        {
            
            con.Open();
            SqlCommand cmd = new SqlCommand("select Buffalo_Milk,Cow_Milk,Curd,Paneer,Butter,Ghee from MilkTb1", con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Bmilk = reader["Buffalo_Milk"].ToString();
                Cmilk = reader["Cow_Milk"].ToString();
                Curd=reader["Curd"].ToString();
                Paneer=reader["Paneer"].ToString();
                Butter=reader["Butter"].ToString();
                Ghee=reader["Ghee"].ToString();
            }
            else
            {
                MessageBox.Show("No Data Found");
            }
            con.Close();

        }
        private void GetAmtMilkData()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select Bmilk_amt,Cmilk_amt,Curd_amt,Paneer_amt,Butter_amt,Ghee_amt from ProductAmtTb1", con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Bmilk2 = reader["Bmilk_amt"].ToString();
                Cmilk2 = reader["Cmilk_amt"].ToString();
                Curd2 = reader["Curd_amt"].ToString();
                Paneer2 = reader["Paneer_amt"].ToString();
                Butter2 = reader["Butter_amt"].ToString();
                Ghee2 = reader["Ghee_amt"].ToString();
            }
            else
            {
                MessageBox.Show("No Data Found");
            }
            con.Close();

        }
        private void GetSalesMilkData()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select Buffalo_Milk,Cow_Milk,Curd,Paneer,Butter,Ghee from MilkSalesTb1", con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Bmilk3 = reader["Buffalo_Milk"].ToString();
                Cmilk3 = reader["Cow_Milk"].ToString();
                Curd3 = reader["Curd"].ToString();
                Paneer3 = reader["Paneer"].ToString();
                Butter3 = reader["Butter"].ToString();
                Ghee3 = reader["Ghee"].ToString();
            }
            else
            {
                MessageBox.Show("No Data Found");
            }
            con.Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            String Item;
            float qty;
            float price = 0;
            if (BmilkCb.Checked)
            {
                Item = "Buffalo Milk";
                qty = float.Parse(BmilkTb.Text);
                price = 45;
                total1 = price*qty;
                this.dataGridView1.Rows.Add(Item, price, qty, total1);
               

            }
            if (CmilkCb.Checked)
            {
                Item = "Cow Milk";
                qty = float.Parse(CmilkTb.Text);
                price = 31;
                total2 = price * qty;
                this.dataGridView1.Rows.Add(Item, price, qty, total2);
                

            }
            if (CurdCb.Checked)
            {
                Item = "Curd";
                qty = float.Parse(CurdTb.Text);
                price = 50;
                total3 = price * qty;
                this.dataGridView1.Rows.Add(Item, price, qty, total3);
                

            }
            if (PaneerCb.Checked)
            {
                Item = "Paneer";
                qty = float.Parse(PaneerTb.Text);
                price = 320;
                total4 = price * qty;
                this.dataGridView1.Rows.Add( Item, price, qty, total4);
              

            }
            if (ButterCb.Checked)
            {
                Item = "Butter";
                qty = float.Parse(ButterTb.Text);
                price = 1450;
                total5 = price * qty;
                this.dataGridView1.Rows.Add( Item, price, qty, total5);
              

            }
            if (GheeCb.Checked)
            {
                Item = "Ghee";
                qty = float.Parse(GheeTb.Text);
                price = 430;
                total6 = price * qty;
                this.dataGridView1.Rows.Add( Item, price, qty, total6);
                
            }
            int sum = 0;
            for (int row = 0; row < dataGridView1.Rows.Count; row++)
            {
                sum=sum+Convert.ToInt32(dataGridView1.Rows[row].Cells[3].Value);
            }
            TotalTb.Text = sum.ToString();
            button2.Enabled = true;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["delete"].Index && e.RowIndex >= 0)
            {
                dataGridView1.Rows.Remove(dataGridView1.Rows[e.RowIndex]);
                int sum = 0;
                for (int row = 0; row < dataGridView1.Rows.Count; row++)
                {
                    sum = sum + Convert.ToInt32(dataGridView1.Rows[row].Cells[3].Value);
                }
                TotalTb.Text = sum.ToString();
            }
        }
        public void save_sales()
        {
            string sql1,sql2;
            sql1 = "Insert into SalesTb2(subtotal)values(@subtotal) select @@identity;";
            con.Open();
            cmd1 = new SqlCommand(sql1,con);
            cmd1.Parameters.AddWithValue("@subtotal",TotalTb.Text);
            int lastinsertid = int.Parse(cmd1.ExecuteScalar().ToString());
            con.Close();



            string proname;
            int price = 0;
            float qty = 0;
            float total = 0;

            for (int row = 0; row < dataGridView1.Rows.Count; row++)
            {
                proname = dataGridView1.Rows[row].Cells[0].Value.ToString();
                price = int.Parse(dataGridView1.Rows[row].Cells[1].Value.ToString());
                qty = float.Parse(dataGridView1.Rows[row].Cells[2].Value.ToString());
                total = float.Parse(dataGridView1.Rows[row].Cells[3].Value.ToString());

                sql2 = "Insert into Sales_productTb1(sales_id,prod_name,price,qty,total)values(@id,@name,@price,@qty,@total) ";
                con.Open();
                cmd2 = new SqlCommand(sql2, con);
                cmd2.Parameters.AddWithValue("@id",lastinsertid);
                cmd2.Parameters.AddWithValue("@name",proname);
                cmd2.Parameters.AddWithValue("@price", price);
                cmd2.Parameters.AddWithValue("@qty", qty);
                cmd2.Parameters.AddWithValue("@total", total);
                cmd2.ExecuteNonQuery();
                con.Close();
                
            }
            MessageBox.Show("Sales Completed...");
            Print ob = new Print();
            ob.SalesID = lastinsertid;
            ob.Show();
            removeMilk();
        }
        public void removeMilk()
        {
            if (CmilkTb.Text != "")
            {
                cmilktotal = float.Parse(Cmilk) - float.Parse(CmilkTb.Text);
            }
            if (BmilkTb.Text != "")
            {
                bmilktotal = float.Parse(Bmilk) - float.Parse(BmilkTb.Text);
            }
            if (CmilkTb.Text == "")
            {
                cmilktotal = float.Parse(Cmilk);
            }
            if (BmilkTb.Text == "")
            {
                bmilktotal = float.Parse(Bmilk);
            }

            if (CurdTb.Text != "")
            {
                curdtotal = float.Parse(Curd) - float.Parse(CurdTb.Text);
            }
            if (PaneerTb.Text != "")
            {
                paneertotal = float.Parse(Paneer) - float.Parse(PaneerTb.Text);
            }
            if (CurdTb.Text == "")
            {
                curdtotal = float.Parse(Curd);
            }
            if (PaneerTb.Text == "")
            {
                paneertotal = float.Parse(Paneer);
            }

            if (ButterTb.Text != "")
            {
                buttertotal = float.Parse(Butter) - float.Parse(ButterTb.Text);
            }
            if (GheeTb.Text != "")
            {
                gheetotal = float.Parse(Ghee) - float.Parse(GheeTb.Text);
            }
            if (ButterTb.Text == "")
            {
                buttertotal = float.Parse(Butter);
            }
            if (GheeTb.Text == "")
            {
                gheetotal = float.Parse(Ghee);
            }
      
                con.Open();
                string query = ("update MilkTb1 set Buffalo_Milk=@Bmilk,Cow_Milk=@Cmilk,Curd=@curd,Paneer=@paneer,Butter=@butter,Ghee=@ghee");
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Bmilk", bmilktotal);
                cmd.Parameters.AddWithValue("@Cmilk", cmilktotal);
                cmd.Parameters.AddWithValue("@curd", curdtotal);
                cmd.Parameters.AddWithValue("@paneer", paneertotal);
                cmd.Parameters.AddWithValue("@butter", buttertotal);
                cmd.Parameters.AddWithValue("@ghee", gheetotal);
                cmd.ExecuteNonQuery();
                con.Close();
                saleMilk();
        }
        public void saleMilk()
        {
            if (CmilkTb.Text != "")
            {
                cmilktotal3 = float.Parse(Cmilk3) + float.Parse(CmilkTb.Text);
            }
            if (BmilkTb.Text != "")
            {
                bmilktotal3= float.Parse(Bmilk3) + float.Parse(BmilkTb.Text);
            }
            if (CmilkTb.Text == "")
            {
                cmilktotal3 = float.Parse(Cmilk3);
            }
            if (BmilkTb.Text == "")
            {
                bmilktotal3 = float.Parse(Bmilk3);
            }

            if (CurdTb.Text != "")
            {
                curdtotal3 = float.Parse(Curd3) + float.Parse(CurdTb.Text);
            }
            if (PaneerTb.Text != "")
            {
                paneertotal3 = float.Parse(Paneer3) + float.Parse(PaneerTb.Text);
            }
            if (CurdTb.Text == "")
            {
                curdtotal3 = float.Parse(Curd2);
            }
            if (PaneerTb.Text == "")
            {
                paneertotal3 = float.Parse(Paneer2);
            }

            if (ButterTb.Text != "")
            {
                buttertotal3 = float.Parse(Butter3) + float.Parse(ButterTb.Text);
            }
            if (GheeTb.Text != "")
            {
                gheetotal3 = float.Parse(Ghee3) + float.Parse(GheeTb.Text);
            }
            if (ButterTb.Text == "")
            {
                buttertotal3 = float.Parse(Butter3);
            }
            if (GheeTb.Text == "")
            {
                gheetotal3 = float.Parse(Ghee3);
            }

            con.Open();
            string query = ("update MilkSalesTb1 set Buffalo_Milk=@Bmilk,Cow_Milk=@Cmilk,Curd=@curd,Paneer=@paneer,Butter=@butter,Ghee=@ghee");
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Bmilk", bmilktotal3);
            cmd.Parameters.AddWithValue("@Cmilk", cmilktotal3);
            cmd.Parameters.AddWithValue("@curd", curdtotal3);
            cmd.Parameters.AddWithValue("@paneer", paneertotal3);
            cmd.Parameters.AddWithValue("@butter", buttertotal3);
            cmd.Parameters.AddWithValue("@ghee", gheetotal3);
            cmd.ExecuteNonQuery();
            con.Close();
            amtMilk();
        }
        public void amtMilk()
        {
            if (CmilkTb.Text != "")
            {
                cmilktotal2 = Convert.ToInt32(Cmilk2) + Convert.ToInt32(total2);
            }
            if (BmilkTb.Text != "")
            {
                bmilktotal2 = Convert.ToInt32(Bmilk2) + Convert.ToInt32(total1);
            }
            if (CmilkTb.Text == "")
            {
                cmilktotal2 = Convert.ToInt32(Cmilk2);
            }
            if (BmilkTb.Text == "")
            {
                bmilktotal2 = Convert.ToInt32(Bmilk2);
            }

            if (CurdTb.Text != "")
            {
                curdtotal2 = Convert.ToInt32(Curd2) + Convert.ToInt32(total3);
            }
            if (PaneerTb.Text != "")
            {
                paneertotal2 = Convert.ToInt32(Paneer2) + Convert.ToInt32(total4);
            }
            if (CurdTb.Text == "")
            {
                curdtotal2 = Convert.ToInt32(Curd2);
            }
            if (PaneerTb.Text == "")
            {
                paneertotal2 = Convert.ToInt32(Paneer2);
            }

            if (ButterTb.Text != "")
            {
                buttertotal2 = Convert.ToInt32(Butter2) + Convert.ToInt32(total5);
            }
            if (GheeTb.Text != "")
            {
                gheetotal2 = Convert.ToInt32(Ghee2) + Convert.ToInt32(total6);
            }
            if (ButterTb.Text == "")
            {
                buttertotal2 = Convert.ToInt32(Butter2);
            }
            if (GheeTb.Text == "")
            {
                gheetotal2 = Convert.ToInt32(Ghee2);
            }

            con.Open();
            string query = ("update ProductAmtTb1 set Bmilk_amt=@Bmilk,Cmilk_amt=@Cmilk,Curd_amt=@curd,Paneer_amt=@paneer,Butter_amt=@butter,Ghee_amt=@ghee");
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Bmilk", bmilktotal2);
            cmd.Parameters.AddWithValue("@Cmilk", cmilktotal2);
            cmd.Parameters.AddWithValue("@curd", curdtotal2);
            cmd.Parameters.AddWithValue("@paneer", paneertotal2);
            cmd.Parameters.AddWithValue("@butter", buttertotal2);
            cmd.Parameters.AddWithValue("@ghee", gheetotal2);
            cmd.ExecuteNonQuery();
            con.Close();
            clearData();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            save_sales();
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
            CmilkTb.Text = "";
            CmilkCb.Checked = false;
            BmilkTb.Text = "";
            BmilkCb.Checked = false;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        
    }
}
