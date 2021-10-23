using BisnicityApp.Entites;
using BisnicityApp.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucer.Repositry
{
    public class CategoryRepo : IBisnicity<CatTemp>
    {
        DataContext _db;
        public CategoryRepo(DataContext db)
        {
            _db = db;
        }
        public void Add(CatTemp entity)
        {
            _db.CatTemp.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var cat = Find(id);
            _db.CatTemp.Remove(cat);
            _db.SaveChanges();
        }

        public CatTemp Find(int id)
        {
            var info = _db.CatTemp.SingleOrDefault(a => a.CatTempID == id);
            if (info != null)
            {
                return info;
            }
            return null;
        }

        public IList<CatTemp> List()
        {
            return _db.CatTemp.ToList();    
                
        }

        public void Update(int id, CatTemp entity)
        {
            _db.Update(entity);
            _db.SaveChanges();
        }
    }
}
