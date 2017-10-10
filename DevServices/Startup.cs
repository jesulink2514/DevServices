using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using NSwag.AspNet.Owin;
using Owin;

[assembly: OwinStartup(typeof(DevServices.Startup))]

namespace DevServices
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseSwagger(typeof(Startup).Assembly, new SwaggerSettings());

            app.UseSwaggerUi3(typeof(Startup).Assembly, new SwaggerUi3Settings());
        }
    }
}
