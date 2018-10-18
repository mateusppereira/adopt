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
using AdoptAPI.Models;
using AdoptAPI.Business;

namespace AdoptAPI.Controllers
{
    //[Authorize]
    [RoutePrefix("api/message")]
    public class LeadMessageController : BaseController
    {
        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add(LeadMessage message)
        {
            Postgres connection = new Postgres(ConfigurationManager.ConnectionStrings["ADOPT"].ConnectionString);
            connection.BeginTransaction();

            var leadMessageBusiness = new LeadMessageBusiness();
            var result = leadMessageBusiness.Add(connection, message);
            if (result <= 0)
            {
                connection.Rollback();
                return GetResponseFromResults(HttpStatusCode.OK, "", null);
            }

            connection.Commit();
            return GetResponseFromResults(HttpStatusCode.OK, "", result);
        }
    }
}