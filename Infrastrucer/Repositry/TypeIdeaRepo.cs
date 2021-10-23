using BisnicityApp.Entites;
using BisnicityApp.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucer.Repositry
{
    public class TypeIdeaRepo : IBisnicity<TypeIdea>
    {
        DataContext db;
        public TypeIdeaRepo(DataContext _db)
        {
            db = _db;
        }
        public void Add(TypeIdea entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public TypeIdea Find(int id)
        {
            var typeidea = db.TypeIdea.SingleOrDefault(a => a.TypeIdeaID == id);
            if (typeidea != null)
            {
                return typeidea;
            }
            return null;
        }

        public IList<TypeIdea> List()
        {
            return db.TypeIdea.ToList();
        }

        public void Update(int id, TypeIdea entity)
        {
            throw new NotImplementedException();
        }
    }
}
