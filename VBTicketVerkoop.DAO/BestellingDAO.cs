using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBTicketVerkoop.Domain;

namespace VBTicketVerkoop.DAO
{
    public class BestellingDAO
    {
        public IEnumerable<Bestelling> All()
        {
            using( var db = new VoetbalContext())
            {
                return db.Bestellingen.ToList();
            }
        }
        public IEnumerable<Bestelling> getBestellingByGebruiker(string id)
        {
            using( var db = new VoetbalContext())
            {
                return db.Bestellingen
                    .Where(b => b.gebruikerID == id).ToList();
            }
        }
        public Bestelling getBestellingByID(int id)
        {
            using(var db = new VoetbalContext())
            {
                return db.Bestellingen
                    .Where(b => b.BestellingID == id).First();
            }
        }
        public void Update(Bestelling entity)
        {
            using (var db = new VoetbalContext())
            {
                
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public Bestelling Create(Bestelling entity)
        {
            using (var db = new VoetbalContext())
            {
                db.Entry(entity).State = EntityState.Added;
                db.SaveChanges();
                return entity;
            }
        }
        public Bestelling Delete(int id)
        {
            Bestelling b;
            using (var db = new VoetbalContext())
            {
                b = db.Bestellingen
                    .Where(g => g.BestellingID == id)
                    .FirstOrDefault();
                db.Entry(b).State = EntityState.Deleted;
                db.SaveChanges();
                return b;

            }
        }
    }
}
