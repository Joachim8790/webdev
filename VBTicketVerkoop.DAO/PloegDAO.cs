using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBTicketVerkoop.Domain;

namespace VBTicketVerkoop.DAO
{
    public class PloegDAO
    {
        public List<Ploeg> All()
        {
            using( var db = new VoetbalContext())
            {
                return db.Ploegen.ToList();
            }
        }
        public Ploeg getPloegByStadion(int id)
        {
            using(var db = new VoetbalContext())
            {
                return db.Ploegen
                    .Where(p => p.stadionID == id).First();
            }
        }
        public Ploeg getPloegByID(int id)
        {
            using(var db = new VoetbalContext())
            {
                return db.Ploegen
                    .Where(p => p.ploegID == id).First();
            }
        }
    }
}
