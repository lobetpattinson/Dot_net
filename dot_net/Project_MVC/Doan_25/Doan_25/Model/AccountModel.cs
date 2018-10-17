using Doan_25.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doan_25.Model
{
    public class AccountModel
    {
        private Web_DenLedDbContext db = null;
        public AccountModel()
        {
            db = new Web_DenLedDbContext();
        }
        public int Login(string UserName, string Password)
        {
            //object[] para={
            //    new SqlParameter("@UserName",UserName),
            //    new SqlParameter("@Password",Password)
            //};
            //var res = db.Database.SqlQuery<bool>("Sp_Account_Login @UserName, @Password", para).SingleOrDefault();
            var res = db.tblCustomers.SingleOrDefault(x => x.Account == UserName);
            if (res == null)
            {
                return 0;
            }
            else
            {
                if (res.Status == false)
                {
                    return -1;
                }
                else
                {
                    if (res.Password == Password)
                    {
                        return 1;
                    }
                    else return -2;
                }
            }

        }
        public tblUser GetById(string UserName)
        {
            return db.tblUsers.SingleOrDefault(x => x.Account == UserName);
        }
        public bool Edit(tblCustomer tb)
        {
            var c = db.tblCustomers.Find(tb.CustomerID);
            if (tb.Status == true)
            {
                c.Status = false;
            }
            else
            {
                c.Status = true;
            }

            db.SaveChanges();
            return true;
        }
    }
}