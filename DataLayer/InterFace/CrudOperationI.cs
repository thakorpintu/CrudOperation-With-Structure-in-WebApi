using BusinessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.InterFace
{
    public interface CrudOperationI
    {
        int CrudOperation(UserMaster model);
        List<UserMaster> ShowData();
        UserMaster Edit(UserMaster model);
        int Delete(UserMaster model);
    }
}
