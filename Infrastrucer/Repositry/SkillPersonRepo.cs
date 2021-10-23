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
  public  class SkillPersonRepo : IBisnicity<SkillsPerson>
    {
        DataContext db;
        public SkillPersonRepo(DataContext _db)
        {
            db = _db;
        }

        public void Add(SkillsPerson entity)
        {
            db.SkillsPerson.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var cat = Find(id);
            db.SkillsPerson.Remove(cat);
            db.SaveChanges();
        }

        public SkillsPerson Find(int id)
        {
            var skill = db.SkillsPerson.SingleOrDefault(a => a.SkillsPersonID == id);
            if (skill != null)
            {
                return skill;
            }
            return null;
        }

        public IList<SkillsPerson> List()
        {
            return db.SkillsPerson.ToList();

        }

        public void Update(int id, SkillsPerson entity)
        {
            db.Update(entity);
            db.SaveChanges();
        }
    }
}
