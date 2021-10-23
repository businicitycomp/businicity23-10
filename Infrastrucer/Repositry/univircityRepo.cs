using BisnicityApp.Entites;
using BisnicityApp.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucer.Repositry
{
    public class univircityRepo : IBisnicity<Univircity>
    {
        DataContext db;

        public univircityRepo(DataContext _db)
        {
            db = _db;
        }
        public void Add(Univircity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Univircity Find(int id)
        {
            var uni = db.Univircity.SingleOrDefault(a => a.UnivircityID == id);
            if (uni != null)
            {
                return uni;
            }
            return null;
        }

        public IList<Univircity> List()
        {
            return db.Univircity.ToList();

        }

        public void Update(int id, Univircity entity)
        {
            throw new NotImplementedException();
        }
    }
}
