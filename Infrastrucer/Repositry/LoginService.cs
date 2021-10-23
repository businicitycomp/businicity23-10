using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BisnicityApp.Entites;
using BisnicityApp.InterFaces;
namespace Infrastrucer.Repositry
{
    //public class LoginService : ILogin, IBisnicity<Info>,ILoginPerson
    //{
    //    public DataContext db;

    //    public LoginService(DataContext _db)
    //    {
    //        db = _db;
    //    }
    //    public IList<Info> List()
    //    {

    //        var Listlogin = db.Info.ToList();
    //        return Listlogin;

    //    }

    //    //public Info Login(string Email, string password)
    //    //{
    //    //    var boollist = db.Info.FirstOrDefault(a => a.Email == Email && a.Password == password);
    //    //    return boollist ?? null;
           
    //    //}


    //    public Info Find(int id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Add(Info entity)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Update(int id, Info entity)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Delete(int id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    Person ILoginPerson.Login(string Email, string password)
    //    {
    //        var boollist = db.Person.FirstOrDefault(a => a.Email == Email && a.Password == password);
    //        return boollist ?? null;
    //    }
    //}
}
