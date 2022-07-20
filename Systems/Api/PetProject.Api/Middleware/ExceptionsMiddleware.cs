using FluentValidation;
using Newtonsoft.Json;
using PetProject.Shared.Common.Exceptions;
using PetProject.Shared.Common.Extensions;
using PetProject.Shared.Common.Response;
using System.Text.Json;


namespace PetProject.Api.Middleware
{
    public class ExceptionsMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionsMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            ErrorResponse response = null;
            try
            {
                await next.Invoke(context);
            }
            catch (ValidationException e)
            {
                response = e.ToErrorResponse();
            }
            catch (ProcessException e)
            {
                response = e.ToErrorResponse();
            }
            catch (Exception e)
            {
                response = e.ToErrorResponse();
            }
            finally
            {
                if (!(response is null))
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(response));
                    await context.Response.StartAsync();
                    await context.Response.CompleteAsync();
                }
            }
        }
    }
}
