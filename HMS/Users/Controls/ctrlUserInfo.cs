
using DVLD_Buisness;
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
using static HMS_BusinessLogic.clsPerson;
using System.Xml.Linq;

namespace HMS.Users.Controls
{
    public partial class ctrlUserInfo : UserControl
    {

        int _UserID = 0;

        clsUsers _User;

        public int UserID
        {
            get
            {
                return _UserID;
            }
        }

        public clsUsers User
        {
            get
            {
                return _User;
            }
        }


        public ctrlUserInfo()
        {
            InitializeComponent();
        }

        void _ResetDefaultValue()
        {
            lbUserID.Text    = "[????]";
            lbIDNumber.Text  = "[????]";
            lblCountry.Text  = "[????]";
            lblFullName.Text = "[????]";

            lblGendor.Text   = "[????]";
            lbUserID.Text    = "[????]";
            lblPhone.Text    = "[????]";

            ckIsActive.Checked = false;
        }

        void _FillInfoWithData()
        {
            lbUserID.Text = User.UserID.ToString();
            lbIDNumber.Text = User.IDNumber.ToString();
            lblFullName.Text = User.Name;
            lblCountry.Text = User.CountryInfo.CountryName;

            if (User.Gender==1 )
            lblGendor.Text = "Male";
            else
             lblGendor.Text = "Female";

            lbUserID.Text = User.UserID.ToString();
            lblPhone.Text = User.Phone;
            lblUserName.Text = User.UserName; 
            ckIsActive.Checked = User.IsActive;
        }

        public void LoadUserInfo(int UserID)
        {
            _UserID = UserID;

            _User = clsUsers.Find(_UserID);

            if (_User == null)
            {
                _ResetDefaultValue();

                MessageBox.Show("This user with " + _UserID + "is not found", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _FillInfoWithData();
        }

      
    }
}
