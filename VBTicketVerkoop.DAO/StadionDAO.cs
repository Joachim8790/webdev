using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBTicketVerkoop.Domain;

namespace VBTicketVerkoop.DAO
{
    public class StadionDAO
    {
        public IEnumerable<Stadion> All()
        {
            using(var db = new VoetbalContext())
            {
                return db.Stadions.ToList();
            }
        }
        public Stadion getStadionByID(int id)
        {
            using (var db = new VoetbalContext())
            {
                return db.Stadions
                    .Where(s => s.stadionID == id).First();
            }
        }

    }
}
