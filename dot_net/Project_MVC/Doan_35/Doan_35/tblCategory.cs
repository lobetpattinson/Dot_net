//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Doan_35
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblCategory
    {
        public tblCategory()
        {
            this.tblCategoryProducts = new HashSet<tblCategoryProduct>();
        }
    
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public Nullable<int> Levels { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<int> TypeID { get; set; }
    
        public virtual ICollection<tblCategoryProduct> tblCategoryProducts { get; set; }
    }
}
