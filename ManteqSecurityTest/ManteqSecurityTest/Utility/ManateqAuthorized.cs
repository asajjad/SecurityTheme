using ManteqSecurityTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;


namespace ManteqSecurityTest.Utility
{
    public class ManteqAuthorizeAttribute : AuthorizeAttribute
    {
        private string[] UserAssignedRoles;
        public string Module { get; set; }
        public ManteqAuthorizeAttribute(params string[] roles)
        {
            this.UserAssignedRoles = roles;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool isAuthorized = false;
            var user = httpContext.User;

            if (!user.Identity.IsAuthenticated)
            {
                return false;
            }

            #region Authorize logic

            using (var context = new EntityContext())
            {
                var userName = System.Security.Claims.ClaimsPrincipal.Current.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").Value;
#if DEBUG
                //userName = TempUser.UserName;u
                //userName = "a.sajjad@clemittance.com";
#endif
                var dbUser = context.Users.Include(s => s.Roles).FirstOrDefault(u => u.UserName == userName);
                if (dbUser == null)
                {
                    return false;
                }

                //user role 
                foreach (var role in UserAssignedRoles)
                {
                    //for manteq admin
                    if (dbUser.Roles.Count(r => r.Name == role && r.Name == "ManteqAdmin") > 0)
                        return true;
                    else if (dbUser.Roles.Count(r => r.Name == role && r.Name == "TenantAdmin") > 0)
                        return true;
                    else if (dbUser.Roles.Count(r => r.Name == role) > 0)
                        isAuthorized = true;
                    else
                        return false;
                }
                //tenant subscription access control
                //user -> tenant -> subscription -> licence -> module
                {
                    // var tenants = context.Users.Include(u => u.Tenants).Where(u => u.UserName == userName).SelectMany(u => u.Tenants).Where(t => t.Id == TempUser.TenantId).ToList();
                    var tenant = context.Users.Include(u => u.Tenants).Where(u => u.UserName == userName).SelectMany(u => u.Tenants).FirstOrDefault(t => t.Id == TempUser.TenantId);
                    if (tenant == null)
                        return false;
                    if (tenant.Id != TempUser.SelectedTenantId)
                        isAuthorized = false;
                    else {
                        isAuthorized = true;
                        var subscription = context.Subscriptions.Single(s => s.Id == tenant.SubscriptionId);
                        if (!string.IsNullOrEmpty(Module))
                        {
                            var moduleIds = context.Modules.Where(s => s.Name == Module).Select(s => s.Id).ToArray();
                            isAuthorized = context.Licences.Include(l => l.Modules).Where(l => l.Id == subscription.LicenceId).Any(q => q.Modules.Any(m => moduleIds.Contains(m.Id)));
                        }
                    }

                }


            }

            #endregion Authorize logic

            return isAuthorized;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult("~/Home/UnAuthorized");
        }
    }
}