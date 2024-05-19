using HMS.Global;
using HMS_BusinessLogic;
using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace HMS.Login
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {

            clsUsers user = clsUsers.FindByUserNameAndPassword(txtUserName.Text.Trim(),
              clsUtil.ComputeHash(txtPassword.Text.Trim()));

            if (user != null)
            {

                clsLoginRecord.AddNew(user.UserID, user.UserName);

                if (chkRememberMe.Checked)
                    clsGlobal.RememberUsernameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());
                else
                    clsGlobal.RemoveStoredCredential();
                

                //incase the user is not active
                if (!user.IsActive)
                {

                    txtUserName.Focus();
                    MessageBox.Show("Your accound is not Active, Contact Admin.", "In Active Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                clsGlobal.CurrentUser = user;
                this.Hide();
                MainPage frm = new MainPage(this);
                frm.ShowDialog();

               
            }
            else
            {
                txtUserName.Focus();
                MessageBox.Show("Invalid Username/Password.", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

            string UserName = ""; string Password = "";

            if (clsGlobal.GetStoredCredential(ref UserName, ref Password))
            {
                txtUserName.Text = UserName;

                txtPassword.Text = Password;

                chkRememberMe.Checked = true;
                
            }
            else chkRememberMe.Checked = false;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
