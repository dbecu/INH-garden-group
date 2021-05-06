using GardenGroupModel;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GardenGroupDAO
{
    public class TicketDAO : BaseDAO, ITicketDAO
    {
        private readonly string TABLE_NAME = "Incidents";
        // (MVL)
        public void Create(Ticket newTicket)
        {
            db.InsertDocument<Ticket>(TABLE_NAME, newTicket);
        }

        // (MVL)
        public void Delete(string id)
        {
            db.DeleteDocument<Ticket>(TABLE_NAME, id);
        }

        // (MVL)
        public List<Ticket> FindByBranch(string branch)
        {
            var filter = Builders<Ticket>.Filter.Eq("Branch", branch);
            return db.FindByQuery<Ticket>(TABLE_NAME, filter).ToList();
        }

        // (MVL)
        public Ticket FindById(string id)
        {
            return db.GetDocumentById<Ticket>(TABLE_NAME, id);
        }

        // (MVL)
        public List<Ticket> FindByType(TypeOfIncident type)
        {
            var filter = Builders<Ticket>.Filter.Eq("Type", type);
            return db.FindByQuery<Ticket>(TABLE_NAME, filter).ToList();
        }

        // (MVL)
        public List<Ticket> GetAll()
        {
            return db.GetDocuments<Ticket>(TABLE_NAME);
        }

        // (MVL)
        public void Update(string id, Ticket updatedTicket)
        {
            db.UpdateDocument<Ticket>(id, TABLE_NAME, updatedTicket);
        }

        // (MVL)
        public void ArchiveData()
        {
            var _filter = Builders<Ticket>.Filter.Lte("ReportedDate", DateTime.Today.AddMonths(-24));
            db.ArchiveData(TABLE_NAME, _filter);
        }


        //(DB) - Additional functionality - sorting by priority, and other sorts
        public List<Ticket> GetAllSortedById()
        {
            return db.GetSortedIDDocuments<Ticket>(TABLE_NAME);
        }

        public List<Ticket> GetAllSortedByPriority()
        {
            return db.GetSortedPriorityDocuments<Ticket>(TABLE_NAME);
        }

        public List<Ticket> GetAllSortedByDateReported()
        {
            return db.GetSortedDateReportedDocuments<Ticket>(TABLE_NAME);
        }

        public List<Ticket> GetAllSortedByDeadline()
        {
            return db.GetSortedDeadlineDocuments<Ticket>(TABLE_NAME);
        }

        public List<Ticket> GetAllSortedBySolved()
        {
            return db.GetSortedSolvedDocuments<Ticket>(TABLE_NAME);
        }



        // (DB) - To get current tickets for the end-users
        public List<Ticket> GetUsersTicketsSortedByID(User user)
        {
            return db.GetUsersTicketsSortedByIDDocuments<Ticket>(TABLE_NAME, user);
        }

        public List<Ticket> GetUsersTicketsSortedByPriority(User user)
        {
            return db.GetUsersTicketsSortedByPriorityDocuments<Ticket>(TABLE_NAME, user);
        }

        public List<Ticket> GetUsersTicketsAllSortedByDateReported(User user)
        {
            return db.GetUsersTicketsSortedDateReportedDocuments<Ticket>(TABLE_NAME, user);
        }

        public List<Ticket> GetUsersTicketsAllSortedByDeadline(User user)
        {
            return db.GetUsersTicketsSortedDeadlineDocuments<Ticket>(TABLE_NAME, user);
        }

        public List<Ticket> GetUsersTicketsAllSortedBySolved(User user)
        {
            return db.GetUsersTicketsSortedSolvedDocuments<Ticket>(TABLE_NAME, user);
        }


    }
}
