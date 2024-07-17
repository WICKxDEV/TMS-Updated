using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.MonthCalendar;

namespace TMS
{
    public partial class frmPOS : Form
    {
        public frmPOS()
        {
            InitializeComponent();
        }

        private void btnCal_Click(object sender, EventArgs e)
        {
            double hireval = Convert.ToDouble(txtHireVal.Text);
            double km = Convert.ToDouble(txtKm.Text);
            double servicecost = Convert.ToDouble(txtServiceCost.Text);
            double repcost = Convert.ToDouble(txtRepCost.Text);

            double drsal = (hireval / 100)*12 ;
            txtDrSalary.Text = Convert.ToString(drsal);

            double diesel = (km / 3.5) * 329;
            txtDcost.Text = Convert.ToString(diesel);

            double tirewast = km * 1;

            double maintain = servicecost + repcost + tirewast;
            txtMaintainCost.Text = Convert.ToString(maintain);

            double profit = hireval - diesel - maintain - drsal;
            txtProfit.Text = Convert.ToString(profit);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHireID.Text))
            {

                MessageBox.Show("Text box cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DateTime selectedDate = guna2DateTimePicker1.Value;

                SqlConnection con = new SqlConnection("Data Source=DESKTOP-1P7HTT7;Initial Catalog=TMSDB;Integrated Security=True;Pooling=False");

                con.Open();
                SqlCommand cmd = new SqlCommand("insert into PosTab values (@Hire_ID ,@Vehicle_ID,@Profit,@Salary,@Maintains,@Diesel,@Date)", con);
                cmd.Parameters.AddWithValue("@Hire_ID", int.Parse(txtHireID.Text));
                cmd.Parameters.AddWithValue("@Vehicle_ID", txtVid.Text);
                cmd.Parameters.AddWithValue("@Profit", txtProfit.Text);
                cmd.Parameters.AddWithValue("@Salary", txtDrSalary.Text);
                cmd.Parameters.AddWithValue("@Maintains", txtMaintainCost.Text);
                cmd.Parameters.AddWithValue("@Diesel", txtDcost.Text);
                cmd.Parameters.AddWithValue("@Date", selectedDate.ToString("yyyy-MM-dd"));
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Successfully Saved");
            }
        }

        private void frmPOS_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-1P7HTT7;Initial Catalog=TMSDB;Integrated Security=True;Pooling=False");

            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from PosTab", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            guna2DataGridView3.DataSource = dt;

    
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHireNo.Text))
            {

                MessageBox.Show("Text box cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-1P7HTT7;Initial Catalog=TMSDB;Integrated Security=True;Pooling=False");

                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from PosTab where Hire_ID=@Hire_ID", con);
                cmd.Parameters.AddWithValue("@Hire_ID", int.Parse(txtHireNo.Text));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                guna2DataGridView3.DataSource = dt;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-1P7HTT7;Initial Catalog=TMSDB;Integrated Security=True;Pooling=False");

            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from PosTab", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            guna2DataGridView3.DataSource = dt;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHireID.Text))
            {

                MessageBox.Show("Text box cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-1P7HTT7;Initial Catalog=TMSDB;Integrated Security=True;Pooling=False");

                con.Open();
                SqlCommand cmd = new SqlCommand("Delete PosTab where Hire_ID=@Hire_ID", con);
                cmd.Parameters.AddWithValue("@Hire_ID", int.Parse(txtHireID.Text));
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Successfully Deleted");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHireID.Text))
            {

                MessageBox.Show("Text box cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-1P7HTT7;Initial Catalog=TMSDB;Integrated Security=True;Pooling=False");

                con.Open();
                SqlCommand cmd = new SqlCommand("Update HireTab set Vehicle_ID=@Vehicle_ID, Profit=@Profit, Salary=@Salary, Maintains=@Maintains, Diesel=@Diesel  where Hire_ID = @Hire_ID", con);
                cmd.Parameters.AddWithValue("@Hire_ID", int.Parse(txtHireID.Text));
                cmd.Parameters.AddWithValue("@Vehicle_ID", txtVid.Text);
                cmd.Parameters.AddWithValue("@Profit", txtProfit.Text);
                cmd.Parameters.AddWithValue("@Salary", txtDrSalary.Text);
                cmd.Parameters.AddWithValue("@Maintains", txtMaintainCost.Text);
                cmd.Parameters.AddWithValue("@Diesel", txtDcost.Text);
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Successfully Updated");
            }
        }

        private void btnClr_Click(object sender, EventArgs e)
        {
            txtHireID.Text = "";
            txtVid.Text = "";
            txtHireVal.Text = "";
            txtKm.Text = "";
            txtRepCost.Text = "";
            txtServiceCost.Text = "";
            txtDcost.Text = "";
            txtDrSalary.Text = "";
            txtMaintainCost.Text = "";
            txtProfit.Text = "";
        }

        private void guna2TabControl1_Click(object sender, EventArgs e)
        {

        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            
        }

        private void btnTrUpdate_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCheck_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtVehi1ID.Text))
            {

                MessageBox.Show("Text box cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-1P7HTT7;Initial Catalog=TMSDB;Integrated Security=True;Pooling=False");
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM TireTab where Vehicle_ID = @Vehicle_ID", con);
                cmd.Parameters.AddWithValue("@Vehicle_ID", int.Parse(txtVehi1ID.Text));


                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int VehicleIDFromDatabase = Convert.ToInt32(reader["Vehicle_ID"]);

                    // Check if the HireID from the database matches the value in txtHireID.Text
                    if (VehicleIDFromDatabase == int.Parse(txtVehi1ID.Text))
                    {
                        // Your existing code to read and display data
                        txt1LFW.Text = reader["LFW"].ToString();
                        txt1LMW.Text = reader["LMW"].ToString();
                        txt1LMIW.Text = reader["LMIW"].ToString();
                        txt1LBW.Text = reader["LBW"].ToString();
                        txt1LBIW.Text = reader["LBIW"].ToString();
                        txt1RFW.Text = reader["RFW"].ToString();
                        txt1RMW.Text = reader["RMW"].ToString();
                        txt1RMIW.Text = reader["RMIW"].ToString();
                        txt1RBW.Text = reader["RBW"].ToString();
                        txt1RBIW.Text = reader["RBIW"].ToString();

                        // You might want to break out of the loop if you only want to process the first match
                        // break;
                    }
                }

                reader.Close();
                con.Close();
            }
        }

        private void btnTUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtVehi1ID.Text))
            {

                MessageBox.Show("Text box cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-1P7HTT7;Initial Catalog=TMSDB;Integrated Security=True;Pooling=False");

                con.Open();
                SqlCommand cmd = new SqlCommand("Update TireTab set Vehicle_ID=@Vehicle_ID, LFW=@LFW, LMW=@LMW, LMIW=@LMIW, LBW=@LBW, LBIW=@LBIW, RFW=@RFW, RMW=@RMW, RMIW=@RMIW, RBW=@RBW, RBIW=@RBIW  where Vehicle_ID = @Vehicle_ID", con);
                cmd.Parameters.AddWithValue("@Vehicle_ID", int.Parse(txtVehi1ID.Text));
                cmd.Parameters.AddWithValue("@LFW", txt1LFW.Text);
                cmd.Parameters.AddWithValue("@LMW", txt1LMW.Text);
                cmd.Parameters.AddWithValue("@LMIW", txt1LMIW.Text);
                cmd.Parameters.AddWithValue("@LBW", txt1LBW.Text);
                cmd.Parameters.AddWithValue("@LBIW", txt1LBIW.Text);
                cmd.Parameters.AddWithValue("@RFW", txt1RFW.Text);
                cmd.Parameters.AddWithValue("@RMW", txt1RMW.Text);
                cmd.Parameters.AddWithValue("@RMIW", txt1RMIW.Text);
                cmd.Parameters.AddWithValue("@RBW", txt1RBW.Text);
                cmd.Parameters.AddWithValue("@RBIW", txt1RBIW.Text);
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Successfully Updated");
            }
        }

        private void BtnTClear_Click(object sender, EventArgs e)
        {
            txt1LFW.Text = "";
            txt1LMW.Text = "";
            txt1LMIW.Text = "";
            txt1LBW.Text = "";
            txt1LBIW.Text = "";
            txt1RFW.Text = "";
            txt1RMW.Text = "";
            txt1RMIW.Text = "";
            txt1RBW.Text = "";
            txt1RBIW.Text = "";
        }
    }
}
