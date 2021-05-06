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
    public partial class NewTicket : UserControl, UserSelect
    {
        private CurrentTickets mainForm;
        private User reportedByUser;

        public NewTicket(CurrentTickets mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            cmbIncicentType.DataSource = Enum.GetValues(typeof(TypeOfIncident));
            cmbPriority.DataSource = Enum.GetValues(typeof(Priority));
            numReportHour.Value = dateReported.Value.Hour;
            numReportMinute.Value = dateReported.Value.Minute;
            dateDeadline.Value = DateTime.Now;
            lblUserSelectError.Hide();
            lblDeadLineError.Hide();

            if(Session.Instance.LoggedInUser.TypeOfUser == TypeOfUser.EndUser)
            {
                btnChangeUser.Enabled = false;
                btnChangeUser.Visible = false;

                SetUser(Session.Instance.LoggedInUser);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCreateTicket_Click(object sender, EventArgs e)
        {
            if(reportedByUser == null)
            {
                lblUserSelectError.Show();
                return;
            }
            if (dateDeadline.Value.Date < dateReported.Value.Date)
                return;

            txtDescription.Text.Replace("\n", "\r\n");
            DateTime reportedDateTime = dateReported.Value.Date + new TimeSpan((int)numReportHour.Value, (int)numReportMinute.Value, 0);
            Ticket ticket = new Ticket(
                txtSubject.Text,
                txtDescription.Text,
                reportedByUser.Id,
                reportedDateTime,
                dateDeadline.Value.Date,
                (TypeOfIncident)cmbIncicentType.SelectedIndex,
                (Priority)cmbPriority.SelectedIndex
            );
            TicketService ticketService = new TicketService();
            ticketService.CreateTicket(ticket);
            mainForm.ChangedListSort();
            Close();
        }

        public void SetUser(User user)
        {
            reportedByUser = user;
            lblUsername.Text = user.FirstName + " " + user.LastName;
            mainForm.Show();
            BringToFront();
        }

        private void Close()
        {
            mainForm.DisplayAllTickets();
            mainForm.Show();
            mainForm.UCNewIncident.Dispose();
            mainForm.UCNewIncident = null;
        }

        public void SelectCancelled()
        {
            mainForm.Show();
            BringToFront();
        }

        private void numReportHour_ValueChanged(object sender, EventArgs e)
        {
            if (numReportHour.Value == 24)
            {
                numReportHour.Value = 0;
            }
            if (numReportHour.Value == -1)
            {
                numReportHour.Value = 23;
            }
        }

        private void numReportMinute_ValueChanged(object sender, EventArgs e)
        {
            if (numReportMinute.Value == 60)
            {
                numReportMinute.Value = 0;
            }
            if (numReportMinute.Value == -1)
            {
                numReportMinute.Value = 59;
            }
        }

        private void dateDeadline_ValueChanged(object sender, EventArgs e)
        {
            if(dateDeadline.Value.Date < dateReported.Value.Date)
                lblDeadLineError.Show();
            else
                lblDeadLineError.Hide();
        }
        private void dateReported_ValueChanged(object sender, EventArgs e)
        {
            if (dateDeadline.Value.Date < dateReported.Value.Date)
                lblDeadLineError.Show();
            else
                lblDeadLineError.Hide();
        }

        private void btnChangeUser_Click(object sender, EventArgs e)
        {
            UserSelection UCUS = new UserSelection(this);
            mainForm.Parent.Controls.Add(UCUS);
            mainForm.Hide();
            UCUS.BringToFront();
        }
    }
}
