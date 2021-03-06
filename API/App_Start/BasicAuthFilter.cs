﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace API {

    public class BasicAuthFilterAttribute : AuthorizationFilterAttribute{

        public override void OnAuthorization(HttpActionContext actionContext) {            
            if (actionContext.Request.Headers.Authorization != null) {                
                var credentials 
                    = System.Text.Encoding
                        .UTF8.GetString(
                            Convert.FromBase64String(
                                actionContext.Request.Headers
                                .Authorization.Parameter))
                        .Split(':');
                if (IsAuthorizedUser(credentials[0], credentials[1])) {
                    AddPrincipleIdentity(credentials[0]);
                } else {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            } else {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        public static bool IsAuthorizedUser(string Username, string Password) {            
            return Username == "raj" && Password == "12345";
        }

        public static void AddPrincipleIdentity(string password) {
            Thread.CurrentPrincipal =new GenericPrincipal( new GenericIdentity(password), null);
        }

    }

}