using System.Web.Http;
using WebActivatorEx;
using CRUDCustomersWebAPI;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace CRUDCustomersWebAPI
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;
            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "WebApi");
                    c.IncludeXmlComments(string.Format(@"{0}\bin\CRUDCustomersWebAPI.xml",
                           System.AppDomain.CurrentDomain.BaseDirectory));
                })
                .EnableSwaggerUi();
        }
    }
}
