using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BisnicityApp.Entites;
using BisnicityApp.InterFaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastrucer.Repositry
{
    public class TempleteDbRepo : IBisnicity<Templete>
    {
        DataContext db;
        public TempleteDbRepo(DataContext _db)

        {
            db = _db;
        }
        public void Add(Templete entity)
        {
            db.Templete.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var templete = Find(id);
            db.Templete.Remove(templete);
            db.SaveChanges();
        }

        public Templete Find(int id)
        {
            var templete = db.Templete.SingleOrDefault(a => a.TempleteID == id);
            if (templete != null)
            {
                return templete;
            }
            return null;
        }

        public IList<Templete> List()
        {
            return db.Templete.Include(x => x.CatTemp).AsQueryable().ToList();
        }

        public void Update(int id, Templete entity)
        {
            db.Update(entity);
            db.SaveChanges();
        }
    }
}
