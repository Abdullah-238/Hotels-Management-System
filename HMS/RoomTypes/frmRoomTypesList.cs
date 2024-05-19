using HMS.Users;
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

namespace HMS.RoomTypes
{
    public partial class frmRoomTypesList : Form
    {
        static DataTable _dtAllRoomTypes = clsRoomTypes.GetAllRoomTypes();

        
        public frmRoomTypesList()
        {
            InitializeComponent();
        }

        void _RefreshList()
        {
            _dtAllRoomTypes = clsRoomTypes.GetAllRoomTypes();

            dgvRoomTypes.DataSource = _dtAllRoomTypes;
        }
        private void frmRoomTypesList_Load(object sender, EventArgs e)
        {

            dgvRoomTypes.DataSource = _dtAllRoomTypes;
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddEditRoomType addUpdateRoomTypes = new frmAddEditRoomType();

            addUpdateRoomTypes.ShowDialog();

            _RefreshList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int RoomTypesID = (int)dgvRoomTypes.CurrentRow.Cells[0].Value;

            frmAddEditRoomType addUpdateRoomTypes = new frmAddEditRoomType(RoomTypesID);

            addUpdateRoomTypes.ShowDialog();

            _RefreshList();
        }

     
            
    }
}
