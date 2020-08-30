namespace product_details
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class p_dt
    {
        [Key]
        public int p_id { get; set; }

        [Required]
        [StringLength(50)]
        public string p_name { get; set; }

        public int cg_id { get; set; }

        public int p_num { get; set; }

        public double p_price { get; set; }

        [Required]
        [StringLength(50)]
        public string p_img { get; set; }

        public virtual p_cg p_cg { get; set; }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<p_ct> p_ct { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<p_od> p_od { get; set; }
    }
}
