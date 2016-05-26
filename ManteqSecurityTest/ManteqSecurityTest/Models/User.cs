using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManteqSecurityTest.Models
{
    public class User : BaseEntity
    {
        public User()
        {
            Tenants = new List<Tenant>();
            Roles = new List<ManteqApplicationRole>();
        }
        public int Id { get; set; }
        public string UserName { get; set; }
        public List<Tenant> Tenants { get; set; }
        public List<ManteqApplicationRole> Roles { get; set; }
    }
}