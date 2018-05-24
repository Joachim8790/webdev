using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBTicketVerkoop.Domain;

namespace VBTicketVerkoop.DAO
{
    public class BestellijnDAO
    {
        public IEnumerable<Bestellijn> All()
        {
            using (var db = new VoetbalContext())
            {
                return db.Bestellijnen.ToList();
            }
        }
        public IEnumerable<Bestellijn> getBestellijnByBestelling(int id)
        {
            using (var db = new VoetbalContext())
            {
                return db.Bestellijnen
                    .Where(b => b.bestellingID == id).ToList();
                    
            }
            
        }
        public Bestellijn getBestellijnByID(int id)
        {
            using( var db = new VoetbalContext())
            {
                return db.Bestellijnen
                    .Where(b => b.BestellijnID == id).First();
            }
        }
        public Bestellijn Delete(int id)
        {
            Bestellijn b;
            using (var db = new VoetbalContext())
            {
                b = db.Bestellijnen
                    .Where(g => g.BestellijnID == id)
                    .FirstOrDefault();
                db.Entry(b).State = EntityState.Deleted;
                db.SaveChanges();
                return b;

            }
        }
        public void Update(Bestellijn entity)
        {
            using (var db = new VoetbalContext())
            {

                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Create(Bestellijn entity)
        {
            using (var db = new VoetbalContext())
            {
                db.Entry(entity).State = EntityState.Added;
                db.SaveChanges();
            }
        }

    }
}
