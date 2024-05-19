using HMS.Bookings;
using HMS.Floors;
using HMS.Login;
using HMS.Rooms;
using HMS.RoomTypes;
using HMS.Statistics;
using HMS.Users;
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
    public partial class MainPage : Form
    {
        frmLogin _Login; 
        public MainPage(frmLogin Login)
        {
            InitializeComponent();

            _Login = Login;
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsersList UsersList = new frmUsersList();

            UsersList.ShowDialog();

            MainPage_Load(null, null);

        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            ctrlInfo1.LoadAllRoomsInfo();
            ctrlInfo2.LoadAvailbaleRoomsInfo();
            ctrlInfo3.LoadAllRoomsInfoByPersent();
            ctrlCurrencyEchange1.LoadCurrenciesExChange();
            ctrlMainInfo1.LoadMainInfo();
        }

        private void roomTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRoomTypesList editRoomType = new frmRoomTypesList();

            editRoomType.ShowDialog();

            MainPage_Load(null, null);
        }

        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRoomsList newRoom = new frmRoomsList();

            newRoom.ShowDialog();

            MainPage_Load(null, null);
        }

        private void floorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFloorsList floorsList = new frmFloorsList();

            floorsList.ShowDialog();

            MainPage_Load(null, null);
        }

        private void bookRoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRoomsList addNewBook = new frmRoomsList(); 

            addNewBook.ShowDialog();

            MainPage_Load(null, null);
        }

        private void bookingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBooksList booksList = new frmBooksList();

            booksList.ShowDialog();

            MainPage_Load(null, null);

        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {

            clsGlobal.CurrentUser = null;

            _Login.Show();

            this.Close();
        }

        private void timeSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHotelSettings TimeSettings = new frmHotelSettings();

            TimeSettings.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword changePassword = new frmChangePassword(clsGlobal.CurrentUser.UserID);

            changePassword.ShowDialog();
        }

        private void signOutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;

            _Login.Show();

            this.Close();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo userInfo = new frmUserInfo(clsGlobal.CurrentUser.UserID);   

            userInfo.ShowDialog();

        }

        private void staticesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStatistics statistics = new frmStatistics();

            statistics.ShowDialog();
        }
    }
}
