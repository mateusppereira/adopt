using System.Net;
using System.Net.Http;
using System.Web.Http;
using AdoptAPI.Classes;

namespace AdoptAPI.Controllers
{
    public class BaseController : ApiController
    {
        protected HttpResponseMessage GetResponseFromResults(HttpStatusCode status, string message, object item)
        {
            return Request.CreateResponse(status, Helper.CreateResponse(false, message, item));
        }

        protected HttpResponseMessage GetResponseFromResults(HttpStatusCode status, bool hasErrors, string message, object item)
        {
            return Request.CreateResponse(status, Helper.CreateResponse(hasErrors, message, item));
        }

        protected HttpResponseMessage GetResponseFromGeneralError(string method, string message, string sql)
        {
            var log = new GenerateLog(string.Empty);
            log.WriteOnLogFile(true, "OCORREU UM EXCEPTION - " + method + " - 1: " + message, sql);
            return Request.CreateResponse(HttpStatusCode.InternalServerError, Helper.CreateResponse(true, message, null));
        }

        protected HttpResponseMessage GetResponseFromGeneralBadRequest(string method, string message)
        {
            return Request.CreateResponse(HttpStatusCode.BadRequest, Helper.CreateResponse(true, message, null));
        }
    }
}