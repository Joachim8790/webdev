using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBTicketVerkoop.DAO;
using VBTicketVerkoop.Domain;

namespace VBTicketVerkoop.Service
{
    public class BestellingService
    {
        private BestellingDAO bestellingDAO = new BestellingDAO();

        public IEnumerable<Bestelling> All()
        {
            return bestellingDAO.All();
        }
        public IEnumerable<Bestelling> getBestellingByGebruiker(string id)
        {
            return bestellingDAO.getBestellingByGebruiker(id);
        }
        public Bestelling getBestellingByID(int id)
        {
            return bestellingDAO.getBestellingByID(id);
        }
        public Bestelling Delete(int id)
        {
            return bestellingDAO.Delete(id);
        }
        public void Update(Bestelling entity)
        {
            bestellingDAO.Update(entity);
        }
        public Bestelling Create(Bestelling entity)
        {
            return bestellingDAO.Create(entity);
        }
    }
}
