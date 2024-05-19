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
using static System.Net.Mime.MediaTypeNames;

namespace HMS.Rooms
{
    public partial class frmAddNewRoom : Form
    {
        clsRooms Room;
        enum enMode { AddNewRoom, UpdateRoom };

        enMode Mode;

        int _RoomID = 0;
        public frmAddNewRoom()
        {
            InitializeComponent();

            Mode = enMode.AddNewRoom;
        }

        public frmAddNewRoom(int RoomID)
        {
            InitializeComponent();

            Mode = enMode.UpdateRoom;

            _RoomID = RoomID;

        }

        private void _FillRoomsTypesAndFloorsInComoboBox()
        {
            DataTable dtRoomTypes = clsRoomTypes.GetAllRoomTypes();

            foreach (DataRow row in dtRoomTypes.Rows)
            {
                cbRoomTypes.Items.Add(row["RoomTypeName"]);
            }

            DataTable dtFloors = clsFloors.GetAllFloors();

            foreach (DataRow row in dtFloors.Rows)
            {
                cbFloors.Items.Add(row["FloorName"]);
            }


        }
        void _ResetDefaultValue()
        {
            if (Mode == enMode.AddNewRoom)
            {
                lblTitle.Text = "Add New Room";
                this.Text = "Add New Room";
                Room = new clsRooms();
            }
            else
            {
                lblTitle.Text = "Update Room";
                this.Text = "Update Room";

            }

            _FillRoomsTypesAndFloorsInComoboBox();


            txtName.Text = "";
            txtRoomPrice.Text = "";
            txtAdult.Text = "";
            txtBeds.Text = "";

            ckAvalivale.Checked = false;

            cbRoomTypes.SelectedIndex = 0;
            cbFloors.SelectedIndex = 0;
        }

        void _LoadData()
        {
            Room = clsRooms.Find(_RoomID);

            if (Room == null)
            {
                MessageBox.Show("This Rooms with " + _RoomID + "is not found", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtName.Text = Room.RoomName;
            txtRoomPrice.Text = Room.RoomPrice.ToString();
            txtAdult.Text = Room.Persons.ToString();
            txtBeds.Text = Room.Beds.ToString();

            ckAvalivale.Checked = Room.IsAvailable;

            cbRoomTypes.FindString(Room.RoomTypes.RoomTypeName);

            cbFloors.FindString(Room.Floor.FloorName);

            //cbRoomTypes.SelectedText = Room.RoomTypes.RoomTypeName;
            //cbFloors.SelectedText = Room.Floor.FloorName;


        }

        private void frmAddNewRoom_Load(object sender, EventArgs e)
        {
            _ResetDefaultValue();

            if (Mode == enMode.UpdateRoom)
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


            if (clsRooms.IsRoomExsist(txtName.Text.Trim()) && Mode == enMode.AddNewRoom)
            {
                MessageBox.Show( "This Room is Created Before");
                return;
            }

            int RoomTypeID = clsRoomTypes.Find(cbRoomTypes.Text).RoomTypeID;
            int FloorID = clsFloors.Find(cbFloors.Text).FloorID;


            Room.RoomName = txtName.Text;
            Room.RoomPrice = decimal.Parse(txtRoomPrice.Text);
            Room.Persons = byte.Parse(txtAdult.Text);
            Room.Beds = byte.Parse(txtBeds.Text);

            Room.IsAvailable = ckAvalivale.Checked;

            Room.RoomTypeID = RoomTypeID;
            Room.FloorID = FloorID;


            if (Room.Save())
            {
                _RoomID = Room.RoomID;
                Mode = enMode.UpdateRoom;
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
            this.Close ();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            TextBox Txt = (TextBox)sender;

             if (clsRooms.IsRoomExsist(txtName.Text.Trim()) && Mode == enMode.AddNewRoom)
               {
                    e.Cancel = true;
                    errorProvider1.SetError(Txt, "This Room is Created Before");
                    return; 
               }
               else
               {
                   errorProvider1.SetError(Txt, "");
               }

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
