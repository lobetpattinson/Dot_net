//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Doan_36
{
    using System;
    using System.Collections.Generic;
    
    public partial class WebAction
    {
        public WebAction()
        {
            this.ActionRoles = new HashSet<ActionRole>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<ActionRole> ActionRoles { get; set; }
    }
}
