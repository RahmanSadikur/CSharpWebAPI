using Ninject;
using NMS.Core.Object;
using NMS.Entities;
using NMS.Framework;
using NMS.Loc;
using NMS.Repo.Testing;
using NMS.RepoImp.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NMS.Controllers
{
    public class TestController : BaseController
    {
        ITestRepo _testRepo;
        public TestController()
        {
            // _testRepo = DependencyHandler.Get<ITestRepo>();
            // _testRepo = new TestRepo();
            _testRepo = Kernel.Current.Get<ITestRepo>();
        }
        [HttpGet]
        public ListResult<Test> Get()
        {
            return _testRepo.Get();
        }
        [HttpGet]

        public ListResult<Test> Get(string searchKey)
        {
            return _testRepo.Get(searchKey);
        }
        [HttpPost]
        public Result<Test> Save(Test value)
        {
            return _testRepo.Save(value);
        }
        [HttpDelete]
        public Result<bool> Delete(int id)
        {
            Result<bool> resultFromRepo = _testRepo.Delete(id);
            return resultFromRepo;
        }
    }
}
