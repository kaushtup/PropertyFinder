﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using PropertyFinder.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyFinder.Core
{
    public class Middleware
    {
        private readonly RequestDelegate _next;

        private static IDbHelper _dbHelper;

        public Middleware(RequestDelegate next)
        {
            _next = next;

        }

        public async Task Invoke(HttpContext httpContext, IDbHelper dbHelper)
        {
            _dbHelper = dbHelper;

            var users = await _dbHelper.GetUsersAsync();

            await _next.Invoke(httpContext);
            //return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware>();
        }
    }
}
