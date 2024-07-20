using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.Users.Controls
{
    public partial class UsersList : UserControl
    {
        public UsersList()
        {
            InitializeComponent();
        }

        public void LoadUserList(DataTable dtUserList)
        {
            //if (dtUserList != null)
            //{
            //    Label lblUsersName = new Label();

            //    int i = 0;

            //   foreach(DataRow dr in dtUserList.Rows)
            //    {

            //        lblUsersName.Text = dr["Name"].ToString();

            //        flowLayoutPanel1.Controls.Add(lblUsersName);

            //        i++;
            //    }
            //}

           
        }
    }
}
