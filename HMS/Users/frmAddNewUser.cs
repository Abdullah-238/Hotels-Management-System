using DVLD_Buisness;
using HMS.Global;
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
    public partial class frmAddNewUser : Form
    {
        clsUsers User;
        enum enMode { AddNewUser, UpdateUser };

        enMode Mode;

        int _UserID = 0;
        public frmAddNewUser()
        {
            InitializeComponent();

            Mode = enMode.AddNewUser;
        }

        public frmAddNewUser(int UserID)
        {
            InitializeComponent();

            Mode = enMode.UpdateUser;

            _UserID = UserID;

        }

        private void _FillCountriesInComoboBox()
        {
            DataTable dtCountries = clsCountry.GetAllCountries();

            foreach (DataRow row in dtCountries.Rows)
            {
                cbCountry.Items.Add(row["CountryName"]);
            }
        }
        void _ResetDefaultValue()
        {
            if (Mode == enMode.AddNewUser)
            {
                lblTitle.Text = "Add New User";
                this.Text = "Add New User";
                User = new clsUsers();
            }
            else
            {
                lblTitle.Text = "Update User";
                this.Text = "Update User";

            }

            _FillCountriesInComoboBox();


            txtName.Text = "";
            rbMale.Checked = true;
            txtPhone.Text = "";
            cbCountry.SelectedIndex = cbCountry.FindString("Saudi Arabia");
            txtID.Text = "";

            txUserName.Text = "";
            txPassword.Text = "";
            txConfrimPassword.Text = "";
            ckIsActive.Checked = false;
        
        }

        void _LoadData()
        {
            User = clsUsers.Find(_UserID);

            if (User == null)
            {
                MessageBox.Show("This user with ID " + _UserID + " is not found", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            int CountryID = User.CountryID;

            txtName.Text = User.Name;
            txtPhone.Text = User.Phone;
            txtID.Text = User.IDNumber.ToString();

            if (User.Gender == 1)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;

            cbCountry.SelectedIndex = CountryID - 1;

            txUserName.Text = User.UserName;
            ckIsActive.Checked = User.IsActive;


        }

        private void frmAddNewUser_Load(object sender, EventArgs e)
        {
            _ResetDefaultValue();

            if (Mode == enMode.UpdateUser)
                _LoadData();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Feilds are empty , Please Fill All required Feilds to continue",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txConfrimPassword.Text != txPassword.Text && Mode == enMode.AddNewUser)
            {
                MessageBox.Show("Password Not Match",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsUsers.IsUserNameFound(txUserName.Text) && Mode == enMode.AddNewUser)
            {
                MessageBox.Show("this User Name is Exsist please enter anthor one",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            User.Name = txtName.Text;
            User.Phone = txtPhone.Text;
            User.IDNumber = int.Parse(txtID.Text);

            if (rbMale.Checked)
                User.Gender = 1;
            else
                User.Gender = 0;

            int NationalityCountryID = clsCountry.Find(cbCountry.Text).ID;

            User.CountryID = NationalityCountryID;

            User.UserName = txUserName.Text;
            User.IsActive = ckIsActive.Checked;

            string Password = clsUtil.ComputeHash(txPassword.Text);

            if (string.IsNullOrEmpty(txPassword.Text))
                User.Password = User.Password;
            else
                User.Password = Password;

            if (User.Save())
            {
                _UserID = User.UserID;
                Mode = enMode.UpdateUser;
                MessageBox.Show("Data Saved Succesfully", "Done", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                _LoadData();
            }
            else
            {
                MessageBox.Show("Data Saved Faild", "Errorr", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }

        }

        private void Feilds_Validating_PassWord(object sender, CancelEventArgs e)
        {
            TextBox Txt = (TextBox)sender;
            if (string.IsNullOrEmpty(Txt.Text.Trim()) && Mode != enMode.UpdateUser)
            {
                e.Cancel = true;
                errorProvider1.SetError(Txt, "This field shouldn't be empty");
            }
            else
            {
                errorProvider1.SetError(Txt, "");
            }
        }

        private void Feilds_Validating(object sender, CancelEventArgs e)
        {
            TextBox Txt = (TextBox)sender;
            if (string.IsNullOrEmpty(Txt.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(Txt, "This field shouldn't be empty");
            }
            else
            {
                errorProvider1.SetError(Txt, "");
            }
        }

        private void txUserName_TextChanged(object sender, EventArgs e)
        {
            if (clsUsers.IsUserNameFound(txUserName.Text.Trim()) && Mode == enMode.AddNewUser)
            {
                errorProvider1.SetError(txUserName, "this User Name is Exsist please enter anthor one");
            }
            else
            {
                errorProvider1.SetError(txUserName, "");
            }
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
