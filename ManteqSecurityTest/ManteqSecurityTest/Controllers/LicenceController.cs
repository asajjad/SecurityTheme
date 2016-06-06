using ManteqSecurityTest.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManteqSecurityTest.Controllers
{
    [Authorize]
    public class LicenceController : Controller
    {
        [ManteqAuthorize("ManteqAdmin")]
        public ActionResult Index()
        {
            return View();
        }
    }
}