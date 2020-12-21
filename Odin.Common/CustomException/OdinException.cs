using System;
using System.Collections.Generic;
using System.Net;

namespace Odin.Common.CustomException
{
    public class OdinException : Exception
    {
        public HttpStatusCode HttpStatusCode { get; set; }

        public List<string> Errors { get; set; }

        public OdinException(params string[] errors)
        {
            HttpStatusCode = HttpStatusCode.BadRequest;
            Errors = new List<string>();
            Errors.AddRange(errors);
        }

        public OdinException(HttpStatusCode httpStatusCode, params string[] errors)
        {
            HttpStatusCode = httpStatusCode;
            Errors = new List<string>();
            Errors.AddRange(errors); 
        }
    }
}
