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

namespace HMS
{
    public partial class frmHotelSettings : Form
    {
        clsHotelSettings HotelSettings = clsHotelSettings.Find();

        public frmHotelSettings()
        {
            InitializeComponent();
        }

     

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Feilds are empty , " +
                    "Please Fill All required Feilds to continue",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            byte HoursArrive = (byte)nupArriaveTime.Value;
            byte HourDeparture  =(byte) nupDepartureTime.Value;
            string HotelName = txtHotelName.Text.Trim();
            string Address = txtAddress.Text.Trim();
            string Phone = txtPhone.Text.Trim();
            string ImageLocation = "";
            if (pcHotelImage.ImageLocation != null)
                 ImageLocation = pcHotelImage.ImageLocation;


            if (HotelSettings == null)
            {
                if (clsHotelSettings.AddNew(HotelName,HoursArrive, HourDeparture,
                    ImageLocation,Address,Phone))
                    MessageBox.Show("Time Added Succefully", "Done",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Time Added Faild", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (clsHotelSettings.Update(HotelName, HoursArrive, HourDeparture,
                    ImageLocation, Address, Phone))
                    MessageBox.Show("Time Updated Succefully", "Done",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Time Updated Faild", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }
           

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTimeSettings_Load(object sender, EventArgs e)
        {

            if (HotelSettings != null)
            {
                nupArriaveTime.Value = HotelSettings.ArriveTime;

                nupDepartureTime.Value =HotelSettings.DepartureTime;

                txtHotelName.Text = HotelSettings.HotelName;

                txtPhone.Text = HotelSettings.Phone;

                txtAddress.Text = HotelSettings.Address;

                if (HotelSettings.ImagePath != "")
                    pcHotelImage.ImageLocation = HotelSettings.ImagePath; 
            }    
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            TextBox Txt = (TextBox)sender;
            if (string.IsNullOrEmpty(Txt.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(Txt, "This field shouldn't be empty");
            }
            else
            {
                errorProvider1.SetError(Txt, "");
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog1.FileName;
                pcHotelImage.Load(selectedFilePath);
                llRemoveImage.Visible = true;
            }
        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pcHotelImage.ImageLocation = null;
        }
    }
}
