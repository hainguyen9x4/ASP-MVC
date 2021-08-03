﻿namespace Model.EF
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Data.Entity.Spatial;

  [Table("Logo")]
  public partial class Logo
  {
    public int ID { get; set; }
    [StringLength(250)]
    public string Name { get; set; }
    [StringLength(250)]
    public string Image { get; set; }
    public bool? Status { get; set; }

    public DateTime? CreatedDate { get; set; }

    [StringLength(20)]
    public string CreatedBy { get; set; }

    public DateTime? ModifyDate { get; set; }

    [StringLength(20)]
    public string ModifyBy { get; set; }
  }
}
