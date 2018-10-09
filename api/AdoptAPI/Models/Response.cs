using System.Runtime.Serialization;

namespace AdoptAPI.Models
{
    public class Response
    {
        public bool HasErrors { get; set; }
        public string Message { get; set; }
        public object ObjectResult { get; set; }
    }
}