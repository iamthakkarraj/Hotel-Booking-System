using System.Web.Http;
using WebActivatorEx;
using API;

using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace API
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            GlobalConfiguration.Configuration
                .EnableSwagger(c =>{
                    c.SingleApiVersion("v1", "API");
                    c.PrettyPrint();
                    c.OperationFilter<SwaggerAuthFilter>();                    
                })
                .EnableSwaggerUi(c =>{
                    c.DocumentTitle("My Swagger UI");
                    c.InjectStylesheet(typeof(SwaggerConfig).Assembly, "Swashbuckle.Dummy.SwaggerExtensions.testStyles1.css");                    
                });          
        }
    }
}
