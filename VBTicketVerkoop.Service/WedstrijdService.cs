using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBTicketVerkoop.DAO;
using VBTicketVerkoop.Domain;

namespace VBTicketVerkoop.Service
{
    public class WedstrijdService
    {
        private WedstrijdDAO wedstrijdDAO = new WedstrijdDAO();

        public IEnumerable<Wedstrijd> All()
        {
            return wedstrijdDAO.All();
        }
        public Wedstrijd getWedstrijdByID(int id)
        {
            return wedstrijdDAO.getWedstrijdByID(id);
        }
        public Wedstrijd getWedstrijdByDateStadion(DateTime d, int id)
        {
            return wedstrijdDAO.getWedstrijdByDateStadion(d, id);
        }

        public List<Wedstrijd> getWedstrijdenByPloeg(int ploegID)
        {
            return wedstrijdDAO.getWedstrijdenByPloeg(ploegID);
        }
    }
}
