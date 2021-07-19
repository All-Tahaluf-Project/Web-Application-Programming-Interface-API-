using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace OurProject.Core.Connection
{
    public interface IConnection
    {
        DbConnection DBConnection { get; }
    }
}
