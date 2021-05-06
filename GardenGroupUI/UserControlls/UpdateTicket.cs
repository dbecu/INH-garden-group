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
    public partial class UpdateTicket : UserControl, UserSelect
    {
        private Ticket ticket;
        private CurrentTickets mainForm;
        private User reportedByUser;

        public UpdateTicket(CurrentTickets mainForm, Ticket ticket)
        {
            InitializeComponent();
            this.ticket = ticket;
            this.mainForm = mainForm;
            cmbIncicentType.DataSource = Enum.GetValues(typeof(TypeOfIncident));
            cmbPriority.DataSource = Enum.GetValues(typeof(Priority));
            lblDeadLineError.Hide();
            try
            {
                reportedByUser = new UserService().GetById(ticket.ReportedBy);
                lblUsername.Text = reportedByUser.FirstName + " " + reportedByUser.LastName;
            }
            catch (Exception)
            {
                reportedByUser = null;
                lblUsername.Text = "deleted user";
            }

            txtSubject.Text = ticket.Subject;
            txtDescription.Text = ticket.Description;
            lblReportDate.Text = ticket.ReportedDate.ToString("dd/MM/yyyy H:mm");
            cmbIncicentType.SelectedItem = ticket.Type;
            cmbPriority.SelectedItem = ticket.Priority;
            cheSolved.Checked = ticket.IsSolved;
            try
            {
                dateDeadline.Value = ticket.Deadline;
            }
            catch (Exception)
            {
                dateDeadline.Value = dateDeadline.MinDate;
            }

            if (Session.Instance.LoggedInUser.TypeOfUser == TypeOfUser.EndUser)
            {
                btnChangeUser.Enabled = false;
                btnChangeUser.Visible = false;
            }
        }

        public void SetUser(User user)
        {
            lblUsername.Text = user.FirstName + " " + user.LastName;
            ticket.ReportedBy = user.Id;
            mainForm.Show();
            BringToFront();
        }

        public void SelectCancelled()
        {
            mainForm.Show();
            BringToFront();
        }

        private void btnUpdateTicket_Click(object sender, EventArgs e)
        {
            TicketService ticketService = new TicketService();

            ticketService.UpdateTicket(ticket);
            mainForm.ChangedListSort();
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Close()
        {
            mainForm.DisplayAllTickets();
            mainForm.Show();
            mainForm.UCUpdateTicket.Dispose();
            mainForm.UCUpdateTicket = null;
        }

        private void dateDeadline_ValueChanged(object sender, EventArgs e)
        {
            if (dateDeadline.Value.Date < ticket.ReportedDate)
                lblDeadLineError.Show();
            else
            {
                lblDeadLineError.Hide();
                ticket.Deadline = dateDeadline.Value.Date;
            }
        }

        private void txtSubject_TextChanged(object sender, EventArgs e)
        {
            if (txtSubject == null)
                return;
            ticket.Subject = txtSubject.Text;
        }

        private void cmbIncicentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbIncicentType == null)
                return;

            ticket.Type = (TypeOfIncident)cmbIncicentType.SelectedIndex;
        }

        private void cmbPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPriority == null)
                return;

            ticket.Priority = (Priority)cmbPriority.SelectedIndex;
        }

        private void cheSolved_CheckedChanged(object sender, EventArgs e)
        {
            if (cheSolved == null)
                return;
            ticket.IsSolved = cheSolved.Checked;
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            if (txtDescription == null)
                return;
            ticket.Description = txtDescription.Text.Replace("\n", "\r\n"); ;
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
