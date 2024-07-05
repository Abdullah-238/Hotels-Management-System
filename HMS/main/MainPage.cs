using HMS.Bookings;
using HMS.Floors;
using HMS.Login;
using HMS.Rooms;
using HMS.RoomTypes;
using HMS.Statistics;
using HMS.Users;
using System;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;


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
            frmRoomsList BookList = new frmRoomsList();

            BookList.ShowDialog();

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

        private void applicationArchitectureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAllPages pages = new frmAllPages();

            pages.ShowDialog();
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void sendImailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Outlook.Application outlookApp = new Outlook.Application();
                Outlook.MailItem mailItem = (Outlook.MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
                mailItem.Subject = "";
                mailItem.To = "";
                mailItem.Body = "";
                mailItem.Importance = Outlook.OlImportance.olImportanceHigh;
                mailItem.Display(false);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ok", MessageBoxButtons.OK);
            }
        }

        private void changeWallpaperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog1.FileName;
                pcWallpaper.Load(selectedFilePath);
            }
        }

        private void removeHomeWallpaperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pcWallpaper.ImageLocation = null;
        }
    }
}
