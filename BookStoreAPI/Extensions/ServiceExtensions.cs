using BookStoreDomain;
using Microsoft.AspNetCore.Diagnostics;
using NLog.Fluent;

namespace BookStoreAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler( error =>
            {
                error.Run(async context =>
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if(contextFeature != null)
                    {
                        Log.Error($"Something Went Wrong in the {contextFeature.Error}");

                        await context.Response.WriteAsync(new ErrorDetails
                        {
                            Status = context.Response.StatusCode,
                            Message = "Internal Server Error, Please Try Again Later."
                        }.ToString());
                    }
                });
            });
        }
    }
}
