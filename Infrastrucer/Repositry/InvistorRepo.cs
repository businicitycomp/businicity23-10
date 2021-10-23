using BisnicityApp.Entites;
using BisnicityApp.InterFaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucer.Repositry
{
    public class InvistorRepo : IBisnicity<Invistor>
    {
        DataContext db;

        public InvistorRepo(DataContext _db)
        {
            db = _db;
        }
        public void Add(Invistor entity)
        {
            db.Invistor.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Invistor Find(int id)
        {
            var invistor = db.Invistor.SingleOrDefault(a => a.InvistorID == id);
            if (invistor != null)
            {
                return invistor;
            }
            return null;
        }

        public IList<Invistor> List()
        {
            return db.Invistor.Include(x => x.Targetsector).AsQueryable().ToList();
        }

        public void Update(int id, Invistor entity)
        {
            throw new NotImplementedException();
        }
    }
}
