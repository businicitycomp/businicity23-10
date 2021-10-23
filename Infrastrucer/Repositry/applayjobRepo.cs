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
    public class applayjobRepo : IBisnicity<ApplayJob>
    {
        DataContext db;

        public applayjobRepo(DataContext _db)
        {
            db = _db;
        }
        public void Add(ApplayJob entity)
        {
            db.ApplayJob.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ApplayJob Find(int id)
        {
            throw new NotImplementedException();
        }

        public IList<ApplayJob> List()
        {
            throw new NotImplementedException();
        }

        //public IList<ApplayJob> List()
        //{
        //    return db.ApplayJob.Include(x => x.Person).Include(x=>x.JobVacancy).AsQueryable().ToList();
        //}

        public void Update(int id, ApplayJob entity)
        {
            throw new NotImplementedException();
        }
    }
}
