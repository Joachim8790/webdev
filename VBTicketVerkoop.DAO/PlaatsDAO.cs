using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBTicketVerkoop.Domain;

namespace VBTicketVerkoop.DAO
{
    public class PlaatsDAO
    {
        public IEnumerable<Plaats> All()
        {
            using( var db = new VoetbalContext())
            {
                return db.Plaatsen.ToList();
            }

        }
        public Plaats getPlaatsByID(int id)
        {
            using( var db = new VoetbalContext())
            {
                return db.Plaatsen
                    .Where(p => p.plaatsID == id).First();

            }
        }
    }
}
