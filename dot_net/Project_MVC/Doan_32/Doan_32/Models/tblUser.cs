using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doan_32.Models
{
    public class tblUser
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public Nullable<bool> Status { get; set; }
    }
}