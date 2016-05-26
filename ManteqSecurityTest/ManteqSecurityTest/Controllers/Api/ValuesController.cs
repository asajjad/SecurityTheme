using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ManteqSecurityTest.Controllers.Api
{
    public class ValuesController : ApiController
    {

        public IHttpActionResult GetAll()
        {
            return this.Ok("ValuesGetAll");
        }

        [Authorize]
        public IHttpActionResult GetSpecific()
        {
            return this.Ok("GetSpecific");
        }
    }
}
