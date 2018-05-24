using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBTicketVerkoop.DAO;
using VBTicketVerkoop.Domain;

namespace VBTicketVerkoop.Service
{
    public class PlaatsService
    {
        private PlaatsDAO plaatsDOA = new PlaatsDAO();

        public IEnumerable<Plaats> All()
        {
            return plaatsDOA.All();
        }
        public Plaats getPlaatsByID(int id)
        {
            return plaatsDOA.getPlaatsByID(id);
        }

    }
}
