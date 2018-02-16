namespace CodemodelFronDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DimProductSubcategory")]
    public partial class DimProductSubcategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DimProductSubcategory()
        {
            DimProduct = new HashSet<DimProduct>();
        }

        [Key]
        public int ProductSubcategoryKey { get; set; }

        [StringLength(100)]
        public string ProductSubcategoryLabel { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductSubcategoryName { get; set; }

        [StringLength(100)]
        public string ProductSubcategoryDescription { get; set; }

        public int? ProductCategoryKey { get; set; }

        public int? ETLLoadID { get; set; }

        public DateTime? LoadDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DimProduct> DimProduct { get; set; }

        public virtual DimProductCategory DimProductCategory { get; set; }
    }
}
