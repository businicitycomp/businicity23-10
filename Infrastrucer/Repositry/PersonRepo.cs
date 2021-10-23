using BisnicityApp.Entites;
using BisnicityApp.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucer.Repositry
{
    public class PersonRepo : IBisnicity<Person> /*,ILoginPerson*/
    {

        DataContext db;

        public PersonRepo(DataContext _db)
        {
            db = _db;
        }
        public void Add(Person entity)
        {
            db.Person.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var person = Find(id);
            db.Person.Remove(person);
            db.SaveChanges();
        }

        public Person Find(int id)
        {
            var person = db.Person.SingleOrDefault(a => a.PersonID == id);
            if (person != null)
            {
                return person;
            }
            return null;
        }

        public IList<Person> List()
        {
            return db.Person.ToList();
        }

        //public Person Login(string Email, string password)
        //{
        //    var boollist = db.Person.FirstOrDefault(a => a.Email == Email && a.Password == password);
        //    return boollist ?? null;
        //}

        public void Update(int id, Person entity)
        {
            db.Update(entity);
            db.SaveChanges();
        }
    }
}
