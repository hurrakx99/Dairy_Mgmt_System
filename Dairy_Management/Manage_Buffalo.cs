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
    public partial class Manage_Buffalo : Form
    {
        static string Id = string.Empty;
        public Manage_Buffalo()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8AE0HFD;Initial Catalog=Dairy_Management;Integrated Security=True;Pooling=False");
        int age = 0;
        private void SaveButton_Click(object sender, EventArgs e)
        {
       
            if (NameTb.Text=="")
            {
                MessageBox.Show("Enter Name of Buffalo");
            }
            else if (EarTagTb.Text == "")
            {
                MessageBox.Show("Enter EarTag of Buffalo");
            }
            else if (AgeTb.Text == "")
            {
                MessageBox.Show("Enter Age of Buffalo");
            }
            else if (WeightofBirthTb.Text == "")
            {
                MessageBox.Show("Enter Weightvof Birth");
            }
            else if (ColorTb.Text == "")
            {
                MessageBox.Show("Enter Color of Buffalo");
            }
            else if (BreedTb.Text == "")
            {
                MessageBox.Show("Enter Buffalo Breed");
            }

            else
            {
                try
                {
                    con.Open();
                    string Query = "Insert into BuffaloTb1(Name,Type,Ear_tag,Breed,Color,Weight,Age)values(@Name,@Type,@tag,@Breed,@Color,@Weight,@Age) select @@identity;";
                    SqlCommand cmd = new SqlCommand(Query, con);
                    cmd.Parameters.AddWithValue("@Name", NameTb.Text);
                    cmd.Parameters.AddWithValue("@Type", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@tag", EarTagTb.Text);
                    cmd.Parameters.AddWithValue("@Breed", BreedTb.Text);
                    cmd.Parameters.AddWithValue("@Color", ColorTb.Text);
                    cmd.Parameters.AddWithValue("@Weight", WeightofBirthTb.Text);
                    cmd.Parameters.AddWithValue("@Age", age);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Data Added Successfully");
                    disp_data1();
                    NewButton.Enabled = true;
                    SaveButton.Enabled = false;
                   
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void DOBDate_VisibleChanged(object sender, EventArgs e)
        {
            age = Convert.ToInt32((DateTime.Today.Date-DOBDate.Value.Date).Days) / 365;
        }

        private void DOBDate_MouseLeave(object sender, EventArgs e)
        {
            age = Convert.ToInt32((DateTime.Today.Date - DOBDate.Value.Date).Days) / 365;
            AgeTb.Text = "" + age;
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Milk_Sales ob = new Milk_Sales();
            ob.Show();
            this.Hide();
        }

        private void label11_Click_1(object sender, EventArgs e)
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

        private void Manage_Buffalo_Load(object sender, EventArgs e)
        {
            disp_data1();
        }
        public void disp_data1()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = new CommandType();
            cmd.CommandText = "select * from BuffaloTb1";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            Data_GridView.DataSource = dt;
            con.Close();

        }
 
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "Delete from  BuffaloTb1 where Buffalo_id='" + Convert.ToInt32(Id) + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                int i = cmd.ExecuteNonQuery();
                MessageBox.Show("Record deleted successfully");
                con.Close();
                disp_data1();
                NameTb.Text ="";
                comboBox1.Text = "";
                EarTagTb.Text = "";
                BreedTb.Text = "";
                ColorTb.Text = "";
                WeightofBirthTb.Text = "";
                AgeTb.Text = "";
            

                NameTb.Enabled = false;
                ColorTb.Enabled = false;
                WeightofBirthTb.Enabled = false;
                comboBox1.Enabled = false;
                BreedTb.Enabled = false;
                DOBDate.Enabled = false;
                EarTagTb.Enabled = false;
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Data_GridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (Data_GridView.SelectedRows.Count > 0)
                {
                    int i = Data_GridView.SelectedRows[0].Index;
                    Id = Data_GridView.Rows[i].Cells[0].Value.ToString();
                    NameTb.Text = Data_GridView.Rows[i].Cells[1].Value.ToString();
                    comboBox1.Text = Data_GridView.Rows[i].Cells[2].Value.ToString();
                    EarTagTb.Text = Data_GridView.Rows[i].Cells[3].Value.ToString();
                    BreedTb.Text = Data_GridView.Rows[i].Cells[4].Value.ToString();
                    ColorTb.Text = Data_GridView.Rows[i].Cells[5].Value.ToString();
                    WeightofBirthTb.Text = Data_GridView.Rows[i].Cells[6].Value.ToString();
                    AgeTb.Text = Data_GridView.Rows[i].Cells[7].Value.ToString();
                 
                    NameTb.Enabled = true;
                    ColorTb.Enabled = true;
                    WeightofBirthTb.Enabled = true;
                    comboBox1.Enabled = true;
                    BreedTb.Enabled = true;
                    DOBDate.Enabled = true;
                    EarTagTb.Enabled = true;

                    DeleteButton.Enabled = true;
                    UpdateButton.Enabled = true;
                
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

      

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Id) > 0)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update BuffaloTb1 set Name=@name, Type=@type, Ear_tag=@tag, Breed=@breed, Color=@color, Weight=@weight where Buffalo_id='" + Convert.ToInt32(Id) + "'", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@name", NameTb.Text);
                cmd.Parameters.AddWithValue("@type", comboBox1.Text);
                cmd.Parameters.AddWithValue("@tag", EarTagTb.Text);
                cmd.Parameters.AddWithValue("@breed", BreedTb.Text);
                cmd.Parameters.AddWithValue("@color", ColorTb.Text);
                cmd.Parameters.AddWithValue("@weight", WeightofBirthTb.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Updated Successfully");
                disp_data1();
                NewButton.Enabled = true;
            }
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DeleteButton.Enabled = false;
            UpdateButton.Enabled = false;
            NewButton.Enabled = false;
            SaveButton.Enabled = true;
            NameTb.Enabled = true;
            ColorTb.Enabled = true;
            WeightofBirthTb.Enabled = true;
            comboBox1.Enabled = true;
            BreedTb.Enabled = true;
            DOBDate.Enabled = true;
            EarTagTb.Enabled = true;

            NameTb.Text = "";
            ColorTb.Text = "";
            WeightofBirthTb.Text = "";
            comboBox1.Text = "";
            BreedTb.Text = "";
            DOBDate.Text = "";
            EarTagTb.Text = "";
            AgeTb.Text = "";
            
        }

        private void label18_Click(object sender, EventArgs e)
        {
            Login ob = new Login();
            this.Hide();
            ob.Show();
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
