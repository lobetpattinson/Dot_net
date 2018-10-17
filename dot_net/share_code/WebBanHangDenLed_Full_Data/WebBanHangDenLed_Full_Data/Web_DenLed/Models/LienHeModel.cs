using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class LienHeModel
    {
        Web_DenLedDbContext db = null;
        public LienHeModel()
        {
            db = new Web_DenLedDbContext();
        }
        public int Insert(tblContact lh)
        {
            lh.DateSent = DateTime.Now;
            lh.Status = false;
            var c = db.tblContacts.Add(lh);
            db.SaveChanges();
            return c.ID;
        }
    }
}
