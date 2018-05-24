using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBTicketVerkoop.DAO;
using VBTicketVerkoop.Domain;

namespace VBTicketVerkoop.Service
{
   public class GebruikerService
    {
        private GebruikerDAO gebruikerDAO = new GebruikerDAO();

        public IEnumerable<Gebruiker> All()
        {
            return gebruikerDAO.All();
        }
        public Gebruiker getGebruikerByVoornaamFamilienaam(string vn ,string fn)
        {
            return gebruikerDAO.getGebruikerByVoornaamFamilienaam(vn, fn);

        }
        public Gebruiker getGebruikerByID(string id)
        {
            return gebruikerDAO.getGebruikerByID(id);
        }
        public Gebruiker Delete(string id)
        {
            return gebruikerDAO.Delete(id);
        }
        public void Update(Gebruiker entity)
        {
            gebruikerDAO.Update(entity);
        }
        public void Create(Gebruiker entity)
        {
            gebruikerDAO.Create(entity);
        }
    }
}
