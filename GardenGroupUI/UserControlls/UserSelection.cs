using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GardenGroupModel;
using GardenGroupLogic;

namespace GardenGroupUI.UserControlls
{
    // (SK) Individual/Additional Functionality
    public partial class UserSelection : UserControl
    {
        private List<User> users;
        private UserService userService = new UserService();
        private UserSelect mainWindowInterface;

        //This is the screen for changing the assigned user which is part of the extra functionality done by Sjoerd
        public UserSelection(UserSelect mainWindowInterface)
        {
            InitializeComponent();
            this.mainWindowInterface = mainWindowInterface;
            users = userService.GetAll();
            listViewUsers.Items.Clear();

            foreach (User user in users)
            {
                string[] fields = new string[]
                {
                    user.FirstName,
                    user.LastName,
                    user.Email
                };
                ListViewItem li = new ListViewItem(fields);
                li.Tag = user;
                listViewUsers.Items.Add(li);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            mainWindowInterface.SelectCancelled();
            Dispose();
        }

        private void btnSelectUser_Click(object sender, EventArgs e)
        {
            User selectedUser = (User)listViewUsers.SelectedItems[0].Tag;
            mainWindowInterface.SetUser(selectedUser);
            Dispose();
        }

        private void UserSelection_Load(object sender, EventArgs e)
        {

        }
    }
}
