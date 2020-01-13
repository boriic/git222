using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Routing;

namespace Mono.Project.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //Enable CORS
            config.EnableCors(new EnableCorsAttribute("http://localhost:4200", headers: "*", methods: "*"));
            config.MapHttpAttributeRoutes();
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new DefaultContractResolver { IgnoreSerializableAttribute = true };
        }
    }
}
