using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doan_32.Models
{
    public class tblContact
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Nullable<System.DateTime> DateSent { get; set; }
        public Nullable<bool> Status { get; set; }
    }
}