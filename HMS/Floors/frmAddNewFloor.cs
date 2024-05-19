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

namespace HMS.Floors
{
    public partial class frmAddNewFloor : Form
    {
        clsFloors _floors;

        int _FloorID = 0; 

        enum enMode { AddNewFloor , UpdateFloor};

        enMode _Mode = enMode.AddNewFloor;
        public frmAddNewFloor()
        {
            InitializeComponent();

            _Mode = enMode.AddNewFloor; 
        }

        public frmAddNewFloor(int FloorID)
        {
            InitializeComponent();

            _FloorID = FloorID;

            _Mode = enMode.UpdateFloor; 
        }

        void RestDefaultValues()
        {
            if (_Mode == enMode.AddNewFloor)
            {
                this.Text = "Add New Floor";
                _floors = new clsFloors();
            }
            else
            {
                this.Text = "Update Floor";

            }

            txtName.Text = "";
        }

        void _LoadData()
        {
            _floors = clsFloors.Find(_FloorID);

            txtName.Text = _floors.FloorName; 
        } 

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Feilds are empty , Please Fill All required Feilds to continue",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            _floors.FloorName = txtName.Text;

            if (_floors.Save())
            {
                _FloorID = _floors.FloorID;
                _Mode = enMode.UpdateFloor; 
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddNewFloor_Load(object sender, EventArgs e)
        {
            RestDefaultValues();

            if (_Mode == enMode.UpdateFloor)
                _LoadData();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
