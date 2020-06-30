using Microsoft.SqlServer.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xMap.Persistent.Base
{
    public interface IXPGeometry:DevExpress.Xpo.IXPObject
    {
        SqlGeometry Shape { get; set; }
    }

}
