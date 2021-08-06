﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.ViewModel
{
  public class ProductViewModel
  {
    public long ID { get; set; }
    [Required]
    [StringLength(250)]
    public string Name { get; set; }
    [Required]
    [StringLength(20)]
    public string Code { get; set; }

    [StringLength(500)]
    public string Description { get; set; }

    [StringLength(250)]
    public string Avatar { get; set; }

    [Column(TypeName = "xml")]
    public string MoreImage { get; set; }
    [Required]
    public decimal? Price { get; set; }

    public decimal? PromationPrice { get; set; }

    public bool? IncludeVAT { get; set; }
    [Required]
    public int Quanlity { get; set; }
    public string CategoryName { get; set; }

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

    public DateTime? TopHot { get; set; }

    public int? ViewCount { get; set; }
  }
}
