    namespace product_details
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<p_cg> p_cg { get; set; }
        public virtual DbSet<p_ct> p_ct { get; set; }
        public virtual DbSet<p_dt> p_dt { get; set; }
        public virtual DbSet<p_od> p_od { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<p_cg>()
                .Property(e => e.cg_name)
                .IsUnicode(false);

            modelBuilder.Entity<p_cg>()
                .HasMany(e => e.p_dt)
                .WithRequired(e => e.p_cg)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<p_dt>()
                .Property(e => e.p_name)
                .IsUnicode(false);

            modelBuilder.Entity<p_dt>()
                .Property(e => e.p_img)
                .IsUnicode(false);

            modelBuilder.Entity<p_dt>()
                .HasMany(e => e.p_ct)
                .WithRequired(e => e.p_dt)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<p_dt>()
                .HasMany(e => e.p_od)
                .WithRequired(e => e.p_dt)
                .WillCascadeOnDelete(false);
        }
    }
}