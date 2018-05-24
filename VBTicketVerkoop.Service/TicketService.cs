using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBTicketVerkoop.DAO;
using VBTicketVerkoop.Domain;

namespace VBTicketVerkoop.Service
{
    public class TicketService
    {
        private TicketDAO ticketDAO = new TicketDAO();

        public IEnumerable<Ticket> All()
        {
            return ticketDAO.All();
        }
        public IEnumerable<Ticket> getTicketByWedstrijd(int id)
        {
            return ticketDAO.getTicketByWedstrijd(id);
        }
        public Ticket Add(Ticket entity)
        {
            return ticketDAO.Add(entity);
        }

        public Ticket getTicketByID(int ticketID)
        {
            return ticketDAO.getTicketByID(ticketID);
        }
    }
}
