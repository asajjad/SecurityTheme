namespace ManteqSecurityTest.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    internal sealed class Configuration : DbMigrationsConfiguration<ManteqSecurityTest.Models.EntityContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ManteqSecurityTest.Models.EntityContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //#region User

            //var userManteqAdmin = new User
            //{
            //    UserName = "User Manteq Admin"
            //};

            //var userA = new User
            //{
            //    UserName = "User A Tenant Admin",
            //    CreatedBy = 1,
            //    UpdatedBy = 1
            //};

            //var userB = new User
            //{
            //    UserName = "User B Tenant User",
            //    CreatedBy = 2,
            //    UpdatedBy = 2
            //};

            //var userC = new User
            //{
            //    UserName = "User C Tenant User",
            //    CreatedBy = 2,
            //    UpdatedBy = 2
            //};

            //context.Users.AddOrUpdate(userManteqAdmin);
            //context.Users.AddOrUpdate(userA);
            //context.Users.AddOrUpdate(userB);
            //context.Users.AddOrUpdate(userC);

            //#endregion User

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
            //tenantA.Users.Add(userA);
            //tenantA.Users.Add(userB);
            //tenantA.Users.Add(userC);

            //var tenantB = new Tenant
            //{
            //    Name = "Tenant B",
            //    Subscription = subscriptionB
            //};

            //context.Tenants.AddOrUpdate(tenantA);
            //context.Tenants.AddOrUpdate(tenantB);

            //#endregion Tenant
        }
    }
}
