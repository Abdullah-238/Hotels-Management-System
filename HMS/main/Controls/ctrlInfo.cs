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

        enInfoType _InfoType;
        public enum enInfoType
        {
            AvailableRooms = 1 , RoomsInfo = 2 ,  RoomsInfoByPercentage = 3 
        }

        public enInfoType InfoType
        {
            get
            {
                return _InfoType;
            }
            set
            {
                _InfoType = value;

                switch(_InfoType)
                {
                    case enInfoType.AvailableRooms:
                        {
                            LoadAvailableRoomsInfo();
                        }
                        break;
                    case enInfoType.RoomsInfo:
                        {
                            LoadAllRoomsInfo();
                        }
                        break;
                    case enInfoType.RoomsInfoByPercentage:
                        {
                            LoadAllRoomsInfoByPercentage();
                        }
                        break;
                }
            }
        }


         void LoadAvailableRoomsInfo()
        {
            int NumberOfAvailableRooms = clsRooms.GetAllAvalibaleRooms();

            lbTitle.Text = "Available Rooms";

            lbInfo.Text = NumberOfAvailableRooms.ToString();

            panel1.BackColor = Color.CadetBlue;

            BackColor = Color.CadetBlue;

        }
         void LoadAllRoomsInfo()
        {
            int NumberRooms = clsRooms.GetNumbersOfRooms();

            lbTitle.Text = "Number Of Rooms";

            lbInfo.Text = NumberRooms.ToString();

            panel1.BackColor = Color.DarkOliveGreen;

            BackColor = Color.DarkOliveGreen;

        }
         void LoadAllRoomsInfoByPercentage()
        {
            float NumberOfAvalibaleRooms = clsRooms.GetAllAvalibaleRooms();

            float NumberRooms = clsRooms.GetNumbersOfRooms();

            float PeecentageNumberOfAvailableRooms = NumberOfAvalibaleRooms / NumberRooms;

            PeecentageNumberOfAvailableRooms *= 100;

            lbTitle.Text = "Availability rooms";

            lbInfo.Text = PeecentageNumberOfAvailableRooms.ToString() + "%";

            if (PeecentageNumberOfAvailableRooms > 50) 
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
