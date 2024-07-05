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

namespace HMS.Statistics
{
    public partial class frmStatistics : Form
    {
        public static DataTable dtAllStatices = clsStatistic.GetAllStatistic();

        public frmStatistics()
        {
            InitializeComponent();
        }

        void LoadChartsData()
        {
            if (rbTotalPrices.Checked)
            {
                chart1.Series[0].XValueMember = "Room Number";
                chart1.Series[0].YValueMembers = "Total prices";
                chart1.Series[0].Name = "Total prices";
                chart1.Series[0].Color = Color.Green;
            }

            if (rbNumberofBookings.Checked)
            {
                chart1.Series[0].XValueMember = "Room Number";
                chart1.Series[0].YValueMembers = "Number Of Booking";
                chart1.Series[0].Name = "Number Of Booking";
                chart1.Series[0].Color = Color.Blue;

            }
        }


        private void frmStatistics_Load(object sender, EventArgs e)
        {
            chart1.DataSource = dtAllStatices;

            LoadChartsData();
        }

        private void LoadChartsData(object sender, EventArgs e)
        {
            LoadChartsData();
        }
    }
}
