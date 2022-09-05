﻿
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

                        if (contextFeature.Error is ItemNotFoundExeption)
                            statusCode = 404;

                        if (contextFeature.Error is ItemExsistExeption)
                            statusCode = 409;
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

