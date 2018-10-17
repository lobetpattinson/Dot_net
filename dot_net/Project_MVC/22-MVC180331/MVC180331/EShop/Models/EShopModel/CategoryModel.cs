using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EShop.Models.EShopModel
{
    public class CategoryModel
    {
        public int Create(string id, string password, string fullname, string email, string mobile)
        {
            var context = new EShopDbContext();
            object[] para =
            {
            new SqlParameter("@Id",id),
            new SqlParameter("@Password",password),
            new SqlParameter("@Fullname",fullname),
            new SqlParameter("@Email",email),
            new SqlParameter("@Mobile",mobile),
        };
            int res = context.Database.ExecuteSqlCommand("udsThemMaster @Id,@Password,@Fullname,@Email,@Mobile", para);
            return res;
        }
        public int Edit(string id, string password, string fullname, string email, string mobile)
        {
            var context = new EShopDbContext();
            object[] para =
            {
            new SqlParameter("@Id",id),
            new SqlParameter("@Password",password),
            new SqlParameter("@Fullname",fullname),
            new SqlParameter("@Email",email),
            new SqlParameter("@Mobile",mobile),
        };
            int res = context.Database.ExecuteSqlCommand("udsUpdateMater @Id,@Password,@Fullname,@Email,@Mobile", para);
            return res;
        }
        public int Delete(string id)
        {
            var context = new EShopDbContext();
                        var para = new SqlParameter("@Id", id);
            int res = context.Database.ExecuteSqlCommand("udsDeleteMaster @Id", para);
            return res;
        }
    }
}