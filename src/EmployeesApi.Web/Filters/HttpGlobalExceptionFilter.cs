using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using Abp.Dependency;
using Abp.Events.Bus.Exceptions;
using Abp.Events.Bus.Handlers;
using Castle.Core.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeesApi.Filters
{
    public class HttpGlobalExceptionFilter : IExceptionFilter
    {
        public ILogger Logger { get; set; }

        public HttpGlobalExceptionFilter()
        {
            Logger = NullLogger.Instance;
        }

        public void OnException(ExceptionContext context)
        {
            var errorMessages = new List<string>();
            try
            {
                var validationErrors = context.Exception
                        .GetType()
                        .GetProperty("ValidationErrors", 
                                    BindingFlags.FlattenHierarchy | 
                                    BindingFlags.Instance | 
                                    BindingFlags.Public)
                        .GetValue(context.Exception);
                if (validationErrors is IEnumerable)
                {
                    foreach (var validationError in validationErrors as IEnumerable)
                    {
                        var errorMessage =
                        validationError.GetType()
                                   .GetProperty("ErrorMessage",
                                      BindingFlags.FlattenHierarchy |
                                      BindingFlags.Instance |
                                      BindingFlags.Public)
                                   .GetValue(validationError);
                        errorMessages.Add(errorMessage.ToString());
                    }
                }
            }
            catch(Exception ex){
                Logger.Error(ex.Message);
            }
            var handledResult = new HandledExceptionDetails(new ErrorDetails(errorMessages.FirstOrDefault()));
            context.Result = new BadRequestObjectResult(handledResult);
            context.HttpContext.Response.StatusCode = errorMessages.Any() ? (int)HttpStatusCode.BadRequest : (int)HttpStatusCode.InternalServerError;
        }

        internal class HandledExceptionDetails
        {
            public HandledExceptionDetails(ErrorDetails error)
            {
                Succcess = false;
                Result = null;
                Error = error;
            }

            public bool Succcess { get; set; }

            public object Result { get; set; }

            public ErrorDetails Error { get; set; }
        }
        internal class ErrorDetails
        {
            private const string _defaultErrorMessage = "Couldn't make operation at this time!";
            public ErrorDetails(string message)
            {
                Message = string.IsNullOrEmpty(message) ? _defaultErrorMessage : message;
            }
            public string Message { get; set; }
        }
    }
}
