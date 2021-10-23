using BisnicityApp.Entites;
using BisnicityApp.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucer.Repositry
{
    public class TypeCompRepo : IBisnicity<TypeCompany>
    {
        DataContext db;

        public TypeCompRepo(DataContext _db)

        {
            db = _db;
        }
        public void Add(TypeCompany entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public TypeCompany Find(int id)
        {
            var type = db.TypeCompany.SingleOrDefault(a => a.TypeCompanyID == id);
            if (type != null)
            {
                return type;
            }
            return null;
        }

        public IList<TypeCompany> List()
        {
            return db.TypeCompany.ToList();
        }

        public void Update(int id, TypeCompany entity)
        {
            throw new NotImplementedException();
        }
    }
}
