using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBTicketVerkoop.DAO;
using VBTicketVerkoop.Domain;

namespace VBTicketVerkoop.Service
{
    public class AboService
    {
        private AboDAO aboDAO = new AboDAO();
        public AboService()
        {
            aboDAO = new AboDAO();
        }
        public IEnumerable<Abo> All()
        {
            return aboDAO.All();
        }
      
        public Abo getAboByID(int id)
        {
            return aboDAO.getAboByID(id);
        }

        public List<Abo> getAbosByPloeg(int ploegID)
        {
            return aboDAO.getAbosByPloeg(ploegID);
        }
        public Abo getAboByPloegPlaats(int ploegID, int plaatsID)
        {
            return aboDAO.getAboByPloegPlaats(ploegID, plaatsID);
        }
    }
}
