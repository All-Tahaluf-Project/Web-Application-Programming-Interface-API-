using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Tahaluf.Batsh3DB.Core.Common
{
    public interface IDBContext
    {
        DbConnection Connection { get; }
    }
}
