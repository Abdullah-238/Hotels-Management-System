using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.main.Controls
{
    public partial class ctrlMainInfo : UserControl
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEM_POWER_STATUS
        {
            public byte ACLineStatus;
            public byte BatteryFlag;
            public byte BatteryLifePercent;
            public byte Reserved1;
            public int BatteryLifeTime;
            public int BatteryFullLifeTime;
        }

        // Import the GetSystemPowerStatus API from kernel32.dll
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool GetSystemPowerStatus(out SYSTEM_POWER_STATUS sps);

        public ctrlMainInfo()
        {
            InitializeComponent();
        }

        // Helper method to decode the BatteryFlag
        static string GetBatteryStatus(byte flag)
        {
            switch (flag)
            {
                case 1:
                    return "High, more than 66% charged";
                case 2:
                    return "Low, less than 33% charged";
                case 4:
                    return "Critical, less than 5% charged";
                case 8:
                    return "Charging";
                case 128:
                    return "No battery";
                case 255:
                    return "Unknown status";
                default:
                    return "Battery status not detected";
            }
        }

        void BatteryInfo()
        {
            if (GetSystemPowerStatus(out SYSTEM_POWER_STATUS status))
            {
                lbBattery.Text = (status.BatteryLifePercent == 255 ? "Unknown" : status.BatteryLifePercent + "%");
                 lbIsChargeing.Text =  status.ACLineStatus == 0 ? "No" : "Yes";

            }
        }


        public void LoadMainInfo()
        {
            timer1.Start();
            lbUserName.Text = "Welcome : " + clsGlobal.CurrentUser.Name;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            BatteryInfo();
            lbTime.Text = DateTime.Now.ToString();
        }

        private void lbIsChargeing_Click(object sender, EventArgs e)
        {

        }
    }
}
