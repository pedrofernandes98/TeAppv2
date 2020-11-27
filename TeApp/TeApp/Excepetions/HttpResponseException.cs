using System;
using System.Collections.Generic;
using System.Net;
using TeApp.Models;

namespace TeApp.Excepetions
{
    public class HttpResponseException : Exception
    {
        public HttpStatusCode StatusCode { get; private set; }
        public string Details { get; set; }
        public string RequestUrl { get; set; }
        public string Exception { get; set; }

        public List<ErrorModel> Errors { get; set; }

        public HttpResponseException(HttpStatusCode statusCode, string details, string requestUrl, string excepetion, List<ErrorModel> errors) : base(excepetion)
        {
            StatusCode = statusCode;
            Details = details;
            RequestUrl = requestUrl;
            Exception = excepetion;
            Errors = errors;
        }
    }
}
