using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBTicketVerkoop.DAO;
using VBTicketVerkoop.Domain;

namespace VBTicketVerkoop.Service
{
    public class StadionService
    {
        private StadionDAO stadionDAO = new StadionDAO();
        public IEnumerable<Stadion> All()
        {
            return stadionDAO.All();
        }
        public Stadion getStadionByID(int id)
        {
            return stadionDAO.getStadionByID(id);
        }
    }
}
