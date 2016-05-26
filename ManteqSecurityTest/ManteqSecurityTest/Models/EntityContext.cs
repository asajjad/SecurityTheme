using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ManteqSecurityTest.Models
{
    public class EntityContext : DbContext
    {
        public EntityContext()
            : base("EntityContext")
        {
            Database.SetInitializer<EntityContext>(null);
        }
        public static EntityContext Create()
        {
            return new EntityContext();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Licence> Licences { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<ManteqApplicationRole> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.
                Conventions.
                Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
            MapCustom(modelBuilder);
        }

        private void MapCustom(DbModelBuilder modelBuilder)
        {
            //UserRole
            modelBuilder.Entity<User>()
              .HasMany<ManteqApplicationRole>(s => s.Roles)
              .WithMany(c => c.Users)
              .Map(cs =>
              {
                  cs.MapLeftKey("UserId");
                  cs.MapRightKey("RoleId");
                  cs.ToTable("UserManteqApplicationRole");
              });
            //LicenceModule
            modelBuilder.Entity<Module>()
              .HasMany<Licence>(s => s.Licences)
              .WithMany(c => c.Modules)
              .Map(cs =>
              {
                  cs.MapLeftKey("ModuleId");
                  cs.MapRightKey("LicenceId");
                  cs.ToTable("LicenceModule");
              });
            //UserTenant
            modelBuilder.Entity<User>()
              .HasMany<Tenant>(s => s.Tenants)
              .WithMany(c => c.Users)
              .Map(cs =>
              {
                  cs.MapLeftKey("UserId");
                  cs.MapRightKey("TenantId");
                  cs.ToTable("UserTenant");
              });

        }

    }
}