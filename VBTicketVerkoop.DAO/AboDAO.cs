using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBTicketVerkoop.Domain;

namespace VBTicketVerkoop.DAO
{
    public class AboDAO
    {
        public IEnumerable<Abo> All()
        {
            using( var db = new VoetbalContext())
            {
                return db.Abonnementen;
            }
        }
        public Abo getAboByID(int id)
        {
            using (var db = new VoetbalContext())
            {
                return db.Abonnementen
                    .Where(a => a.aboID == id).First();
            }
        }

        public List<Abo> getAbosByPloeg(int ploegID)
        {
            using (var db = new VoetbalContext())
            {
                return db.Abonnementen.Where(x => x.ploegID == ploegID).ToList();
            }
        }
        public Abo getAboByPloegPlaats(int ploegID,int plaatsID)
        {
            using (var db = new VoetbalContext())
            {
                return db.Abonnementen.Where(x => x.ploegID == ploegID).Where(y => y.plaatsID == plaatsID).FirstOrDefault();
            }
        }
    }
}
