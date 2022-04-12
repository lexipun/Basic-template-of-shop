using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SomeShop.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UsePersonalMidlewares(this IApplicationBuilder app)
        {


            return app;
        }
    }
}
