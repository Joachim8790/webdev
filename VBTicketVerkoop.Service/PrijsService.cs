using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBTicketVerkoop.DAO;
using VBTicketVerkoop.Domain;

namespace VBTicketVerkoop.Service
{
    public class PrijsService
    {
        public PrijsDAO dao = new PrijsDAO();
        public IEnumerable<Prijs> getPricesByStadion(int stadionID)
        {
            return dao.getPricesByStadion(stadionID);
        }

        public Prijs getPriceByID(int? prijsID)
        {
            return dao.getPriceByID(prijsID);
        }
    }
}
