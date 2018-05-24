using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBTicketVerkoop.DAO;
using VBTicketVerkoop.Domain;

namespace VBTicketVerkoop.Service
{
    public class PloegService
    {
        private PloegDAO ploegDAO = new PloegDAO();

        public List<Ploeg> All()
        {
            return ploegDAO.All();
        }
        public Ploeg getPloegByStadion(int id)
        {
            return ploegDAO.getPloegByStadion(id);
        }
        public Ploeg getPloegByID(int id)
        {
            return ploegDAO.getPloegByID(id);
        }
    }
}
