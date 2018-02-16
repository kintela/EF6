namespace CodemodelFronDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DimProduct")]
    public partial class DimProduct
    {
        [Key]
        public int ProductKey { get; set; }

        [StringLength(255)]
        public string ProductLabel { get; set; }

        [StringLength(500)]
        public string ProductName { get; set; }

        [StringLength(400)]
        public string ProductDescription { get; set; }

        public int? ProductSubcategoryKey { get; set; }

        [StringLength(50)]
        public string Manufacturer { get; set; }

        [StringLength(50)]
        public string BrandName { get; set; }

        [StringLength(10)]
        public string ClassID { get; set; }

        [StringLength(20)]
        public string ClassName { get; set; }

        [StringLength(10)]
        public string StyleID { get; set; }

        [StringLength(20)]
        public string StyleName { get; set; }

        [StringLength(10)]
        public string ColorID { get; set; }

        [Required]
        [StringLength(20)]
        public string ColorName { get; set; }

        [StringLength(50)]
        public string Size { get; set; }

        [StringLength(50)]
        public string SizeRange { get; set; }

        [StringLength(20)]
        public string SizeUnitMeasureID { get; set; }

        public double? Weight { get; set; }

        [StringLength(20)]
        public string WeightUnitMeasureID { get; set; }

        [StringLength(10)]
        public string UnitOfMeasureID { get; set; }

        [StringLength(40)]
        public string UnitOfMeasureName { get; set; }

        [StringLength(10)]
        public string StockTypeID { get; set; }

        [StringLength(40)]
        public string StockTypeName { get; set; }

        [Column(TypeName = "money")]
        public decimal? UnitCost { get; set; }

        [Column(TypeName = "money")]
        public decimal? UnitPrice { get; set; }

        public DateTime? AvailableForSaleDate { get; set; }

        public DateTime? StopSaleDate { get; set; }

        [StringLength(7)]
        public string Status { get; set; }

        [StringLength(150)]
        public string ImageURL { get; set; }

        [StringLength(150)]
        public string ProductURL { get; set; }

        public int? ETLLoadID { get; set; }

        public DateTime? LoadDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public virtual DimProductSubcategory DimProductSubcategory { get; set; }
    }
}
