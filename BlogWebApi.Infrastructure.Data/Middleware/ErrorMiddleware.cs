using BlogWebApi.Domain.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace BlogWebApi.Infrastructure.Data.Middleware
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _delegate;

        public ErrorMiddleware(RequestDelegate requestDelegate)
        {
            _delegate = requestDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _delegate(context);
            }
            catch(Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            ErrorModel errorModel;
            errorModel = new ErrorModel(HttpStatusCode.InternalServerError.ToString(), $"{ex.Message} {ex.InnerException?.Message}");

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(JsonConvert.SerializeObject(errorModel));

            return;
        }
    }
}
