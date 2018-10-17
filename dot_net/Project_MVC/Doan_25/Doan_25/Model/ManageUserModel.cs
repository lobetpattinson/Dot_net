using Doan_25.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doan_25.Model
{
    public class ManageUserModel
    {
        Web_DenLedDbContext db = new Web_DenLedDbContext();
        public List<tblCustomer> ListAll()
        {
            var res = db.tblCustomers.ToList();
            return res;
        }
    }
}