using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.main.Controls
{
    public partial class ctrlMainInfo : UserControl
    {
        public ctrlMainInfo()
        {
            InitializeComponent();
        }

        public void LoadMainInfo()
        {
            timer1.Start();
            lbTime.Text = DateTime.Now.ToString();
            lbUserName.Text = "Welcome : " + clsGlobal.CurrentUser.Name;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbTime.Text = DateTime.Now.ToString();
        }
    }
}
