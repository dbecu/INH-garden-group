using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using GardenGroupLogic;

namespace GardenGroupUI
{

    // (TA) Individual/Additional functionality
    public partial class ForgotPasswordForm : Form
    {
        private string email;
        UserService userService = new UserService();

        public ForgotPasswordForm(string email)
        {
            InitializeComponent();
            this.email = email;
        }

        private void btn_resetpass_Click(object sender, EventArgs e)
        {
            //checks if the textbox is empty or not,if filled then goes ahead
            if (!string.IsNullOrEmpty(tb_forgotPassEmail.Text))
            {
                //checking if email is valid

                Regex rEmail = new Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");

                if (!rEmail.IsMatch(tb_forgotPassEmail.Text.Trim()))
                {
                    MessageBox.Show("Email must be a valid email!", "Unsuccessfull", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //use the name from login form for changing stuff
                    string email = tb_forgotPassEmail.Text;
                    userService.SendEmail(email);
                    this.Close();
                    MessageBox.Show("An email was successfully sent to the provided email address. Also check your spam folder!", "Email successfully sent!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tb_forgotPassEmail.Clear();
                }
            }
            else
            {
                MessageBox.Show("Please enter your email!","Unsucessful!",MessageBoxButtons.RetryCancel,MessageBoxIcon.Warning);
            }
        }

        private void ForgotPasswordForm_Load(object sender, EventArgs e)
        {
            tb_forgotPassEmail.Text = email;
        }
    }
}
