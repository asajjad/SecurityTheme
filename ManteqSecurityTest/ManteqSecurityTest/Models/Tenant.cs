using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManteqSecurityTest.Models
{
    public class Tenant : BaseEntity
    {
        public Tenant()
        {
            Users = new List<User>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public List<User> Users { get; set; }
        public Subscription Subscription { get; set; }
        public int SubscriptionId { get; set; }
    }
}