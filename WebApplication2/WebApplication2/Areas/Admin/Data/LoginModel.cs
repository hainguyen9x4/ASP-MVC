using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Areas.Admin.Data
{
  public class LoginModel
  {
    [Required]
    public string Username { get; set; }
    public string Password { get; set; }
    public bool Remember { get; set; }
  }
}