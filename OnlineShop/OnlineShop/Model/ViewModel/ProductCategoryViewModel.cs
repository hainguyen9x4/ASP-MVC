using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
  public class ProductCategoryViewModel
  {
    public long ID { get; set; }
    [StringLength(250)]
    public string Name { get; set; }
    [StringLength(250)]
    public string MetaTitle { get; set; }
    public int? DisplayOrder { get; set; }
    [StringLength(10)]
    public string SeoTitle { get; set; }
    public DateTime? CreatedDate { get; set; }
    [StringLength(20)]
    public string CreatedBy { get; set; }
    public bool? Status { get; set; }
    public bool? ShowOnHome { get; set; }
    public int NumberProduct { get; set; }
  }
}
