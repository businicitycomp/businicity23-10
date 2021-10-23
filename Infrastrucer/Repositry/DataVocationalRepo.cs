using BisnicityApp.Entites;
using BisnicityApp.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucer.Repositry
{
    
    public class DataVocationalRepo : IBisnicity<Datavocational>
    {
        DataContext db;

        public DataVocationalRepo(DataContext _db)
        {
            db = _db;
        }

        public void Add(Datavocational entity)
        {

            db.Datavocational.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Datavocational Find(int id)
        {
            var datavoc = db.Datavocational.SingleOrDefault(a => a.DatavocationalID == id);
            if (datavoc != null)
            {
                return datavoc;
            }
            return null;
        }

        public IList<Datavocational> List()
        {
            return db.Datavocational.ToList();
            
        }

        public void Update(int id, Datavocational entity)
        {
            throw new NotImplementedException();
        }
    }
}
