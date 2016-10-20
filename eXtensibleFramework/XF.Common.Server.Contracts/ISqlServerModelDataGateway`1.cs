// <copyright file="ISqlServerModelDataGateway`1.cs" company="eXtensible Solutions LLC">
// Copyright © 2014 All Right Reserved
// </copyright>

namespace XF.Common
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ISqlServerModelDataGateway<T> : IModelDataGateway<T> where T : class, new()
    {
        SqlConnection DbConnection { get; set; }

    }
}
