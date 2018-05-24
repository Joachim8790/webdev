using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBTicketVerkoop.Domain;

namespace VBTicketVerkoop.DAO
{
    public class GebruikerDAO
    {
        public IEnumerable<Gebruiker> All()
        {
            using( var db = new VoetbalContext())
            {
                return db.Gebruikers.ToList();
            }
        }
        public Gebruiker getGebruikerByVoornaamFamilienaam(string vn, string fn)
        {
            using( var db = new VoetbalContext())
            {
                return db.Gebruikers
                    .Where(g => g.voornaam == vn && g.familienaam == fn).First();
            }
        }
        
        public Gebruiker getGebruikerByID(string id)
        {
            using( var db = new VoetbalContext())
            {
                return db.Gebruikers
                    .Where(g => g.gebruikerID == id).First();
            }
        }
        public Gebruiker Delete(string id)
        {
            Gebruiker gebruiker;
            using(var db = new VoetbalContext())
            {
                gebruiker = db.Gebruikers
                    .Where(g => g.gebruikerID == id)
                    .FirstOrDefault();
                db.Entry(gebruiker).State = EntityState.Deleted;
                db.SaveChanges();
                return gebruiker;

            }
        }
        public void Update(Gebruiker entity)
        {
            using (var db = new VoetbalContext())
            {
                
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Create(Gebruiker entity)
        {
            using (var db = new VoetbalContext())
            {
                db.Entry(entity).State = EntityState.Added;
                db.SaveChanges();
            }
        }
    }
}
