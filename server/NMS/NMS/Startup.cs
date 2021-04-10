
using System.Data.Entity;

using System.Web.Http;
using Microsoft.Owin;
//using Microsoft.Owin.Security.OAuth;
using Ninject;
using Ninject.Web.Common;
using NMS.Loc;
using NMS.RepoNinDep;
using Owin;

[assembly: OwinStartup("NMS", typeof(NMS.Startup))]
namespace NMS
{
    public class Startup
    {
        private static readonly Bootstrapper Bootstrap = new Bootstrapper();
        public void Configuration(IAppBuilder app)
        {
            //This command is require to make sure that system will not regenerate tables or recreate the databse or modify the database.
            Database.SetInitializer<DbContext>(null);

            // ConfigureOAuth(app);

            var config = new HttpConfiguration();

            //config.EnableCors(new EnableCorsAttribute("*", "*", "GET, POST, OPTIONS, PUT, DELETE"));
            WebApiConfig.Register(config);

            // app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            //app.UseWebApi(config);


            Bootstrap.Initialize(CreateKernel);
        }
        private IKernel CreateKernel()
        {
            var kernel = Kernel.Current;



            kernel.Load(new RepoModule());

            return kernel;
        }
    }
}