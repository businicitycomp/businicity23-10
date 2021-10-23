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
    public class OurServicedbRepo : IBisnicity<OurServices>
    {
        DataContext db;
        public OurServicedbRepo(DataContext _db)
        {
            db = _db;
        }
        public void Add(OurServices entity)
        {
            db.OurServices.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var ourservies = Find(id);
            db.OurServices.Remove(ourservies);
            db.SaveChanges();
        }

        public OurServices Find(int id)
        {
            var ourservice = db.OurServices.SingleOrDefault(a => a.OurServicesID == id);
            if(ourservice !=null)
            {
                return ourservice;
            }
            return null;
        }

        public IList<OurServices> List()
        {
            return db.OurServices.Include(x => x.Info).AsQueryable().ToList();
        }

        public void Update(int id, OurServices entity)
        {
            db.Update(entity);
            db.SaveChanges();
        }
    }
}
