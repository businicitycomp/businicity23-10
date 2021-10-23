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
    public class ServicesDbRepo : IBisnicity<Services>
    {
        DataContext db;
        public ServicesDbRepo(DataContext _db)
        {
            db = _db;
        }
        public void Add(Services entity)
        {
            db.Services.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var services = Find(id);
            db.Services.Remove(services);
            db.SaveChanges();
        }

        public Services Find(int id)
        {
            var service = db.Services.SingleOrDefault(a => a.ServicesID == id);
            if(service !=null)
            {
                return service;
            }
            return null;
        }

        public IList<Services> List()
        {
            return db.Services.Include(x=>x.Info).AsQueryable().ToList();
        }

        public void Update(int id, Services entity)
        {
            db.Update(entity);
            db.SaveChanges();
        }
    }
}
