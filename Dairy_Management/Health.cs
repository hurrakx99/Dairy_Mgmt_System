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
    public partial class Health : Form
    {
        static string Id = string.Empty;
        public Health()
        {
            InitializeComponent();
            FillId();
        }

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

        private void Health_Load(object sender, EventArgs e)
        {
            disp_data1();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8AE0HFD;Initial Catalog=Dairy_Management;Integrated Security=True;Pooling=False");
        public void disp_data1()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = new CommandType();
            cmd.CommandText = "select * from HealthTb1";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }
        private void FillId()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select Buffalo_id from BuffaloTb1", con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Buffalo_id", typeof(int));
            dt.Load(Rdr);
            AnimalIdCb.ValueMember = "Buffalo_id";
            AnimalIdCb.DataSource = dt;
            con.Close();
        }
        private void GetName()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from BuffaloTb1 where Buffalo_id="+AnimalIdCb.SelectedValue.ToString()+ "", con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                AnimalNameTb.Text = dr["Name"].ToString();
            }
            con.Close();
        }
        private void button4_Click(object sender, EventArgs e)
        {

            if (EventTb.Text=="")
            {
                MessageBox.Show("Enter a Event");
            }
            else if (DiagnosisTb.Text == "")
            {
                MessageBox.Show("Enter a Diagnosis");
            }
            else if (CostofTreatmentTb.Text=="")
            {
                MessageBox.Show("Enter a cost of treatment");
            }
            else if (TreatmentTb.Text == "")
            {
                MessageBox.Show("Enter a  treatment");
            }
            else if (VetNameTb.Text == "")
            {
                MessageBox.Show("Enter a Vel Name");
            }
            else
            {
                try
                {
                    con.Open();
                    string Query = "Insert into HealthTb1(Animal_Id,Name,Rep_Date,Event,Diagnosis,Treatment,Cost,Vel_Name)values(@Animal_Id,@Name,@Rep_Date,@Event,@Diagnosis,@Treatment,@Cost,@Vel_Name) select @@identity;";
                    SqlCommand cmd = new SqlCommand(Query, con);
                    cmd.Parameters.AddWithValue("@Animal_Id", AnimalIdCb.Text);
                    cmd.Parameters.AddWithValue("@Name", AnimalNameTb.Text);
                    cmd.Parameters.AddWithValue("@Rep_Date", dateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("@Event", EventTb.Text);
                    cmd.Parameters.AddWithValue("@Diagnosis",DiagnosisTb.Text);
                    cmd.Parameters.AddWithValue("@Treatment", TreatmentTb.Text);
                    cmd.Parameters.AddWithValue("@Cost", CostofTreatmentTb.Text);
                    cmd.Parameters.AddWithValue("@Vel_Name", VetNameTb.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    addvetCost();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }
        public void addvetCost()
        {
            con.Open();
            string query = "Insert into ExpenditureTb2(Name,Vet_Cost)values(@name,@cost) ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Name", AnimalNameTb.Text);
            cmd.Parameters.AddWithValue("@cost", CostofTreatmentTb.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Heath Issue Saved");
            disp_data1();
        }
        private void AnimalIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetName();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clearData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "Delete from  HealthTb1 where Rep_Id='" + Convert.ToInt32(Id) + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                int i = cmd.ExecuteNonQuery();
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
            AnimalIdCb.Text = "";
            AnimalNameTb.Text = "";
            EventTb.Text = "";
            DiagnosisTb.Text = "";
            TreatmentTb.Text = "";
            CostofTreatmentTb.Text = "";
            VetNameTb.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int i = dataGridView1.SelectedRows[0].Index;
                    Id = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    AnimalNameTb.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    EventTb.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
                    DiagnosisTb.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
                    TreatmentTb.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
                    CostofTreatmentTb.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();
                    VetNameTb.Text = dataGridView1.Rows[i].Cells[8].Value.ToString();
                    button3.Enabled = true;
                    button2.Enabled = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (Convert.ToInt32(Id) > 0)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update HealthTb1 set Rep_Date=@Rep_Date, Event=@Event, Diagnosis=@Diagnosis, Treatment=@Treatment, Cost=@Cost, Vel_Name=@Vel_Name  where Rep_Id='" + Convert.ToInt32(Id) + "'", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Rep_Date", dateTimePicker1.Value.Date);
                cmd.Parameters.AddWithValue("@Event", EventTb.Text);
                cmd.Parameters.AddWithValue("@Diagnosis", DiagnosisTb.Text);
                cmd.Parameters.AddWithValue("@Treatment", TreatmentTb.Text);
                cmd.Parameters.AddWithValue("@Cost", CostofTreatmentTb.Text);
                cmd.Parameters.AddWithValue("@Vel_Name", VetNameTb.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Updated Successfully");
                clearData();
                disp_data1();
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Login ob = new Login();
            this.Hide();
            ob.Show();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
        
    }
}
