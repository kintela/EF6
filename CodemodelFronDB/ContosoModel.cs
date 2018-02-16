namespace CodemodelFronDB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ContosoModel : DbContext
    {
        public ContosoModel()
            : base("name=ContosoModel")
        {
        }

        public virtual DbSet<DimProduct> DimProduct { get; set; }
        public virtual DbSet<DimProductCategory> DimProductCategory { get; set; }
        public virtual DbSet<DimProductSubcategory> DimProductSubcategory { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DimProduct>()
                .Property(e => e.UnitCost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DimProduct>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 4);
        }
    }
}
