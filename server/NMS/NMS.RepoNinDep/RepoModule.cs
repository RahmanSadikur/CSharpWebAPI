using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Extensions.Conventions;
using NMS.Repo.Testing;
using NMS.RepoImp.Testing;

namespace NMS.RepoNinDep
{
    public class RepoModule : NinjectModule
    {

        public override void Load()
        {
            this.Bind<ITestRepo>().To<TestRepo>();
            //this.Bind(x => x
            //    .From("NMS.RepoImp")
            //    .SelectAllClasses()
            //    .InNamespaces("NMS.Repo")
            //    .BindAllInterfaces());
            ////MyCorp.*.dll
            //this.Bind(x => x.FromAssembliesMatching("NMS.*.dll")
            //       .SelectAllClasses()
            //       .BindAllInterfaces());
        }
    }
}
