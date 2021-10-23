using BisnicityApp.Entites;
using BisnicityApp.InterFaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucer.Repositry
{
    public class postRepo : IBisnicity<PostCompany>
    {
        DataContext db;

        public postRepo(DataContext _db)
        {
            db = _db;
        }
        public void Add(PostCompany entity)
        {
            db.PostCompany.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var post = Find(id);
            db.PostCompany.Remove(post);
            db.SaveChanges();
        }

        public PostCompany Find(int id)
        {
            var post = db.PostCompany.SingleOrDefault(a => a.PostCompanyID == id);
            if (post != null)
            {
                return post;
            }
            return null;
        }

        public IList<PostCompany> List()
        {
            return db.PostCompany.ToList();
        }

        public void Update(int id, PostCompany entity)
        {
            throw new NotImplementedException();
        }
    }
}
