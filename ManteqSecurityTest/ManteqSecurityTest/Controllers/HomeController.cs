using ManteqSecurityTest.Models;
using ManteqSecurityTest.Utility;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManteqSecurityTest.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {

        public ActionResult Index()
        {
            Seed(new EntityContext());
            //TempUser.UserName = model.UserName;
            //TempUser.TenantId = model.TenantId;
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel model)
        {
            TempUser.UserName = model.UserName;
            TempUser.TenantId = model.TenantId;
            TempUser.SelectedTenantId = model.SelectedTenantId;
            return View(model);
        }


        [ManteqAuthorize(Roles = "TenantUser", Module = "Clemittance")]
        public ActionResult Clemittance()
        {
            ViewBag.Message = "Clemittance Home Page.";

            return View();
        }

        [ManteqAuthorize("TenantUser", Module = "Cura")]
        public ActionResult Cura()
        {
            ViewBag.Message = "Cura Home Page";

            return View();
        }

        [ManteqAuthorize("TenantUser")]
        public ActionResult TenantA()
        {

            return View();
        }

        [ManteqAuthorize("TenantUser")]
        public ActionResult TenantB()
        {

            return View();
        }


        [ManteqAuthorize("TenantAdmin")]
        public ActionResult TenantAdminDashboard()
        {
            return View();
        }

        [ManteqAuthorize("ManteqAdmin")]
        public ActionResult ManteqAdminPage()
        {
            return View();
        }

        public ActionResult UnAuthorized()
        {
            return View();
        }


        void Seed(ManteqSecurityTest.Models.EntityContext context)
        {
            if (context.Users.ToList().Count > 0) return;
            try
            {
                var userManteqAdmin = new User
                {
                    UserName = "a.sajjad@manteq-me.com"

                };

                context.Users.AddOrUpdate(userManteqAdmin);

                var roleManteqAdmin = new ManteqApplicationRole { Name = "ManteqAdmin" };

                context.Roles.AddOrUpdate(roleManteqAdmin);

                //manteq admin
                roleManteqAdmin.Users.Add(userManteqAdmin);

                //#region User

                //var userManteqAdmin = new User
                //{
                //    UserName = "a.sajjad@manteq-me.com"

                //};

                //var userTenantAdmin = new User
                //{
                //    UserName = "a.sajjad@clemittance.com",
                //    CreatedBy = 1,
                //    UpdatedBy = 1

                //};

                //var userB = new User
                //{
                //    UserName = "User A",
                //    CreatedBy = 2,
                //    UpdatedBy = 2
                //};

                //var userC = new User
                //{
                //    UserName = "User B",
                //    CreatedBy = 2,
                //    UpdatedBy = 2
                //};

                //context.Users.AddOrUpdate(userManteqAdmin);
                //context.Users.AddOrUpdate(userTenantAdmin);
                //context.Users.AddOrUpdate(userB);
                //context.Users.AddOrUpdate(userC);

                //#endregion User

                //#region Roles

                //var roleManteqAdmin = new ManteqApplicationRole { Name = "ManteqAdmin" };
                //var roleTenantAdmin = new ManteqApplicationRole { Name = "TenantAdmin" };
                //var roleTenantUser = new ManteqApplicationRole { Name = "TenantUser" };

                ////manteq admin
                //roleManteqAdmin.Users.Add(userManteqAdmin);
                ////tenant admin
                //roleTenantAdmin.Users.Add(userTenantAdmin);
                ////other , change it later, testing only
                //roleTenantUser.Users.Add(userB);
                //roleTenantUser.Users.Add(userC);

                //context.Roles.AddOrUpdate(roleManteqAdmin);
                //context.Roles.AddOrUpdate(roleTenantAdmin);
                //context.Roles.AddOrUpdate(roleTenantUser);

                //#endregion Roles

                //#region Module

                //var Clemittance = new Module
                //{
                //    Name = "Clemittance"
                //};

                //var Cura = new Module
                //{
                //    Name = "Cura"
                //};

                //context.Modules.AddOrUpdate(Clemittance);
                //context.Modules.AddOrUpdate(Cura);

                //#endregion Module

                //#region Licence 

                //var licenceA = new Licence
                //{
                //    Name = "Basic",
                //    CreatedBy = 1,
                //    UpdatedBy = 1,
                //    Price = 50,
                //    UserLimit = 1
                //};
                //licenceA.Modules.Add(Clemittance);

                //var licenceB = new Licence
                //{
                //    Name = "Advanced",
                //    CreatedBy = 1,
                //    UpdatedBy = 1,
                //    Price = 100,
                //    UserLimit = 50
                //};
                //licenceB.Modules.Add(Clemittance);
                //licenceB.Modules.Add(Cura);

                //context.Licences.AddOrUpdate(licenceA);
                //context.Licences.AddOrUpdate(licenceB);

                //#endregion Licence

                //#region Subscription

                //var subscriptionA = new Subscription
                //{
                //    Name = "First Subscrption",
                //    DateSubscribed = DateTime.Now,
                //    DateExpired = DateTime.Now.AddMonths(1),
                //    Licence = licenceA
                //};

                //var subscriptionB = new Subscription
                //{
                //    Name = "First Subscrption",
                //    DateSubscribed = DateTime.Now,
                //    DateExpired = DateTime.Now.AddMonths(1),
                //    Licence = licenceB
                //};


                //context.Subscriptions.AddOrUpdate(subscriptionA);
                //context.Subscriptions.AddOrUpdate(subscriptionB);

                //#endregion Subscription

                //#region Tenant 

                //var tenantA = new Tenant
                //{
                //    Name = "Tenant A",
                //    Subscription = subscriptionA
                //};
                //tenantA.Users.Add(userTenantAdmin);
                //tenantA.Users.Add(userB);
                //tenantA.Users.Add(userC);

                //var tenantB = new Tenant
                //{
                //    Name = "Tenant B",
                //    Subscription = subscriptionB
                //};

                //tenantB.Users.Add(userB);
                //context.Tenants.AddOrUpdate(tenantA);
                //context.Tenants.AddOrUpdate(tenantB);

                //#endregion Tenant

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

    public class LoginViewModel
    {
        public string UserName { get; set; }
        public int TenantId { get; set; }
        public int SelectedTenantId { get; set; }
    }
}