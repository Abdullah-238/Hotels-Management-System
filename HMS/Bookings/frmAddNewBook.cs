using DVLD_Buisness;
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
    public partial class frmAddNewBook : Form
    {
        public class CompleteBooking 
        {
            public clsBookings Book { get;  }

            public CompleteBooking (clsBookings book)
            {
                this.Book = book; 
            }  
        }

        public void RaiseOnBookingCompleted(clsBookings Book)
        {
            RaiseOnBookingCompleted(new CompleteBooking(Book));
        }

        protected virtual void RaiseOnBookingCompleted(CompleteBooking e)
        {
            OnBookingCompleted?.Invoke(this, e);
        }

        public event EventHandler<CompleteBooking> OnBookingCompleted;


        clsBookings Book;

        clsGuests Gust;
 
        public int  _RoomID = -1;

        int _BookID = -1;

        int _GuestID = -1;
        enum enMode { AddNewBook, UpdateBook };

        enMode Mode = enMode.AddNewBook;

        public frmAddNewBook(int BookID)
        {
            InitializeComponent();

             Mode = enMode.UpdateBook;

            _BookID = BookID;

        }

        public frmAddNewBook()
        {
            InitializeComponent();

            Mode = enMode.AddNewBook;
        }

        private void _FillCountriesInComoboBox()
        {
            DataTable dtCountries = clsCountry.GetAllCountries();

            foreach (DataRow row in dtCountries.Rows)
            {
                cbCountry.Items.Add(row["CountryName"]);
            }
        }

        void _ResetDefaultValue()
        {
            if (Mode == enMode.AddNewBook)
            {
                lblTitle.Text = "Add New Book";
                this.Text = "Add New Book";
                Book = new clsBookings();
            }
            else
            {
                lblTitle.Text = "Update Book";
                this.Text = "Update Book";

            }

            _FillCountriesInComoboBox();

            txtPrice.Text = clsRooms.Find(_RoomID).RoomPrice.ToString();

            txtName.Text = "";
            rbMale.Checked = true;
            txtPhone.Text = "";
            cbCountry.SelectedIndex = cbCountry.FindString("Saudi Arabia");
            txtID.Text = "";
            txtTotalPrice.Text = "";
            btSignOut.Enabled = false;

           
            dtpArrive.MinDate = DateTime.Now;
            dtpDeparture.MinDate = DateTime.Now.AddDays(1);
            
           

            cbBookType.SelectedIndex = 0;

        }

        void _LoadData()
        {

            Book = clsBookings.Find(_BookID);

            if (Book == null)
            {
                MessageBox.Show("This bookings with " + _BookID + " is not found", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btSignOut.Enabled = true;
            txtName.Text = Book.Guest.Name;
            txtPhone.Text = Book.Guest.Phone;
            txtID.Text = Book.Guest.IDNumber.ToString();

            if (Book.Guest.Gender == 1)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;

            int CountryID = Book.Guest.CountryID;
            cbCountry.SelectedIndex = CountryID - 1;

            _RoomID = Book.RoomID;
            _GuestID = Book.GuestID;


            dtpArrive.MinDate = Book.ArriveDate;
            dtpArrive.Value = Book.ArriveDate;

            dtpDeparture.MinDate = Book.ArriveDate; 
            dtpDeparture.Value = Book.DepartureDate;

            cbBookType.SelectedIndex = Book.BookType;
            txtPrice.Text = clsRooms.Find(Book.RoomID).RoomPrice.ToString();
            txtTotalPrice.Text = Book.BookingPrice.ToString();
        }

        private void frmAddNewBook_Load(object sender, EventArgs e)
        {
            _ResetDefaultValue();

            if (Mode == enMode.UpdateBook)
                _LoadData();
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

        bool CreateNewGuest()
        {
            if (_GuestID != -1)
                Gust = clsGuests.Find(_GuestID);
            else
                Gust = new clsGuests();

            Gust.Phone = txtPhone.Text;
            Gust.Name = txtName.Text;

            if (rbMale.Checked)
                Gust.Gender = 1;
            else
                Gust.Gender = 0;

            int NationalityCountryID = clsCountry.Find(cbCountry.Text).ID;
            Gust.CountryID = NationalityCountryID;
            Gust.IDNumber = int.Parse(txtID.Text);
            
            if (!Gust.Save())
                return false ;

            _GuestID = Gust.GuestID; 
                return true;
        }

        void NotifyMessage ()
        {
            notifyIcon1.Icon = SystemIcons.Application;
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.BalloonTipText = "New booking added Successfully";
            notifyIcon1.BalloonTipTitle = "Done";
            notifyIcon1.ShowBalloonTip(1000);
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Fields are empty , Please Fill All required Fields to continue",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (dtpArrive.Value.CompareTo(dtpDeparture.Value) >= 0)
            {
                MessageBox.Show("Date of arrives can't be after Departure Date",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

                if (!CreateNewGuest())
                    return;;

            if (Mode != enMode.UpdateBook)
            NotifyMessage();

            Book.RoomID = _RoomID;
            Book.GuestID = _GuestID;
            Book.ArriveDate = dtpArrive.Value;
            Book.DepartureDate = dtpDeparture.Value.Date;
            Book.BookType = Convert.ToByte(cbBookType.SelectedIndex);
            Book.BookingPrice = decimal.Parse( txtTotalPrice.Text);
            Book.EmployeeID = clsGlobal.CurrentUser.UserID;

            clsRooms.SetRoomUnAvailable(_RoomID); 

            if (Book.Save())
            {
                if (OnBookingCompleted != null)
                    RaiseOnBookingCompleted(Book);

                _BookID = Book.BookID; 
                Mode = enMode.UpdateBook;
                MessageBox.Show("Data Saved Successfully", "Done", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                _LoadData();
            }
            else
            {
                MessageBox.Show("Data Saved Failed", "Error", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void CalculteTotalPrice(object sender, EventArgs e)
        {
            
            int TotalDays = Convert.ToInt16(dtpDeparture.Value.Subtract(dtpArrive.Value).TotalDays);

            decimal TotalPrice = TotalDays * clsRooms.Find(_RoomID).RoomPrice;

            if (dtpArrive.Value.CompareTo(dtpDeparture.Value) > 0)
                return; 

            txtTotalPrice.Text = TotalPrice.ToString();

            lbDays.Text = TotalDays.ToString();
        }

        private void btSignOut_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure want to sign out for this Guest ?", "Warning"
                , MessageBoxButtons.OKCancel , MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (Book.SignOut())
                {
                    if (clsRooms.SetRoomAvailable(_RoomID))
                         MessageBox.Show("Guest Sign out successfully",
                             "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Guest Sign out failed",
                       "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
       

        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {

            frmBookInfo bookInfo = new frmBookInfo(_BookID);

            this.Close();

            bookInfo.ShowDialog();


        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
    }
}
