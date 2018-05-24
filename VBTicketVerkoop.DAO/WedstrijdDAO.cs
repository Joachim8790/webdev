using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBTicketVerkoop.Domain;

namespace VBTicketVerkoop.DAO
{
    public class WedstrijdDAO
    {
        public IEnumerable<Wedstrijd> All()
        {
            using(var db = new VoetbalContext())
            {
                return db.Wedstrijden.ToList();
            }
        }
        public Wedstrijd getWedstrijdByID(int id)
        {
            using(var db = new VoetbalContext())
            {
                return db.Wedstrijden
                    .Where(w => w.wedstrijdID == id).First();
            }
        }
        public Wedstrijd getWedstrijdByDateStadion(DateTime d,int id)
        {
            using(var db = new VoetbalContext())
            {
                return db.Wedstrijden
                    .Where(w => w.date == d && w.stadionID == id).First();
            }
        }

        public List<Wedstrijd> getWedstrijdenByPloeg(int ploegID)
        {
            using (var db = new VoetbalContext())
            {
                List<Wedstrijd> thuis =  db.Wedstrijden.Where(a => a.thuisID == ploegID).ToList();
                List<Wedstrijd> uit = db.Wedstrijden.Where(a => a.uitID == ploegID).ToList();
                return thuis.Concat(uit).ToList();
            }

        }
    }
}
