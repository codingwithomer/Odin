using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Odin.Common.CustomException;
using Odin.Common.Models;
using System.Collections.Generic;
using System.Net;

namespace Odin.WebApi.Filters
{
    public class ExceptionHandlerFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var concurrencyException = context.Exception as DbUpdateConcurrencyException;

            ErrorModel error;

            if (context.Exception is OdinException exception)
            {
                context.HttpContext.Response.StatusCode = (int)exception.HttpStatusCode;

                error = new ErrorModel(exception.Errors);
            }
            else if (context.Exception is DbUpdateConcurrencyException)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.TooManyRequests;

                var responseMessages = new List<string>();

                foreach (var entry in concurrencyException.Entries)
                {
                    responseMessages.Add(entry.Entity.GetType().FullName);
                }

                error = new ErrorModel(string.Join(", ", responseMessages.ToArray()));
            }
            else
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                error = new ErrorModel(context.Exception.InnerException?.Message ?? context.Exception.Message);
            }

            context.Result = new JsonResult(error);
        }
    }
}
