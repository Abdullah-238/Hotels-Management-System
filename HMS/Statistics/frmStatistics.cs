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
        public frmStatistics()
        {
            InitializeComponent();
        }

        private void frmStatistics_Load(object sender, EventArgs e)
        {
            dgvStatistics.DataSource = clsStatistic.GetAllStatistic();

            if (dgvStatistics.Rows.Count > 0 )
            {
                dgvStatistics.Columns[0].Width = 120;
                dgvStatistics.Columns[1].Width = 120;
                dgvStatistics.Columns[2].Width = 120;

            }

        }
    }
}
