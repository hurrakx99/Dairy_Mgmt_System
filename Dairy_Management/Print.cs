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
    public partial class Print : Form
    {
        public Print()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8AE0HFD;Initial Catalog=Dairy_Management;Integrated Security=True;Pooling=False");
        SqlCommand cmd1;
        SqlCommand cmd2;
        SqlDataAdapter dr;
        private int salesid;

        public int SalesID
        {
            get { return salesid; }
            set { salesid = value; }
        }
        

        private void Print_Load(object sender, EventArgs e)
        {
            con.Open();
            DataTable dt1 = new DataTable();
            cmd1 = new SqlCommand("Select * from SalesTb2 where id='"+SalesID+"'",con);
            dr = new SqlDataAdapter(cmd1);
            dr.Fill(dt1);


            DataTable dt2 = new DataTable();
            cmd2 = new SqlCommand("Select * from Sales_productTb1 where sales_id='" + SalesID + "'", con);
            dr = new SqlDataAdapter(cmd2);
            dr.Fill(dt2);
           

            CrystalReport1 cr = new CrystalReport1();
            cr.Database.Tables["SalesTb2"].SetDataSource(dt1);
            cr.Database.Tables["Sales_productTb1"].SetDataSource(dt2);
            this.crystalReportViewer1.ReportSource = cr;
            crystalReportViewer1.Refresh();
            con.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
