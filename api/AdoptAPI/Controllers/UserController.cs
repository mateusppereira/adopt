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
    [RoutePrefix("api")]
    public class UserController : BaseController
    {
        [HttpPost]
        [Route("login")]
        public HttpResponseMessage Login(User user)
        {
            Postgres connection = new Postgres(ConfigurationManager.ConnectionStrings["ADOPT"].ConnectionString);
            connection.OpenConnection();

            var userBusiness = new UserBusiness();
            var foundedUser = userBusiness.Login(connection, user);

            connection.CloseConnection();
            return GetResponseFromResults(HttpStatusCode.OK, "", foundedUser);
        }

        [HttpPost]
        [Route("user/add")]
        public HttpResponseMessage Add(User user)
        {
            Postgres connection = new Postgres(ConfigurationManager.ConnectionStrings["ADOPT"].ConnectionString);
            connection.BeginTransaction();

            var userBusiness = new UserBusiness();
            var result = userBusiness.Add(connection, user);
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