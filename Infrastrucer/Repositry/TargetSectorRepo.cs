using BisnicityApp.Entites;
using BisnicityApp.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucer.Repositry
{
    public class TargetSectorRepo : IBisnicity<Targetsector>
    {
        DataContext db;

        public TargetSectorRepo(DataContext _db)
        {
            db = _db;
        }
        public void Add(Targetsector entity)
        {
            db.Targetsector.Add(entity);
                db.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Targetsector Find(int id)
        {
            var targeta = db.Targetsector.SingleOrDefault(a => a.TargetsectorID == id);
            if (targeta != null)
            {
                return targeta;
            }
            return null;
        }

        public IList<Targetsector> List()
        {
            return db.Targetsector.ToList();

        }

        public void Update(int id, Targetsector entity)
        {
            throw new NotImplementedException();
        }
    }
}
