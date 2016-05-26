using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManteqSecurityTest.Models
{
    public class ManteqApplicationRole : BaseEntity
    {
        public ManteqApplicationRole()
        {
            Users = new List<User>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }
}