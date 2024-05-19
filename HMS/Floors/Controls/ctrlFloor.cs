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
    public partial class ctrlFloor : UserControl
    {
        clsFloors Floor;

        string _Name = ""; 
        public ctrlFloor()
        {
            InitializeComponent();
        }

        public void LoadFloorInfo(string Name)
        {
            _Name = Name;

            Floor = clsFloors.Find(_Name);

            lbFloorName.Text = _Name;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure want to delete this Floor ?", "Warning"
               , MessageBoxButtons.OKCancel
               , MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsFloors.DeleteFloor(Floor.FloorID))
                {
                    MessageBox.Show("Floor deleted successfully",
                        "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Floor deleted failed",
                       "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNewFloor EditFloor = new frmAddNewFloor(Floor.FloorID);

            EditFloor.ShowDialog();
        }
    }
}
