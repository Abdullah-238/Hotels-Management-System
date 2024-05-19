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

namespace HMS.Floors
{
    public partial class frmFloorsList : Form
    {
        public frmFloorsList()
        {
            InitializeComponent();
        }

        void FillLayoutWithItems()
        {
            DataTable _dtFloors = clsFloors.GetAllFloors();

            string FloorName;

            foreach (DataRow dr in _dtFloors.Rows)
            {
                FloorName = (string)dr["FloorName"];

                ctrlFloor ucFloor = new ctrlFloor();

                ucFloor.LoadFloorInfo(FloorName);

                flpFloors.Controls.Add(ucFloor);
            }
        }

        private void frmFloorsList_Load(object sender, EventArgs e)
        {

            FillLayoutWithItems();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddNewFloor newFloor = new frmAddNewFloor();

            newFloor.ShowDialog();

        }
    }
}
