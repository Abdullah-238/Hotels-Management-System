using HMS.Bookings;
using HMS.Rooms;
using HMS.Users;
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

namespace HMS
{
    public partial class frmAllPages : Form
    {
        public frmAllPages()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            switch(treeView1.SelectedNode.Text)
            {
                case "Add New User":
                    {
                        frmAddNewUser frmAddNewUser = new frmAddNewUser();
                        frmAddNewUser.ShowDialog();
                        break;
                    }
                case "Users List":
                    {
                        frmUsersList frmUsers = new frmUsersList();
                        frmUsers.ShowDialog();
                        break;
                    }
                case "Add New Room":
                    {
                         frmAddNewRoom AddNewRoom  = new frmAddNewRoom();
                        AddNewRoom.ShowDialog();
                        break;
                    }
                case "Room List":
                    {
                        frmRoomsList frmRoom = new frmRoomsList();
                        frmRoom.ShowDialog();
                        break;
                    }
                
                case "Bookings List":
                    {
                        frmBooksList BookingsList = new frmBooksList();
                        BookingsList.ShowDialog();
                        break;
                    }

            }
        }

        private void frmAllPages_Load(object sender, EventArgs e)
        {
            
        }
    }
}
