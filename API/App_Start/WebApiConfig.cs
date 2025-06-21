using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

// ← הוספתי את זה

namespace API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // ✨ הפעלת CORS לכל המקורות (לבדיקות בלבד)
            var cors = new EnableCorsAttribute("http://localhost:3000", "*", "*");
            config.EnableCors(cors);

            // שימוש ב-JSON בלבד
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.Add(config.Formatters.JsonFormatter);

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "CarHelpRequestersApi",
                routeTemplate: "api/CarHelpRequesters/Get_CarHelpRequesters_Max_Unapproved_Requests",
                defaults: new { controller = "CarHelpRequesters", action = "Get_CarHelpRequesters_Max_Unapproved_Requests" }
            );
        }
    }
}
