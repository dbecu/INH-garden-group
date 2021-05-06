using GardenGroupModel;
using System.Collections.Generic;

namespace GardenGroupDAO
{
    interface ITicketDAO
    {
        void Create(Ticket newTicket);
        void Update(string id, Ticket updatedTicket);
        void Delete(string id);
        void ArchiveData();
        List<Ticket> FindByType(TypeOfIncident type);
        List<Ticket> FindByBranch(string branch);
        List<Ticket> GetAll();
        Ticket FindById(string id);

        //Do I put these in the interface or directly in the class?
        List<Ticket> GetAllSortedById();
        List<Ticket> GetAllSortedByPriority();
    }
}
