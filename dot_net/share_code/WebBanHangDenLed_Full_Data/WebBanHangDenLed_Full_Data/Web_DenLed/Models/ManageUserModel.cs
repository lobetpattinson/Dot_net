using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
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
