using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GardenGroupDAO;
using GardenGroupModel;

namespace GardenGroupLogic
{
    public class TicketService
    {
        TicketDAO ticketDAO;

        public TicketService()
        {
            ticketDAO = new TicketDAO();
        }

        public void CreateTicket(Ticket ticket)
        {
            ticketDAO.Create(ticket);
        }

        public Ticket FindById(string id)
        {
            return ticketDAO.FindById(id);
        }

        public void DeleteTicket(string id)
        {
            ticketDAO.Delete(id);
        }

        public void UpdateTicket(Ticket ticket)
        {
            if (ticket.Id == null)
                return;
            ticketDAO.Update(ticket.Id, ticket);
        }

        public void UpdateTicket(string id, Ticket ticket)
        {
            ticket.Id = id;
            UpdateTicket(ticket);
        }

        // (MVL)
        public void ArchiveTickets()
        {
            ticketDAO.ArchiveData();
        }


        //(DB) - Additional functionality - sorting by priority
        public List<Ticket> GetAllSortedById()
        {
            return ticketDAO.GetAllSortedById();
        }

        public List<Ticket> GetAllSortedByPriority()
        {
            return ticketDAO.GetAllSortedByPriority();
        }

        public List<Ticket> GetAllSortedByDateReported()
        {
            return ticketDAO.GetAllSortedByDateReported();
        }

        public List<Ticket> GetAllSortedByDeadline()
        {
            return ticketDAO.GetAllSortedByDeadline();
        }

        public List<Ticket> GetAllSortedBySolved()
        {
            return ticketDAO.GetAllSortedBySolved();
        }

        //(DB) For end-user
        public List<Ticket> GetFromUserSortedById(User user)
        {
            return ticketDAO.GetUsersTicketsSortedByID(user);
        }
        public List<Ticket> GetFromUserSortedByPriority(User user)
        {
            return ticketDAO.GetUsersTicketsSortedByPriority(user);
        }

        public List<Ticket> GetFromUserAllSortedByDateReported(User user)
        {
            return ticketDAO.GetUsersTicketsAllSortedByDateReported(user);
        }

        public List<Ticket> GetFromUserAllSortedByDeadline(User user)
        {
            return ticketDAO.GetUsersTicketsAllSortedByDeadline(user);
        }

        public List<Ticket> GetFromUserAllSortedBySolved(User user)
        {
            return ticketDAO.GetUsersTicketsAllSortedBySolved(user);
        }

    }
}
