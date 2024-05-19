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

namespace HMS.RoomTypes
{
    public partial class frmAddEditRoomType : Form
    {
        clsRoomTypes RoomType;
        enum enMode { AddNewRoomType, UpdateRoomType };

        enMode Mode = enMode.AddNewRoomType;

        int _RoomTypeID = 0;

        public frmAddEditRoomType()
        {
            InitializeComponent();

            Mode = enMode.AddNewRoomType;

        }
        public frmAddEditRoomType(int RoomTypeID)
        {
            InitializeComponent();

            Mode = enMode.UpdateRoomType;

            _RoomTypeID = RoomTypeID;
        }

        void _ResetDefaultValue()
        {
            if (Mode == enMode.AddNewRoomType)
            {
                lblTitle.Text = "Add New Room Type";
                this.Text = "Add New Room Type";
                RoomType = new clsRoomTypes();
            }
            else
            {
                lblTitle.Text = "Update Room Type";
                this.Text = "Update Room Type";

            }

            txtName.Text = "";
           
        }

        void _LoadData()
        {
            RoomType = clsRoomTypes.Find(_RoomTypeID);

            if (RoomType == null)
            {
                MessageBox.Show("This user with " + _RoomTypeID + "is not found", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            txtName.Text = RoomType.RoomTypeName;
           

        }

        private void frmAddEditRoomType_Load(object sender, EventArgs e)
        {
            _ResetDefaultValue();

            if (Mode == enMode.UpdateRoomType)
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

            RoomType.RoomTypeName = txtName.Text.Trim();
           

            if (RoomType.Save())
            {
                _RoomTypeID = RoomType.RoomTypeID;
                Mode = enMode.AddNewRoomType;
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

        private void txtName_Validating(object sender, CancelEventArgs e)
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

    }
}
