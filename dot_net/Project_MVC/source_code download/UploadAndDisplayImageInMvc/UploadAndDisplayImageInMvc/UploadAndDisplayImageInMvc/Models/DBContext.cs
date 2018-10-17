using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UploadAndDisplayImageInMvc.Models
{
    public class DBContext : DbContext
    {
        public DBContext()
            : base("Name=ChuoiKetNoi")
        {
            Database.SetInitializer<DBContext>(new DropCreateDatabaseIfModelChanges<DBContext>());
        }
        public DbSet<Content> Contents { get; set; }
    }
}