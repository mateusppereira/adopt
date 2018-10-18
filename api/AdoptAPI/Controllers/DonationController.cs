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
    [RoutePrefix("api/donation")]
    public class DonationController : BaseController
    {
        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add(Donation donation)
        {
            Postgres connection = new Postgres(ConfigurationManager.ConnectionStrings["ADOPT"].ConnectionString);
            connection.BeginTransaction();

            var donationBusiness = new DonationBusiness();
            var result = donationBusiness.Add(connection, donation);
            if (result <= 0)
            {
                connection.Rollback();
                return GetResponseFromResults(HttpStatusCode.OK, "", null);
            }

            connection.Commit();
            return GetResponseFromResults(HttpStatusCode.OK, "", result);
        }

        [HttpGet]
        [Route("get/all")]
        public HttpResponseMessage GetAll()
        {
            Postgres connection = new Postgres(ConfigurationManager.ConnectionStrings["ADOPT"].ConnectionString);

            var donationBusiness = new DonationBusiness();
            var result = donationBusiness.GetAll(connection);

            return GetResponseFromResults(HttpStatusCode.OK, "", result);
        }

    }
}