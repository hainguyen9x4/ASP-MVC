using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Areas.Admin.Code
{
  public class SessionHelper
  {
    static public void SetSession(UserSession user_session)
    {
      HttpContext.Current.Session["loginSession"] = user_session;
    }
    static public UserSession GetSesstion()
    {
      var res = HttpContext.Current.Session["loginSession"];
      if(res == null)
      {
        return null;
      }
      else
      {
        return res as UserSession;
      }
    }
  }
}