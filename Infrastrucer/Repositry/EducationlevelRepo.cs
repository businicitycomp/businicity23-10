using BisnicityApp.Entites;
using BisnicityApp.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucer.Repositry
{
    public class EducationlevelRepo : IBisnicity<Educationlevel>
    {
        DataContext db;

        public EducationlevelRepo(DataContext _db)
        {
            db = _db;
        }
        public void Add(Educationlevel entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Educationlevel Find(int id)
        {
            var edu = db.Educationlevel.SingleOrDefault(a => a.EducationlevelID == id);
            if (edu != null)
            {
                return edu;
            }
            return null;
        }

        public IList<Educationlevel> List()
        {
            return db.Educationlevel.ToList();
        }

        public void Update(int id, Educationlevel entity)
        {
            throw new NotImplementedException();
        }
    }
}
