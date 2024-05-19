using HMS.Bookings;
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

namespace HMS.Rooms
{
    public partial class ctrlRoom : UserControl
    {
        clsRooms _Room;

        int _RoomID = 0;

        clsBookings _Book;
        public ctrlRoom()
        {
            InitializeComponent();
        }

        public void LoadFloorInfo(int RoomID)
        {
            _RoomID = RoomID;

            _Room = clsRooms.Find(_RoomID);

            _Book = clsBookings.FindByRoom(RoomID);

            lbRoomName.Text = _Room.RoomName;
            lbFloor.Text = _Room.Floor.FloorName;
            lbPrice.Text = Convert.ToInt16(_Room.RoomPrice).ToString() + " R.S";
            lbBeds.Text = _Room.Beds.ToString();
            lbAdult.Text = _Room.Persons.ToString();
            lbRoomType.Text = _Room.RoomTypes.RoomTypeName; 

            if (_Room.IsRoomAvalibale())
            {
                lbIsAvalibale.Text = "Yes";
                BackColor = Color.Green;
                lbAvalibaleDate.Text = "Avalibale";
            }
            else
            {
                BackColor = Color.Red;
                lbIsAvalibale.Text = "No";

                if (_Book != null)
                    lbAvalibaleDate.Text = clsBookings.FindByRoom(RoomID).DepartureDate.ToString();
                else
                    lbAvalibaleDate.Text = "Room not Avalibale";
            }

        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNewRoom newRoom = new frmAddNewRoom(_RoomID);

            newRoom.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure want to delete this Room ?", "Warning"
              , MessageBoxButtons.OKCancel
              , MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsFloors.DeleteFloor(_RoomID))
                {
                    MessageBox.Show("Room deleted successfully",
                        "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Room deleted failed",
                       "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ctrlRoom_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            frmAddNewBook addNewBook = new frmAddNewBook();

            if (!_Room.IsRoomAvalibale())
            {
               MessageBox.Show("This room is'nt avalibale" , "Error" ,
                                MessageBoxButtons.OK , MessageBoxIcon.Error);
                return;
            }

            addNewBook._RoomID = _RoomID;

            addNewBook.ShowDialog();
        }

    }
}
