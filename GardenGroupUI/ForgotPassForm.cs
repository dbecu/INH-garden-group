using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using GardenGroupLogic;

namespace GardenGroupUI
{
    public partial class ForgotPassForm : Form
    {
        private string emailId;
        UserService userService = new UserService();
        public ForgotPassForm(string email)
        {
            InitializeComponent();
            this.emailId = email;
        }

        private void ForgotPassForm_Load(object sender, EventArgs e)
        {
            tb_forgotEmail.Text = emailId;
        }

        private void btn_resetLink_Click(object sender, EventArgs e)
        {
            //checks if the textbox is empty or not,if filled then goes ahead
            if (!string.IsNullOrEmpty(tb_forgotEmail.Text))
            {
                //using regex to check if email is valid

                Regex rEmail = new Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");

                if (!rEmail.IsMatch(tb_forgotEmail.Text.Trim()))
                {
                    MessageBox.Show("Email must be a valid email!", "Unsuccessfull", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //use the name from login form for changing stuff
                    string email = tb_forgotEmail.Text;
                    userService.SendEmail(email);
                    MessageBox.Show("An email was sent to the provided email address.Also, check your spam folder!", "Successfull.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tb_forgotEmail.Clear();
                }
            }
        }   
    }
}
