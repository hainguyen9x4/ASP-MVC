using System.ComponentModel.DataAnnotations;

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