using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer;
using System.Threading.Tasks;
using BusinessLayer.Entity;
using DataLayer.InterFace;

namespace DataLayer.Service
{
    public class CrudOperationService:CrudOperationI,IDisposable
    {
        CrudDbContext db;
        public CrudOperationService()
        {
            db = new CrudDbContext();
        }


        public List<UserMaster> ShowData()
        {
            return db.usermasters.ToList();
        }

        public int CrudOperation(UserMaster model)
        {
            if(model.Id>0)
            {
                
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return 2;

            }
            else
            {
                db.usermasters.Add(model);
                db.SaveChanges();
                return 1;

            }
        }

        public int Delete(UserMaster model)
        {
            if (model.Id > 0)
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Deleted;
                return db.SaveChanges();

            }
            return 0;
        }
        public UserMaster Edit(UserMaster model)
        {
            UserMaster md = new UserMaster();
            if (model.Id > 0)
            {
               return db.usermasters.Where(m => m.Id == model.Id).FirstOrDefault();
               

            }
            return md;
            
        }
        public void Dispose()
        {
            db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
