using NMS.Core.Handlers;
using NMS.Core.Object;
using NMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.SqlServer;

namespace NMS.RepoImp.Bases
{
    public class BaseRepo
    {

        private Context _contextHandler;



        public Context ContextHandler
        {
            get
            {
                if (_contextHandler == null)
                    _contextHandler = new Context();
                return _contextHandler;
            }
            protected set { _contextHandler = value; }
        }
        protected void CopyObject<T>(ref T source, ref T destination)
        {


            var parentProperties = source.GetType().GetProperties();
            var childProperties = destination.GetType().GetProperties();

            foreach (var parentProperty in parentProperties)
            {
                foreach (var childProperty in childProperties)
                {
                    if (parentProperty.Name == childProperty.Name && parentProperty.PropertyType == childProperty.PropertyType)
                    {
                        childProperty.SetValue(destination, parentProperty.GetValue(source));
                        break;
                    }
                }
            }

        }


        protected void SetError(Exception ex, Result result)
        {
            result.HasError = true;
            result.Messages.Add(ex.Message);
        }
    }
}
