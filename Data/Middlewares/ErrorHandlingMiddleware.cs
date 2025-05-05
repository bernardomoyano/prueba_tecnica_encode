using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Data.Entity;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Data.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (CustomHttpException ex)
            {
                context.Response.ContentType = "application/json";

                var response = new ResponseEntity
                {
                    Ok = false,
                    StatusCode = ex.StatusCode,
                    Message = ex.Message
                };

                var json = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(json);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";

                var response = new ResponseEntity
                {
                    Ok = false,
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = "Ocurrió un error inesperado."
                };

                var json = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(json);
            }
        }
    }
}
