using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBTicketVerkoop.Domain;

namespace VBTicketVerkoop.DAO
{
    public class TicketDAO
    {
        public IEnumerable<Ticket> All()
        {
            using(var db = new VoetbalContext())
            {
                return db.Tickets.ToList();
            }
        }
        public IEnumerable<Ticket> getTicketByWedstrijd(int id)
        {
            using(var db = new VoetbalContext())
            {
                return db.Tickets
                    .Where(t => t.wedstrijdID == id).ToList();
            }
        }
        public Ticket Add(Ticket entity)
        {
            using (var db = new VoetbalContext())
            {
                db.Entry(entity).State = EntityState.Added;
                db.SaveChanges();
                return entity;
            }

        }

        public Ticket getTicketByID(int ticketID)
        {
            using (var db = new VoetbalContext())
            {
                return db.Tickets.Where(x => x.ticketID == ticketID).FirstOrDefault();
            }
        }
    }
}
