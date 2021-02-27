using NMS.Core.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMS.Core.Handlers
{
    public interface IErrorHandler
    {
        void Write(Exception ex);
        void Write(string message, Exception ex);
        void Write(Result result, Exception ex);
    }
}
