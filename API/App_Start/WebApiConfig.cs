﻿using Swashbuckle.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API {

    public static class WebApiConfig {

        public static void Register(HttpConfiguration config) {

            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
            config.MapHttpAttributeRoutes();
            config.Filters.Add(new BasicAuthFilterAttribute());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(        
                name: "swagger_root",        
                routeTemplate: "",        
                defaults: null,        
                constraints: null,                
                handler: new RedirectHandler((message => message.RequestUri.ToString()), "swagger"));            

            config.Formatters.Remove(config.Formatters.XmlFormatter);            
        }

    }

}