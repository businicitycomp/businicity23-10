using BisnicityApp.Entites;
using BisnicityApp.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucer.Repositry
{
    public class CareerPathRepo : IBisnicity<CareerPath>
    {

        DataContext db;

        public CareerPathRepo(DataContext _db)
        {
            db = _db;
        }
        public void Add(CareerPath entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public CareerPath Find(int id)
        {
            var career = db.CareerPath.SingleOrDefault(a => a.CareerPathID == id);
            if (career != null)
            {
                return career;
            }
            return null;
        }

        public IList<CareerPath> List()
        {
            return db.CareerPath.ToList();
        }

        public void Update(int id, CareerPath entity)
        {
            throw new NotImplementedException();
        }
    }
}
