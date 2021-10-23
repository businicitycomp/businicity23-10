using BisnicityApp.Entites;
using BisnicityApp.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucer.Repositry
{
    public class yourstatusRepo : IBisnicity<yourstatus>
    {
        DataContext db;

        public yourstatusRepo(DataContext _db)
        {
            db = _db;
        }
        public void Add(yourstatus entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public yourstatus Find(int id)
        {
            var status = db.yourstatus.SingleOrDefault(a => a.yourstatusID == id);
            if (status != null)
            {
                return status;
            }
            return null;
        }

        public IList<yourstatus> List()
        {
            return db.yourstatus.ToList();
        }

        public void Update(int id, yourstatus entity)
        {
            throw new NotImplementedException();
        }
    }
}
