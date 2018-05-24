using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBTicketVerkoop.Domain;
using VBTicketVerkoop.DAO;

namespace VBTicketVerkoop.Service
{
    public class BestellijnService
    {
        private BestellijnDAO bestellijnDAO = new BestellijnDAO();

        public IEnumerable<Bestellijn> All()
        {
            return bestellijnDAO.All();
        }
        public IEnumerable<Bestellijn> getBestellijnByBestelling(int id)
        {
            return bestellijnDAO.getBestellijnByBestelling(id);
        }
        public Bestellijn getBestellijnByID(int id)
        {
            return bestellijnDAO.getBestellijnByID(id);
        }
        public Bestellijn Delete(int id)
        {
            return bestellijnDAO.Delete(id);
        }
        public void Update(Bestellijn entity)
        {
            bestellijnDAO.Update(entity);
        }
        public void Create(Bestellijn entity)
        {
            bestellijnDAO.Create(entity);
        }

    }
}
