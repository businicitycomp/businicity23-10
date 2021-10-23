using BisnicityApp.Entites;
using BisnicityApp.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucer.Repositry
{
    public class CatPersonRepo : IBisnicity<CatPerson>
    {
        DataContext db;
        public CatPersonRepo(DataContext _db)
        {
            db = _db;
        }
        public void Add(CatPerson entity)
        {
            db.CatPerson.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var cat = Find(id);
            db.CatPerson.Remove(cat);
            db.SaveChanges();
        }

        public CatPerson Find(int id)
        {
            var info = db.CatPerson.SingleOrDefault(a => a.CatPersonID == id);
            if (info != null)
            {
                return info;
            }
            return null;
        }

        public IList<CatPerson> List()
        {
            return db.CatPerson.ToList();

        }

        public void Update(int id, CatPerson entity)
        {
            db.Update(entity);
            db.SaveChanges();
        }
    }
}
