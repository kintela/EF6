namespace CodemodelFronDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DimProductCategory")]
    public partial class DimProductCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DimProductCategory()
        {
            DimProductSubcategory = new HashSet<DimProductSubcategory>();
        }

        [Key]
        public int ProductCategoryKey { get; set; }

        [StringLength(100)]
        public string ProductCategoryLabel { get; set; }

        [Required]
        [StringLength(30)]
        public string ProductCategoryName { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductCategoryDescription { get; set; }

        public int? ETLLoadID { get; set; }

        public DateTime? LoadDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DimProductSubcategory> DimProductSubcategory { get; set; }
    }
}
