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

namespace TMS
{
    public partial class frmManagement : Form
    {
        public frmManagement()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHireNo.Text))
            {

                MessageBox.Show("Text box cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-1P7HTT7;Initial Catalog=TMSDB;Integrated Security=True;Pooling=False");

                con.Open();
                SqlCommand cmd = new SqlCommand("insert into HireTab values (@Hire_No ,@Vehicle_No,@Hire_valu,@Area,@Kilometers)", con);
                cmd.Parameters.AddWithValue("@Hire_No", int.Parse(txtHireNo.Text));
                cmd.Parameters.AddWithValue("@Vehicle_No", txtVehicleNo.Text);
                cmd.Parameters.AddWithValue("@Hire_valu", txtHireValue.Text);
                cmd.Parameters.AddWithValue("@Area", txtArea.Text);
                cmd.Parameters.AddWithValue("@Kilometers", txtKm.Text);
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Successfully Saved");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHireNo.Text))
            {

                MessageBox.Show("Text box cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-1P7HTT7;Initial Catalog=TMSDB;Integrated Security=True;Pooling=False");

                con.Open();
                SqlCommand cmd = new SqlCommand("Update HireTab set Vehicle_No=@Vehicle_No, Hire_valu=@Hire_valu, Area=@Area, Kilometers=@Kilometers where Hire_No = @Hire_No", con);
                cmd.Parameters.AddWithValue("@Hire_No", int.Parse(txtHireNo.Text));
                cmd.Parameters.AddWithValue("@Vehicle_No", txtVehicleNo.Text);
                cmd.Parameters.AddWithValue("@Hire_valu", txtHireValue.Text);
                cmd.Parameters.AddWithValue("@Area", txtArea.Text);
                cmd.Parameters.AddWithValue("@Kilometers", txtKm.Text);
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Successfully Updated");
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHireNo.Text))
            {

                MessageBox.Show("Text box cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-1P7HTT7;Initial Catalog=TMSDB;Integrated Security=True;Pooling=False");

                con.Open();
                SqlCommand cmd = new SqlCommand("Delete HireTab where Hire_No=@Hire_No", con);
                cmd.Parameters.AddWithValue("@Hire_No", int.Parse(txtHireNo.Text));
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Successfully Deleted");
            }
        }

        private void btnClr_Click(object sender, EventArgs e)
        {
            txtHireNo.Text = "";
            txtVehicleNo.Text = "";
            txtArea.Text = "";
            txtKm.Text = "";
            txtHireValue.Text = "";
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
                SqlCommand cmd = new SqlCommand("Select * from HireTab where Hire_No=@Hire_No", con);
                cmd.Parameters.AddWithValue("@Hire_No", int.Parse(txtHireNo.Text));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                guna2DataGridView2.DataSource = dt;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-1P7HTT7;Initial Catalog=TMSDB;Integrated Security=True;Pooling=False");

            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from HireTab", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            guna2DataGridView2.DataSource = dt;
        }

        private void frmManagement_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-1P7HTT7;Initial Catalog=TMSDB;Integrated Security=True;Pooling=False");

            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from HireTab", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            guna2DataGridView2.DataSource = dt;

        }

        private void btnTSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtVehicleNo.Text))
            {

                MessageBox.Show("Text box cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-1P7HTT7;Initial Catalog=TMSDB;Integrated Security=True;Pooling=False");

                con.Open();
                SqlCommand cmd = new SqlCommand("insert into TireTab values (@Vehicle_ID ,@LFW,@LMW,@LMIW,@LBW,@LBIW,@RFW,@RMW,@RMIW,@RBW,@RBIW)", con);
                cmd.Parameters.AddWithValue("@Vehicle_ID", int.Parse(txtVehicleNo.Text));
                cmd.Parameters.AddWithValue("@LFW", txtLFW.Text);
                cmd.Parameters.AddWithValue("@LMW", txtLMW.Text);
                cmd.Parameters.AddWithValue("@LMIW", txtLMIW.Text);
                cmd.Parameters.AddWithValue("@LBW", txtLBW.Text);
                cmd.Parameters.AddWithValue("@LBIW", txtLBIW.Text);
                cmd.Parameters.AddWithValue("@RFW", txtRFW.Text);
                cmd.Parameters.AddWithValue("@RMW", txtRMW.Text);
                cmd.Parameters.AddWithValue("@RMIW", txtRMIW.Text);
                cmd.Parameters.AddWithValue("@RBW", txtRBW.Text);
                cmd.Parameters.AddWithValue("@RBIW", txtRBIW.Text);
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Successfully Saved");
            }
        }

        private void btnTLoad_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-1P7HTT7;Initial Catalog=TMSDB;Integrated Security=True;Pooling=False");

            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from TireTab", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            guna2DataGridView4.DataSource = dt;
        }
    }
}
