using HMS_BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.Users
{
    public partial class frmUsersList : Form
    {
        static DataTable _dtAllUsers = clsUsers.GetAllUsers();

        static DataTable _dtUsers =
            _dtAllUsers.DefaultView.ToTable(false, "UserID", "Name", "UserName","CountryName" , 
                "Gender", "IsActive");
        public frmUsersList()
        {
            InitializeComponent();
        }

        void _RefreshList()
        {
            _dtAllUsers = clsUsers.GetAllUsers();

            _dtUsers =
            _dtAllUsers.DefaultView.ToTable(false, "UserID", "Name", "UserName", "CountryName", "Gender", "IsActive");

            dgvUsers.DataSource = _dtUsers;

            lblRecordsCount.Text = dgvUsers.RowCount.ToString();
        }

        private void frmUsersList_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            cbIsActive.SelectedIndex = 0;

            dgvUsers.DataSource = _dtUsers;

            if (dgvUsers.Rows.Count > 0)
            {
                dgvUsers.Columns[0].HeaderText = "User ID";
                dgvUsers.Columns[0].Width = 100;

                dgvUsers.Columns[1].HeaderText = "Name";
                dgvUsers.Columns[1].Width = 300;

                dgvUsers.Columns[2].HeaderText = "User Name";
                dgvUsers.Columns[2].Width = 150;

                dgvUsers.Columns[3].HeaderText = "CountryName";
                dgvUsers.Columns[3].Width = 150;

                dgvUsers.Columns[4].HeaderText = "Gender";
                dgvUsers.Columns[4].Width = 100;

                dgvUsers.Columns[5].HeaderText = "Is Active";
                dgvUsers.Columns[5].Width = 100;
            }
            lblRecordsCount.Text = dgvUsers.RowCount.ToString();

            
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddNewUser addUpdateUser = new frmAddNewUser();

            addUpdateUser.ShowDialog();

            _RefreshList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterValue = "";

            switch (cbFilterBy.SelectedItem)
            {
                case "None":
                    FilterValue = "None";
                    break;
                case "User ID":
                    FilterValue = "UserID";
                    break;
                case "Name":
                    FilterValue = "Name";
                    break;
                case "User Name":
                    FilterValue = "UserName";
                    break;
                case "Is Active":
                    FilterValue = "IsActive";
                    break;
            }

            if (txtFilterValue.Text == "" || FilterValue == "None")
            {
                _dtUsers.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvUsers.RowCount.ToString();
                return;
            }

            if (FilterValue == "UserID")
                _dtUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterValue, txtFilterValue.Text.Trim());

            else
                _dtUsers.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", FilterValue, txtFilterValue.Text.Trim());


            lblRecordsCount.Text = dgvUsers.RowCount.ToString();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "User ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "None" || cbFilterBy.Text == "Is Active")
            {
                txtFilterValue.Visible = false;
            }
            else
                txtFilterValue.Visible = true;

            if (cbFilterBy.Text == "Is Active")
                cbIsActive.Visible = true;
            else
                cbIsActive.Visible = false;
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterValue = "";

            string FilterColumn = "IsActive";

            FilterValue = cbIsActive.Text.Trim();

            switch (FilterValue)
            {
                case "None":
                    break;
                case "Active":
                    FilterValue = "1";
                    break;
                case "InActive":
                    FilterValue = "0";
                    break;
            }

            if (FilterValue == "None")
                _dtUsers.DefaultView.RowFilter = "";
            else
                _dtUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;

            frmAddNewUser addUpdateUser = new frmAddNewUser(UserID);

            addUpdateUser.ShowDialog();

            _RefreshList();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddNewUser addUpdateUser = new frmAddNewUser();

            addUpdateUser.ShowDialog();

            _RefreshList();

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;

            if (MessageBox.Show("Are you sure want to delete this user ?", "Warning"
                , MessageBoxButtons.OKCancel
                , MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsUsers.DeleteUser(UserID))
                {
                    MessageBox.Show("User deleted successfully",
                        "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("User deleted failed",
                       "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                _RefreshList();
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;

            frmUserInfo userInfo = new frmUserInfo(UserID);

            userInfo.ShowDialog();
        }

        private void ChangePasswordtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;

            frmChangePassword ChangePassword = new frmChangePassword(UserID);

            ChangePassword.ShowDialog();
        }
    }

}
