using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;

namespace PODBProjectWebApi.Services
{
    public class ServiceResponse
    {
        public string Response { get; set; }
        public string Message { get; set; }
        public HttpStatusCode Status { get; set; }
    }
}