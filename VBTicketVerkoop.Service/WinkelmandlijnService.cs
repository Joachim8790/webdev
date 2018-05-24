using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBTicketVerkoop.DAO;
using VBTicketVerkoop.Domain;

namespace VBTicketVerkoop.Service
{
    public class WinkelmandlijnService
    {
        private WinkelmandlijnDAO dao = new WinkelmandlijnDAO();
        //telt het aantal tickets in het winkelmandje
        public int countTickets(List<Winkelmandlijn> lines)
        {
            return dao.countTickets(lines);
        }
        //alle lijnen opvragen van een gebruiker
        public List<Winkelmandlijn> getLinesFromUser(string gebruikersID)
        {
            return dao.getLinesFromUser(gebruikersID);
        }
        //alle lijnen verwijderen van een gebruiker
        public void DeleteLinesFromUser(string gebruikersID)
        {
            dao.DeleteLinesFromUser(gebruikersID);
        }
        //één lijn opvragen
        public Winkelmandlijn getLineByID(int id)
        {
            return dao.getLineByID(id);

        }
        //één lijn verwijderen
        public void DeleteLine(Winkelmandlijn line)
        {
            dao.DeleteLine(line);
        }
        //één lijn toevoegen
        public Winkelmandlijn AddLine(Winkelmandlijn line)
        {
            return dao.AddLine(line);
        }
        //een lijn aanpassen
        public Winkelmandlijn EditLine(Winkelmandlijn line)
        {
            return dao.EditLine(line);
        }

    }
}
