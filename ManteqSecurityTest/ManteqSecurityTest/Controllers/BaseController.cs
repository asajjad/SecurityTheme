using ManteqSecurityTest.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManteqSecurityTest.Controllers
{
    public class BaseController : Controller
    {
        protected ExtendedUserProfile ExtendedUserProfile { get; set; }
        protected void PopulateExtendedUserProfile()
        {
            if (System.Security.Claims.ClaimsPrincipal.Current != null)
            {
                if (System.Security.Claims.ClaimsPrincipal.Current.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress") != null)
                {
                    ExtendedUserProfile = new ExtendedUserProfile();
                    ExtendedUserProfile.Email = System.Security.Claims.ClaimsPrincipal.Current.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").Value;
                    //ExtendedUserProfile.FullName = claimPrincipal.Claims.FirstOrDefault(c => c.Type == "name").Value;
                    ExtendedUserProfile.FullName = System.Security.Claims.ClaimsPrincipal.Current.FindFirst("name").Value;
                    ExtendedUserProfile.ObjectIdentifier = System.Security.Claims.ClaimsPrincipal.Current.FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier").Value;
                }
            }
        }
    }
}