namespace product_details
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class p_ct
    {
        [Key]
        public int c_id { get; set; }

        public int p_id { get; set; }

        public int c_num { get; set; }

        public virtual p_dt p_dt { get; set; }
    }
}
