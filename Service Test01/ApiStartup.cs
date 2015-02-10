using Owin;
using System.Web.Http;

namespace Service_Test01
{
    class ApiStartup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            //Configure Web API for self-hosting
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );

            appBuilder.UseWebApi(config);
        }
    }
}
