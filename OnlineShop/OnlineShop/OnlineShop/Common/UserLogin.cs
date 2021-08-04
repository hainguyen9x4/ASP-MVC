using System;

namespace OnlineShop.Common
{
  [Serializable]
  public class UserLogin
  {
    public string UserName { get; set; }
    public long Id { get; set; }
  }
}