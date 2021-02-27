using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMS.Core.Object
{

    public class Result
    {
        private List<string> _messages = new List<string>();

        public List<String> Messages
        {
            get { return _messages; }
            set { _messages = value; }
        }

        public bool HasError { get; set; }
    }

    public class ListResult : Result
    {
        public int Count { get; set; }
    }

    public class Result<T> : Result
    {
        public T Data { get; set; }
    }

    public class ListResult<T> : ListResult
    {

        public IList<T> Data { get; set; }
        public dynamic ExtraData { get; set; }

        public ListResult()
        {
            ExtraData = new ExpandoObject();
        }
    }
}
