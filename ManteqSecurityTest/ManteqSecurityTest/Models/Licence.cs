using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManteqSecurityTest.Models
{
    public class Licence : BaseEntity
    {
        public Licence()
        {
            Modules = new List<Module>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public long UserLimit { get; set; }
        public List<Module> Modules { get; set; }
        
    }
}