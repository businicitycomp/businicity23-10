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
    public class DetailsPersonRepo : IBisnicity<DetailsPerson>
    {
        DataContext db;
        public DetailsPersonRepo(DataContext _db)
        {
            db = _db;
        }
        public void Add(DetailsPerson entity)
        {
            db.DetailsPerson.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var cat = Find(id);
            db.DetailsPerson.Remove(cat);
            db.SaveChanges();
        }

        public DetailsPerson Find(int id)
        {
            var dteails = db.DetailsPerson.SingleOrDefault(a => a.CatPersonID == id);
            if (dteails != null)
            {
                return dteails;
            }
            return null;
        }

        public IList<DetailsPerson> List()
        {
            return db.DetailsPerson.Include(x => x.CatPerson).AsQueryable().ToList();

        }

        public void Update(int id, DetailsPerson entity)
        {
            db.Update(entity);
            db.SaveChanges();
        }
    }
}
