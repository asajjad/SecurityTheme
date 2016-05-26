using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManteqSecurityTest.Models
{
    public class Subscription: BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateSubscribed { get; set; }
        public DateTime DateExpired { get; set; }
        public Licence Licence { get; set; }
        public int LicenceId { get; set; }
    }
}