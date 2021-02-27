using NMS.Core.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NMS.Entities;

namespace NMS.Repo.Testing
{
   public interface ITestRepo
    {
        
        ListResult<Test> Get();
        ListResult<Test> Get(string searchKey);
        Result<Test> Save(Test dept);
        Result<bool> Delete(int id);
    }
}
