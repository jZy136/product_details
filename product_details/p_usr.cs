namespace product_details
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class p_usr
    {
        [Key]
        public int u_id { get; set; }

        [Required]
        [StringLength(50)]
        public string u_name { get; set; }

        [Required]
        [StringLength(50)]
        public string u_pwd { get; set; }
    }
}
