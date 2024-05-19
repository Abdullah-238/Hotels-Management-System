using HMS.Floors;
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
    public partial class frmRoomsList : Form
    {
        public frmRoomsList()
        {
            InitializeComponent();
        }


        void FillLayoutWithItems()
        {
            DataTable _dtRooms = clsRooms.GetAllRooms();

            int RoomID;

            foreach (DataRow dr in _dtRooms.Rows)
            {
                RoomID = (int)dr["RoomID"];

                ctrlRoom ucRoom = new ctrlRoom();

                ucRoom.LoadFloorInfo(RoomID);

                flpRooms.Controls.Add(ucRoom);
            }
        }

        private void frmRoomsList_Load(object sender, EventArgs e)
        {
            FillLayoutWithItems();

        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddNewRoom newRoom = new frmAddNewRoom();

            newRoom.ShowDialog();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
