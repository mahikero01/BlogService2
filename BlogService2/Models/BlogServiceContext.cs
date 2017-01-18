namespace BlogService2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BlogServiceContext : DbContext
    {
        public BlogServiceContext()
            : base("name=BlogServiceContext")
        {
        }

        public virtual DbSet<BS_Persons> BS_Persons { get; set; }
        public virtual DbSet<BS_Posts> BS_Posts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BS_Persons>()
                .HasMany(e => e.BS_Posts)
                .WithRequired(e => e.BS_Persons)
                .HasForeignKey(e => e.PersonId);
        }
    }
}
