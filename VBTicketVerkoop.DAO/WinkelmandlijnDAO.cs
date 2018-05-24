using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBTicketVerkoop.Domain;

namespace VBTicketVerkoop.DAO
{
    public class WinkelmandlijnDAO
    {
        //tellen hoeveel tickets er reeds in het winkelmandje zitten
        public int countTickets(List<Winkelmandlijn> lines)
        {
            int counter = 0;
            for (int i = 0; i < lines.Count(); i++)
            {
                if (lines.ElementAt(i).TicketID != null)
                {
                    counter++;
                }

            }
            return counter;
        }
        //alle lijnen opvragen van een gebruiker
        public List<Winkelmandlijn> getLinesFromUser(string gebruikersID)
        {
            using (var db = new VoetbalContext())
            {
                return db.Winkelmandlijnen.Where(x => x.gebruikerID == gebruikersID).ToList();
            }
        }
        //alle lijnen verwijderen van een gebruiker
        public void DeleteLinesFromUser(string gebruikersID)
        {
            using (var db = new VoetbalContext())
            {
                List<Winkelmandlijn> linesOfUser = getLinesFromUser(gebruikersID);
                foreach (Winkelmandlijn l in linesOfUser)
                {
                    db.Entry(l).State = EntityState.Deleted;
                }
                db.SaveChanges();
            }
        }
        //één lijn opvragen
        public Winkelmandlijn getLineByID(int id)
        {
            using (var db = new VoetbalContext())
            {
                return db.Winkelmandlijnen.Where(x => x.ID == id).FirstOrDefault();
            }

        }
        //één lijn verwijderen
        public void DeleteLine(Winkelmandlijn line)
        {
            using (var db = new VoetbalContext())
            {

                db.Entry(line).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
        //één lijn toevoegen
        public Winkelmandlijn AddLine(Winkelmandlijn line)
        {
            using(var db = new VoetbalContext())
            {
                db.Entry(line).State = EntityState.Added;
                db.SaveChanges();
                return line;
                
            }
        }
        //een lijn aanpassen
        public Winkelmandlijn EditLine(Winkelmandlijn line)
        {
            using (var db = new VoetbalContext())
            {
                db.Entry(line).State = EntityState.Modified;
                db.SaveChanges();
                return line;
            }
        }

    }
}
