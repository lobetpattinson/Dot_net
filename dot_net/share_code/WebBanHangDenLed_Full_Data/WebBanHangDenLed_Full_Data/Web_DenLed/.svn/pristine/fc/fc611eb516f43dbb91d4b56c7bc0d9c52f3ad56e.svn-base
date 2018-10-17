namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblCategoryProduct
    {
        public int ID { get; set; }

        public int? ProductID { get; set; }

        public int? CategoryID { get; set; }

        public virtual tblCategory tblCategory { get; set; }
    }
}
