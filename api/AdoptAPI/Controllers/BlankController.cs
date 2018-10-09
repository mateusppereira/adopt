using AdoptAPI.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Linq;
using AdoptAPI.Controllers;

namespace AdoptAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/login")]
    public class BlankController : BaseController
    {
        [HttpPost]
        [Route("")]
        public HttpResponseMessage Login(User user)
        {
            Postgres connection = new Postgres(ConfigurationManager.ConnectionStrings["ADOPT"].ConnectionString);


        }
    }
}