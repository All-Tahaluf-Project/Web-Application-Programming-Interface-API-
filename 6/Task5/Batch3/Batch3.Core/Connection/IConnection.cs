using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Tahaluf.Task3OnionArchitectoure.Core.Connection
{
    public interface IConnection
    {
        DbConnection DBConnection { get; }
    }
}
