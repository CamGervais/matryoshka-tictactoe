using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace TicTacToe.WepApi.Controllers.Exceptions
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            HttpStatusCode status;
            string message;

            var exceptionType = context.Exception.GetType();
            if (exceptionType == typeof(InvalidPlayMoveException))
            {
                message = context.Exception.ToString();
                status = HttpStatusCode.BadRequest;
            }
            else
            {
                message = context.Exception.Message;
                status = HttpStatusCode.InternalServerError;
            }
            context.ExceptionHandled = true;

            HttpResponse response = context.HttpContext.Response;
            response.StatusCode = (int)status;
            response.ContentType = "application/json";
            var err = message + " " + context.Exception.StackTrace;
            response.WriteAsync(err);
        }
    }
}
