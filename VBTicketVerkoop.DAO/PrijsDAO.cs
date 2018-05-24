using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBTicketVerkoop.Domain;

namespace VBTicketVerkoop.DAO
{
    public class PrijsDAO
    {
        //get prijzen per stadion
        public IEnumerable<Prijs> getPricesByStadion(int stadionID)
        {
            using (var db = new VoetbalContext())
            {
                return db.Prijs.Where(x => x.stadionID == stadionID).OrderBy(x => x.stadionID).ThenBy(y => y.plaatsID).ToList();
            }
        }

        public Prijs getPriceByID(int? prijsID)
        {
            using (var db = new VoetbalContext())
            {
                return db.Prijs.Where(x => x.prijsID == prijsID).FirstOrDefault();

            }
        }
    }
}
