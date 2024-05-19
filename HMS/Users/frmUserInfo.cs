using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.Users
{
    public partial class frmUserInfo : Form
    {
        int _UserID = -1; 
        public frmUserInfo(int UserID)
        {
            InitializeComponent();

           _UserID = UserID;
        }

        private void frmUserInfo_Load(object sender, EventArgs e)
        {
            ctrlUserInfo1.LoadUserInfo(_UserID);
        }
    }
}
