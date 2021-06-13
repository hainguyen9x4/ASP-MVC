namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Content")]
    public partial class Content
    {
        public long ID { get; set; }

        [StringLength(250)]
        [Required]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(250)]
        public string Avatar { get; set; }

        [Column(TypeName = "xml")]
        public string MoreImage { get; set; }

        public long? CategoryID { get; set; }

        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

        public int? Warranty { get; set; }

        [StringLength(250)]
        public string MetaDescription { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(20)]
        public string CreatedBy { get; set; }

        public DateTime? ModifyDate { get; set; }

        [StringLength(20)]
        public string ModifyBy { get; set; }

        [StringLength(250)]
        public string MetaKeyword { get; set; }

        public bool? Status { get; set; }

        public DateTime? TopHot { get; set; }

        public int? ViewCount { get; set; }

        [StringLength(500)]
        public string Tag { get; set; }
    }
}
