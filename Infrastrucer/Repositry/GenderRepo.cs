using BisnicityApp.Entites;
using BisnicityApp.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucer.Repositry
{
    public class GenderRepo : IBisnicity<Gender>
    {
        DataContext db;

        public GenderRepo(DataContext _db)
        {
            db = _db;
        }
        public void Add(Gender entity)
        {
            db.Gender.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Gender Find(int id)
        {
            var gender = db.Gender.SingleOrDefault(a => a.GenderID == id);
            if (gender != null)
            {
                return gender;
            }
            return null;
        }

        public IList<Gender> List()
        {
            return db.Gender.ToList();
        }

        public void Update(int id, Gender entity)
        {
            throw new NotImplementedException();
        }
    }
}
