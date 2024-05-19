using HMS_BusinessLogic;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.Main
{
    public partial class ctrlInfo : UserControl
    {
        public ctrlInfo()
        {
            InitializeComponent();
        }


        public void LoadAvailbaleRoomsInfo()
        {
            int NumberOfAvalibaleRooms = clsRooms.GetAllAvalibaleRooms();

            lbTitle.Text = "Avalibale Rooms";

            lbInfo.Text = NumberOfAvalibaleRooms.ToString();

            panel1.BackColor = Color.CadetBlue;

            BackColor = Color.CadetBlue;

        }
        public void LoadAllRoomsInfo()
        {
            int NumberRooms = clsRooms.GetNumbersOfRooms();

            lbTitle.Text = "Number Of Rooms";

            lbInfo.Text = NumberRooms.ToString();

            panel1.BackColor = Color.DarkOliveGreen;

            BackColor = Color.DarkOliveGreen;

        }
        public void LoadAllRoomsInfoByPersent()
        {
            float NumberOfAvalibaleRooms = clsRooms.GetAllAvalibaleRooms();

            float NumberRooms = clsRooms.GetNumbersOfRooms();

            float PrecntageNumberOfavalibaleRooms = NumberOfAvalibaleRooms / NumberRooms;

            PrecntageNumberOfavalibaleRooms *= 100;

            PrecntageNumberOfavalibaleRooms = Convert.ToInt16(PrecntageNumberOfavalibaleRooms);

            lbTitle.Text = "Availability rooms";

            lbInfo.Text = PrecntageNumberOfavalibaleRooms.ToString() + "%";

            if (PrecntageNumberOfavalibaleRooms > 50) 
            {
                panel1.BackColor = Color.Green; 

                BackColor = Color.Green;
            }
            else
            {
                panel1.BackColor = Color.Red;

                BackColor = Color.Red;
            }
        }
    }
}
