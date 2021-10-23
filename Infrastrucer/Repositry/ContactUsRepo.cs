using BisnicityApp.Entites;
using BisnicityApp.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucer.Repositry
{
    public class ContactUsRepo : IBisnicity<ContactUs>
    {
        DataContext db;

        public ContactUsRepo(DataContext _db)

        {
            db = _db;
        }
        public void Add(ContactUs entity)
        {
            db.ContactUs.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ContactUs Find(int id)
        {
            throw new NotImplementedException();
        }

        public IList<ContactUs> List()
        {
            return db.ContactUs.ToList();
        }

        public void Update(int id, ContactUs entity)
        {
            throw new NotImplementedException();
        }
    }
}
