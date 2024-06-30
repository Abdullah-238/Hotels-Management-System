using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.Login
{
    public partial class ucProgressBar : UserControl
    {
        public ucProgressBar()
        {
            InitializeComponent();
        }

       public void LoadProgress()
       {
            BackColor = Color.Transparent;

            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;
            progressBar1.Style = ProgressBarStyle.Marquee;

            for (int i = 0; i < 10; i++)
            {
                if (progressBar1.Value < progressBar1.Maximum)
                {
                    Thread.Sleep(100);
                    progressBar1.Value += 1; 
                    progressBar1.Refresh();
                }
            }

            this.Visible = false;
       }

    }
}
