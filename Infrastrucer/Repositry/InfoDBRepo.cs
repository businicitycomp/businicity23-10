using BisnicityApp.Entites;
using BisnicityApp.InterFaces;
using System;
using System.Collections.Generic;
//using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucer.Repositry
{
    public class InfoDBRepo : IBisnicity<Info>/*,ILogin*/
    {
        DataContext db;
        public InfoDBRepo(DataContext _db)
        {
            db = _db;
        }
        #region Mehod :: Add
        /// <summary>
        ///  This Mehod For Create Obejct
        /// </summary>
        /// <param name="entity"></param>
        public void Add(Info entity)
        {
            //try
            //{

            //}
            //catch (DbEntityValidationException ex)
            //{
            //    throw ex;
            //}
            db.Info.Add(entity);
            db.SaveChanges();
        }
        #endregion
        public void Delete(int id)
        {
            var info = Find(id);
            db.Info.Remove(info);
            db.SaveChanges();
        }
        public Info Find(int id)
        {
            var info = db.Info.SingleOrDefault(a => a.InfoID == id);
            if(info !=null)
            {
                return info;
            }
            return null;
        }

        public IList<Info> List()
        {
            return db.Info.ToList();
        }

        //public Info Login(string Email, string password)
        //{
        //    var boollist = db.Info.FirstOrDefault(a => a.Email == Email && a.Password == password);
        //    return boollist ?? null;
        //}

        public void Update(int id, Info entity)
        {
            db.Update(entity);
            db.SaveChanges();       
        }
       public int ss(List<Info> infos)
        {
            var a =Convert.ToInt32(infos.Select(a => a.InfoID));
            return a;
        }


      
    }
    
}
