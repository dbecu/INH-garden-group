using System;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GardenGroupLogic;
using GardenGroupModel;
using System.Web;

namespace GardenGroupUI
{
    public partial class LoginForm : Form
    {
        UserService userService = new UserService();
        List<User> users;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            string username = tb_Username.Text;
            string password = tb_Password.Text;

            RememberCredentials();

            users = userService.GetAll();
            int userIndex = users.FindIndex(user => user.Email == tb_Username.Text);

            try
            {
                if (tb_Username.Text == "" || tb_Password.Text == "")
                {
                    MessageBox.Show("Please enter a username and password.", "Login Unsuccessful",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
                else if (userIndex >= 0)
                {
                    if (users[userIndex].Password == tb_Password.Text)
                    {
                        DialogResult result = MessageBox.Show("Login Successfull", "Sucessfully logged in!",
                           MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                    if(result == DialogResult.OK)
                    {
                        Session.Instance.LoggedInUser = users[userIndex];

                        this.Hide();
                        MainForm mainform = new MainForm();
                        mainform.Closed += (s, args) => this.Close();
                        mainform.ShowDialog();

                        }
                    }
                    else
                    {
                        MessageBox.Show("Login unsuccessfull", "Can't login! Incorrect password!",
                           MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception excp)
            {
                MessageBox.Show("Something went wrong!");
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.UserName != string.Empty)
            {
                tb_Username.Text = Properties.Settings.Default.UserName;
                tb_Password.Text = Properties.Settings.Default.Password;
            }
        }

        //If checkbox is checked, then remembers the credentials for next time 
        private void RememberCredentials()
        {
            if(cb_RemeberMe.Checked)
            {
                Properties.Settings.Default.UserName = tb_Username.Text;
                Properties.Settings.Default.Password = tb_Password.Text;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.UserName = "";
                Properties.Settings.Default.Password = "";
                Properties.Settings.Default.Save();
            }
        }

        //opens a new form when the forget details link is clicked
        private void ll_forgotdetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPasswordForm forgotPasswordForm = new ForgotPasswordForm(tb_Username.Text);
            forgotPasswordForm.Show();
        }

    }
}
