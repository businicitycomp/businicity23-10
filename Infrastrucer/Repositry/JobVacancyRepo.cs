using BisnicityApp.Entites;
using BisnicityApp.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucer.Repositry
{
    public class JobVacancyRepo : IBisnicity<jobVacancy>
    {
        DataContext db;
        public JobVacancyRepo(DataContext _db)
        {
            db = _db;
        }
        public void Add(jobVacancy entity)
        {
            db.jobVacancy.Add(entity);
            db.SaveChanges();
                
        }

        public void Delete(int id)
        {
            var job = Find(id);
            db.jobVacancy.Remove(job);
            db.SaveChanges();
        }

        public jobVacancy Find(int id)
        {
            var job = db.jobVacancy.SingleOrDefault(a => a.jobVacancyID == id);
            if (job != null)
            {
                return job;
            }
            return null;
        }

        public IList<jobVacancy> List()
        {
            throw new NotImplementedException();
        }

        public void Update(int id, jobVacancy entity)
        {
            throw new NotImplementedException();
        }
    }
}
