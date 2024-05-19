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

namespace HMS.main
{
    public partial class ctrlCurrencyEchange : UserControl
    {
        public ctrlCurrencyEchange()
        {
            InitializeComponent();
        }

        public void LoadCurrenciesExChange()
        {
          DataTable dtCurrencies = clsCurrencies.GetAllCurrencies();

            foreach(DataRow dr in dtCurrencies.Rows)
            {
                cbFrom.Items.Add(dr["Code"]);
                cbTo.Items.Add(dr["Code"]);
            }

            cbFrom.SelectedIndex = 115;
            cbTo.SelectedIndex = 139;
            ctrlCalculter1.LoadCaluctor();
        }

        void CalculteCurrencyRate()
        {
            double Amount = 0;
            double Result = 0;
            double CurrencyRate = 0; 

            clsCurrencies Currencies1 = clsCurrencies.Find(cbFrom.SelectedItem.ToString().Trim());

            clsCurrencies Currencies2 = clsCurrencies.Find(cbTo.SelectedItem.ToString().Trim());

            if (txAmount.Text != "")
            {
               Amount = double.Parse(txAmount.Text.Trim());

               CurrencyRate = Currencies2.Rate / Currencies1.Rate;

               Result = Amount * CurrencyRate;
               txResult.Text = Result.ToString();
            }
        }

      
        private void txAmount_TextChanged(object sender, EventArgs e)
        {
            CalculteCurrencyRate();
        }

        private void txAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cbFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculteCurrencyRate();

        }

        private void cbFrom_SelectedIndexChanged_1(object sender, EventArgs e)
        {
          
        }

        private void cbTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculteCurrencyRate();

        }

        private void pcConvertCurrency_Click(object sender, EventArgs e)
        {
            int Currency1 = 0; int Currency2 = 0; int empty = 0;

            Currency1 = cbFrom.SelectedIndex;
            Currency2 = cbTo.SelectedIndex;

            empty = Currency2;
            Currency2 = Currency1;
            Currency1 = empty;

            cbFrom.SelectedIndex = Currency1;
            cbTo.SelectedIndex = Currency2;

            CalculteCurrencyRate();
        }
    }
}
