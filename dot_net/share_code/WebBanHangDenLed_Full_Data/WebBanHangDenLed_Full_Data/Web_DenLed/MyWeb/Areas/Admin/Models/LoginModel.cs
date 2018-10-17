using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWeb.Areas.Admin.Models
{
    public class LoginModel
    {
        
        Web_DenLedDbContext db = new Web_DenLedDbContext();
        
        public string UserName { set; get; }
        public string Password { set; get; }
        public bool Remember { set; get; }

        public int Login(string UserName, string Password)
        {
            //object[] para={
            //    new SqlParameter("@UserName",UserName),
            //    new SqlParameter("@Password",Password)
            //};
            //var res = db.Database.SqlQuery<bool>("Sp_Account_Login @UserName, @Password", para).SingleOrDefault();
            var res = db.tblUsers.SingleOrDefault(x => x.Account == UserName);
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
    }
}