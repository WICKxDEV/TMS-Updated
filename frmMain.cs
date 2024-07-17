using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TMS
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        //methord to add controls in main form
        public  void AddControls(Form f)
        {
            ControlsPanel.Controls.Clear();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            ControlsPanel.Controls.Add(f);
            f.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblUser.Text = MainClass.USER;
            AddControls(new frmHome());
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            AddControls(new frmHome());
        }

        private void btnVehicles_Click(object sender, EventArgs e)
        {
            AddControls(new frmVehicles());
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            AddControls(new frmManagement());
        }

        private void btnPos_Click(object sender, EventArgs e)
        {
            AddControls(new frmPOS());
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            AddControls(new frmStaff());
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            AddControls(new frmSettings());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin frm = new frmLogin();
            frm.Show();
        }
    }
}
