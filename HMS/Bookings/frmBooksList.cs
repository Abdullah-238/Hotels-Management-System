using HMS.Rooms;
using HMS.Users;
using HMS_BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.Bookings
{
    public partial class frmBooksList : Form
    {
        static short  pageNumbr = 1,  rowsByPage = 3;

        static DataTable _dtAllBookings = clsBookings.GetAllBookings(pageNumbr,rowsByPage);

        static DataTable _dtBookings = _dtAllBookings;
        public frmBooksList()
        {
            InitializeComponent();
        }

        void _RefreshList()
        {
            _dtAllBookings = clsBookings.GetAllBookings(pageNumbr, rowsByPage);


            if (_dtAllBookings.Rows.Count > 0)
            { 

              _dtBookings = _dtAllBookings.DefaultView.ToTable(false, "BookID", "Name", "RoomID", "ArriveDate", "DepartureDate"
                                                                    , "Status", "BookingPrice");
                dgvBookings.DataSource = _dtBookings;

                dgvBookings.Columns[0].HeaderText = "Book ID";
                dgvBookings.Columns[0].Width = 100;

                dgvBookings.Columns[1].HeaderText = "Name";
                dgvBookings.Columns[1].Width = 100;

                dgvBookings.Columns[2].HeaderText = "Room ID";
                dgvBookings.Columns[2].Width = 100;

                dgvBookings.Columns[3].HeaderText = "Arrive Date";
                dgvBookings.Columns[3].Width = 200;

                dgvBookings.Columns[4].HeaderText = "Departure Date";
                dgvBookings.Columns[4].Width = 200;

                dgvBookings.Columns[5].HeaderText = "Status";
                dgvBookings.Columns[5].Width = 100;

                dgvBookings.Columns[6].HeaderText = "Booking Price";
                dgvBookings.Columns[6].Width = 150;


                lblRecordsCount.Text = dgvBookings.RowCount.ToString();
            }

        }

        private void frmBooksList_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;

            _RefreshList();

            if (clsHotelSettings.Find() != null)
            lbTimeOut.Text = clsHotelSettings.Find().DepartureTime.ToString() ;

            btPrevious.Enabled = false;

        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {

            frmRoomsList RoomList = new frmRoomsList();

            RoomList.ShowDialog();

            _RefreshList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

            frmBooksList_Load(null, null);

        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterValue = "";

            switch (cbFilterBy.SelectedItem)
            {
                case "None":
                    FilterValue = "None";
                    break;
                case "Room ID":
                    FilterValue = "RoomID";
                    break;
                case "Name":
                    FilterValue = "Name";
                    break;
            }

            if (txtFilterValue.Text == "" || FilterValue == "None")
            {
                _dtBookings.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvBookings.RowCount.ToString();
                return;
            }

            if (FilterValue == "RoomID")
                _dtBookings.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterValue, txtFilterValue.Text.Trim());

            else
                _dtBookings.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", FilterValue, txtFilterValue.Text.Trim());


            lblRecordsCount.Text = dgvBookings.RowCount.ToString();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Room ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //int UserID = (int)dgvBookings.CurrentRow.Cells[0].Value;

            //frmAddNewUser addUpdateUser = new frmAddNewUser(UserID);

            //addUpdateUser.ShowDialog();

            //_RefreshList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int BookID = (int)dgvBookings.CurrentRow.Cells[0].Value;

            if (MessageBox.Show("Are you sure want to Cancel this booking ?", "Warning"
                , MessageBoxButtons.OKCancel
                , MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsBookings.Cancel(BookID))
                {
                   if (clsRooms.SetRoomAvailable(clsBookings.Find(BookID).RoomID))
                        MessageBox.Show("booking Cancel successfully",
                       "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   else
                        MessageBox.Show("booking Cancel failed",
                      "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("booking Cancel failed",
                       "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                _RefreshList();
            }

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int BookID = (int)dgvBookings.CurrentRow.Cells[0].Value;

            frmAddNewBook addUpdateRoom = new frmAddNewBook(BookID);

            addUpdateRoom._RoomID = (int)dgvBookings.CurrentRow.Cells[2].Value;

            addUpdateRoom.ShowDialog();

            _RefreshList();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int BookID = (int)dgvBookings.CurrentRow.Cells[0].Value;

            frmBookInfo bookInfo = new frmBookInfo(BookID);

            bookInfo.ShowDialog();
        }

        private void btPrevious_Click(object sender, EventArgs e)
        {

            btForward.Enabled = true;

            pageNumbr--;

            if (pageNumbr == 1)
                btPrevious.Enabled = false;

            lbNumbers.Text = pageNumbr.ToString();

            _RefreshList();
        }

        private void btForward_Click(object sender, EventArgs e)
        {

            pageNumbr++;

            _RefreshList();

            lbNumbers.Text = pageNumbr.ToString();

            if (_dtAllBookings.Rows.Count < rowsByPage)
            {
                btForward.Enabled = false;
                return;
            }

            if (pageNumbr != 1)
                btPrevious.Enabled = true;
            else
                btPrevious.Enabled = false;


        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text != "None")
                txtFilterValue.Visible = true;
        }
    }
}
