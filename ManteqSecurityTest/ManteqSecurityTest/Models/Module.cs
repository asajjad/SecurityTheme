using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManteqSecurityTest.Models
{
    public class Module : BaseEntity
    {
        public Module()
        {
            Licences = new List<Licence>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Licence> Licences { get; set; }
    }
}