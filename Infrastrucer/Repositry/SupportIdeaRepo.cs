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
    public class SupportIdeaRepo : IBisnicity<SuppourtIdea>
    {
        DataContext db;

        public SupportIdeaRepo(DataContext _db)
        {
            db = _db;
        }
        public void Add(SuppourtIdea entity)
        {
            db.SuppourtIdea.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public SuppourtIdea Find(int id)
        {
            var suportidea = db.SuppourtIdea.SingleOrDefault(a => a.SuppourtIdeaID == id);
            if (suportidea != null)
            {
                return suportidea;
            }
            return null;
        }

        public IList<SuppourtIdea> List()
        {
            return db.SuppourtIdea.Include(x => x.Targetsector).Include(x=>x.TypeCompany).AsQueryable().ToList();

        }

        public void Update(int id, SuppourtIdea entity)
        {
            throw new NotImplementedException();
        }
    }
}
