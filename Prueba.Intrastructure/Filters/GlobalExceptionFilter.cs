using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;
using Prueba.Core.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace InsttanttFlujos.Infrastructure.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public readonly IWebHostEnvironment _hostingEnviroment;
        private readonly IModelMetadataProvider _modelMetadataProvier;

        public GlobalExceptionFilter(IWebHostEnvironment hostingEnviroment, IModelMetadataProvider modelMetadataProvier)
        {
            _hostingEnviroment = hostingEnviroment;
            _modelMetadataProvier = modelMetadataProvier;
        }

        public void OnException(ExceptionContext context)
        {
            //--------------------------------------------------------//
            //--   Para tlos errores tipo Rxception de status 400   --//
            //--------------------------------------------------------//
            if (context.Exception.GetType() == typeof(BusinessException))
            {
                var exception = (BusinessException)context.Exception;
                var validation = new
                {
                    Status = 400,
                    Title = "Bad Request",
                    Detail = exception.Message
                };

                var json = new
                {
                    errors = new[] { validation }
                };

                context.Result = new BadRequestObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.ExceptionHandled = true;
            }
            else
            {
                //------------------------------------------------//
                //--   Para todos los demas Errores generados   --//
                //------------------------------------------------//


                var xx = context.Exception.GetType();

                var exception = context.Exception;

                string  program = "", tipo = "", title = "", detail = "";

                if (context.Exception.GetType() == typeof(DbUpdateException))
                {
                    program = _hostingEnviroment.ApplicationName;
                    tipo = context.Exception.GetType().ToString();
                    title = exception.Message;
                    detail = exception.InnerException.Message.ToString();
                }
                else
                {
                    program = _hostingEnviroment.ApplicationName;
                    tipo = context.Exception.GetType().ToString();
                    title = exception.Message;
                    //detail = exception.InnerException.Message.ToString();
                }

                var validation = new
                {
                    Program = program,
                    Tipo = tipo,
                    Title = title,
                    Detail = detail,
                };

                var json = new
                {
                    Errors = new[] { validation }
                };

                context.Result = new JsonResult(json);
            }

        }
    }
}
