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

namespace HMS.Bookings
{
    public partial class frmBookInfo : Form
    {

        int _BookID = 0;
        public frmBookInfo(int BookID)
        {
            InitializeComponent();

            _BookID = BookID;
        }

        private void frmBookInfo_Load(object sender, EventArgs e)
        {
            ctrlBookingInfo1.LoadUserInfo(_BookID);
        }

      
    }
}
