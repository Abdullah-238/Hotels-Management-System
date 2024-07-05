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
using QRCoder;
using Word = Microsoft.Office.Interop.Word;
using System.IO;
using Microsoft.SqlServer.Server;

namespace HMS.Bookings
{
    public partial class ctrlBookingInfo : UserControl
    {
        clsHotelSettings HotelSettings = clsHotelSettings.Find();

        int _BookID = 0;

        clsBookings _Book;

        public int BookID
        {
            get
            {
                return _BookID;
            }
        }

        public clsBookings Book
        {
            get
            {
                return _Book;
            }
        }

        public ctrlBookingInfo()
        {
            InitializeComponent();
        }

        void _ResetDefaultValue()
        {
            lbName.Text = "[????]";
            lbGender.Text = "[????]";
            lbCountry.Text = "[????]";
            lbID.Text = "[????]";
            lbPhone.Text = "[????]";

            lbArrive.Text = "[????]";
            lbDeprateure.Text = "[????]";
            lbDays.Text = "[????]";
            lbRoomNumber.Text = "[????]";
            lbPrice.Text = "[????]";
            lbRoomType.Text = "[????]";

        }

        void _FillInfoWithData()
        {

            lbName.Text = _Book.Guest.Name;

            if (_Book.Guest.Gender == 1) 
                lbGender.Text = "Male";
            else
                lbGender.Text = "Female";

            lbID.Text      = _Book.Guest.IDNumber.ToString();
            lbPhone.Text = _Book.Guest.Phone.ToString();
            lbCountry.Text = _Book.Guest.CountryInfo.CountryName;

            lbArrive.Text = _Book.ArriveDate.ToShortDateString();
            lbDeprateure.Text = _Book.DepartureDate.ToShortDateString();

            int TotalDays = Convert.ToInt16(_Book.DepartureDate.Subtract(_Book.ArriveDate).TotalDays);
            lbDays.Text = TotalDays.ToString();

            lbRoomNumber.Text = _Book.RoomID.ToString();
            lbPrice.Text = _Book.BookingPrice.ToString();
            lbRoomType.Text = _Book.Room.RoomTypes.RoomTypeName; 
        }

        public void LoadUserInfo(int BookID)
        {
            _BookID = BookID;

            _Book = clsBookings.Find(_BookID);

            if (_Book == null)
            {
                _ResetDefaultValue();

                MessageBox.Show("This Bookings with " + _BookID + "is not found", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _FillInfoWithData();
        }

        private void pbPrint_Click(object sender, EventArgs e)
        {
            if (_BookID == -1)
                return;


            printDocument1.Print();


            //Word.Application wordApp = new Word.Application();

            //wordApp.Visible = false;

            

            //Word.Document doc = wordApp.Documents.Add();
            //Word.Paragraph para = doc.Paragraphs.Add();
            //para.Range.Text =
            //    "\t\t\n" + HotelSettings.HotelName
            //    + "\t\t\n" + HotelSettings.Address
            //    + "\t\t\n" + HotelSettings.Phone;


            //doc.SaveAs2(filepath);
            //doc.Close();
            //doc.PrintOut();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
           Rectangle rect = new Rectangle(0, 320, 1000, 50);

           SolidBrush blueBrush = new SolidBrush(Color.DarkCyan);

            int NumbersOfDays = Book.DepartureDate.Day - Book.ArriveDate.Day; 

            e.Graphics.DrawString("\tInvoice", new Font("Poppins", 20, FontStyle.Bold), Brushes.DarkCyan, 280, 30);

            if (File.Exists( HotelSettings.ImagePath))
            e.Graphics.DrawImage(Image.FromFile(HotelSettings.ImagePath), 400, 100, 100, 100);

            e.Graphics.DrawString(
                "\t\t\n" + HotelSettings.HotelName
                + "\t\t\n" + HotelSettings.Address
                + "\t\t\n" + HotelSettings.Phone
                , new Font("Arial", 16, FontStyle.Regular), Brushes.Black, 350, 200);

            e.Graphics.FillRectangle(blueBrush, rect);

            e.Graphics.DrawString(

                "\nRoom Number : " + Book.Room.RoomName
              + "\n\nGuest : " + Book.Guest.Name
              + "\n\nArriving Date : " + Book.ArriveDate.ToString()
              + "\n\nDeparture Date : " + Book.DepartureDate.ToString()
              + "\n\nNumber of days : " + NumbersOfDays
              + "\n\nPrice : " + Book.BookingPrice.ToString()
              + "\n\nRoom Type : " + Book.Room.RoomTypes.RoomTypeName

              , new Font("Arial", 16, FontStyle.Regular), Brushes.Black, 50, 350) ;

            rect = new Rectangle(0, 720, 1000, 50);

            e.Graphics.FillRectangle(blueBrush, rect);

            QRCodeGenerator qRCode = new QRCodeGenerator();

            QRCodeData Data = qRCode.CreateQrCode(BookID.ToString(), QRCodeGenerator.ECCLevel.L);

            QRCode Code = new QRCode(Data);

            e.Graphics.DrawImage(Code.GetGraphic(5), 300, 780, 250, 250);

        }

    }
}
