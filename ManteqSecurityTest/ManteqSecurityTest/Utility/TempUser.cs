using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManteqSecurityTest.Utility
{
    public static class TempUser
    {
        public static string UserName { get; set; }
        public static int TenantId { get; set; }
        public static int SelectedTenantId { get; set; }
    }
}