
using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;

public static class ExeptionHandeler
    {
        public static void UseCustomExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(error =>
            {
                error.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    int statusCode = 500;
                    string msg = "Internal server error!";

                    if (contextFeature != null)
                    {
                        msg = contextFeature.Error.Message;

                        if (contextFeature.Error is OutOfStack)
                            statusCode = 409;

                        if (contextFeature.Error is InvalidProductId)
                            statusCode = 404;
                    }

                    context.Response.StatusCode = statusCode;

                    string responseStr = JsonConvert.SerializeObject(new
                    {
                        code = statusCode,
                        message = msg
                    });

                    await context.Response.WriteAsync(responseStr);
                });
            });

        }
    }

