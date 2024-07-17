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
    public partial class frmSettings : Form
    {
        public frmSettings()
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
                SqlCommand cmd = new SqlCommand("insert into UsersTab values (@userID ,@Job,@upass,@uName,@uphone)", con);
                cmd.Parameters.AddWithValue("@userID", int.Parse(txtId.Text));
                cmd.Parameters.AddWithValue("@Job", txtJobTitle.Text);
                cmd.Parameters.AddWithValue("upass", txtUserPass.Text);
                cmd.Parameters.AddWithValue("@uName", txtUserName.Text);
                cmd.Parameters.AddWithValue("@uphone", txtUserMobile.Text);
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
                SqlCommand cmd = new SqlCommand("Update UsersTab set Job=@Job, upass=@upass, uName=@uName, uphone=@uphone where userID = @userID", con);
                cmd.Parameters.AddWithValue("@userID", int.Parse(txtId.Text));
                cmd.Parameters.AddWithValue("@Job", txtJobTitle.Text);
                cmd.Parameters.AddWithValue("upass", txtUserPass.Text);
                cmd.Parameters.AddWithValue("@uName", txtUserName.Text);
                cmd.Parameters.AddWithValue("@uphone", txtUserMobile.Text);
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
                SqlCommand cmd = new SqlCommand("Delete UsersTab where userID=@userID", con);
                cmd.Parameters.AddWithValue("@userID", int.Parse(txtId.Text));
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Successfully Deleted");
            }
        }

        private void btnClr_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtJobTitle.Text = "";
            txtUserMobile.Text = "";
            txtUserName.Text = "";
            txtUserPass.Text = "";
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
                SqlCommand cmd = new SqlCommand("Select * from UsersTab where userID=@userID", con);
                cmd.Parameters.AddWithValue("@userID", int.Parse(txtId.Text));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                guna2DataGridView4.DataSource = dt;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-1P7HTT7;Initial Catalog=TMSDB;Integrated Security=True;Pooling=False");

            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from UsersTab", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            guna2DataGridView4.DataSource = dt;
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-1P7HTT7;Initial Catalog=TMSDB;Integrated Security=True;Pooling=False");

            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from UsersTab", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            guna2DataGridView4.DataSource = dt;
        }
    }
}
