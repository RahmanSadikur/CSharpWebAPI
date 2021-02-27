using NMS.Core.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMS.Core.Handlers
{
    public interface IEnumHandler
    {
        EnumDetail GetEnum(int i, Type eType);
        EnumDetail GetEnumDetail(object i, Type eType);
        IList<EnumDetail> GetEnumList(Type enumType);
    }
}
