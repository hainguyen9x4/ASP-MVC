using Model.Dao;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Areas.Admin.Data
{
  public class LoginModel
  {
    [Required(ErrorMessage = "This field is required!")]
    public string Username { get; set; }
    [Required(ErrorMessage = "This field is required!")]
    public string Password { get; set; }
    public bool Remember { get; set; }
  }
}