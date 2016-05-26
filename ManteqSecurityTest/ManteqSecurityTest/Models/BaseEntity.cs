using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManteqSecurityTest.Models
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            DateCreation = DateTime.Now;
            DateUpdated = DateTime.Now;
            IsActive = true;
        }
        //all these fields are required
        public DateTime? DateCreation { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}