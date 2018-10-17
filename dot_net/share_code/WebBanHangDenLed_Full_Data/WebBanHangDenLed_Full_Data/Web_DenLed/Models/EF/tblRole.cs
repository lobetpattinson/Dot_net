namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblRole
    {
        [Key]
        public int RoleID { get; set; }

        [StringLength(50)]
        public string NameRole { get; set; }
    }
}
