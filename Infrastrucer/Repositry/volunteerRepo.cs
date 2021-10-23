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
    public class volunteerRepo : IBisnicity<volunteer>
    {
        DataContext db;

        public volunteerRepo(DataContext _db)
        {
            db = _db;
        }
        public void Add(volunteer entity)
        {
            db.Volunteer.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public volunteer Find(int id)
        {
            throw new NotImplementedException();
        }

        public IList<volunteer> List()
        {
            return db.Volunteer.Include(x => x.Gender).AsQueryable().ToList();
        }

        public void Update(int id, volunteer entity)
        {
            throw new NotImplementedException();
        }
    }
}
