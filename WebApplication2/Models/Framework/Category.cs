namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        public int ID { get; set; }

        [StringLength(20,ErrorMessage ="Must less than 20 characters")]
        [Required(ErrorMessage ="This field is required!")]
        [Display(Name="Name of category")]
        public string Name { get; set; }

        public DateTime? CreatedDate { get; set; }
        [Range(0,100,ErrorMessage ="Accept value from 0 to 100")]
        public int? Order { get; set; }

        public bool? Status { get; set; }
    }
}
