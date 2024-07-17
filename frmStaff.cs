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
    public partial class frmStaff : Form
    {
        public frmStaff()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {

                MessageBox.Show("Text box cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-1P7HTT7;Initial Catalog=TMSDB;Integrated Security=True;Pooling=False");

                con.Open();
                SqlCommand cmd = new SqlCommand("insert into StaffTab values (@ID ,@Driver_Name,@Driver_NIC,@Driver_Mobile,@Vehicle_No)", con);
                cmd.Parameters.AddWithValue("@ID", int.Parse(txtId.Text));
                cmd.Parameters.AddWithValue("@Vehicle_No", txtVehiNo.Text);
                cmd.Parameters.AddWithValue("@Driver_Name", txtDrivName.Text);
                cmd.Parameters.AddWithValue("@Driver_Mobile", txtDrivNo.Text);
                cmd.Parameters.AddWithValue("@Driver_NIC", txtNicNo.Text);
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Successfully Saved");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {

                MessageBox.Show("Text box cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-1P7HTT7;Initial Catalog=TMSDB;Integrated Security=True;Pooling=False");

                con.Open();
                SqlCommand cmd = new SqlCommand("Update StaffTab set Vehicle_NO=@Vehicle_No, Driver_Name=@Driver_Name, Driver_Mobile=@Driver_Mobile, Driver_NIC=@Driver_NIC where ID = @ID", con);
                cmd.Parameters.AddWithValue("@ID", int.Parse(txtId.Text));
                cmd.Parameters.AddWithValue("@Vehicle_No", txtVehiNo.Text);
                cmd.Parameters.AddWithValue("@Driver_Name", txtDrivName.Text);
                cmd.Parameters.AddWithValue("@Driver_Mobile", txtDrivNo.Text);
                cmd.Parameters.AddWithValue("@Driver_NIC", txtNicNo.Text);
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Successfully Updated");
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {

                MessageBox.Show("Text box cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-1P7HTT7;Initial Catalog=TMSDB;Integrated Security=True;Pooling=False");

                con.Open();
                SqlCommand cmd = new SqlCommand("Delete StaffTab where ID=@ID", con);
                cmd.Parameters.AddWithValue("@ID", int.Parse(txtId.Text));
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Successfully Deleted");
            }
        }

        private void btnClr_Click(object sender, EventArgs e)
        {
            txtDrivName.Text = "";
            txtDrivNo.Text = "";
            txtNicNo.Text = "";
            txtId.Text = "";
            txtVehiNo.Text = "";
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {

                MessageBox.Show("Text box cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-1P7HTT7;Initial Catalog=TMSDB;Integrated Security=True;Pooling=False");

                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from StaffTab where ID=@ID", con);
                cmd.Parameters.AddWithValue("@ID", int.Parse(txtId.Text));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                guna2DataGridView5.DataSource = dt;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-1P7HTT7;Initial Catalog=TMSDB;Integrated Security=True;Pooling=False");

            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from StaffTab", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            guna2DataGridView5.DataSource = dt;
        }

        private void frmStaff_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-1P7HTT7;Initial Catalog=TMSDB;Integrated Security=True;Pooling=False");

            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from StaffTab", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            guna2DataGridView5.DataSource = dt;
        }
    }
}
