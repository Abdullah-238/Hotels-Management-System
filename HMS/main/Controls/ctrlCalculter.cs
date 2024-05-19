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
    public partial class ctrlCalculter : UserControl
    {
        public ctrlCalculter()
        {
            InitializeComponent();
        }

        public void LoadCaluctor()
        {
            cbSigns.SelectedIndex = 0; 
        }


        void Caluclte()
        {

            string Sign = cbSigns.SelectedItem.ToString();
            float Num1= 0;
            float Num2 = 0; 
            float Result = 0;


            Num1 = float.Parse(txtNum1.Text);
            Num2 = float.Parse(txtNum2.Text);

            switch (Sign)
            {
                case  "+" :
                    Result = Num1 + Num2;
                    break;
                case  "-" :
                    Result = Num1 - Num2;
                    break;
                case  "*" :
                    Result = Num1 * Num2;
                    break;
                case  "/" :
                    Result = Num1 / Num2;
                    break;
            }

            txResult.Text = Result.ToString();
        }

        private void txtNum2_TextChanged(object sender, EventArgs e)
        {
            if (txtNum1.Text != "" && txtNum2.Text != "")
            Caluclte();

        }

        private void txtNum1_TextChanged(object sender, EventArgs e)
        {
            if (txtNum1.Text != "" && txtNum2.Text != "")
                Caluclte();
        }

        private void cbSigns_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtNum1.Text != "" && txtNum2.Text != "")
                Caluclte();
        }
    }
}
