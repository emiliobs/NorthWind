namespace NorthWind.Services.Repositories
{
    using NorthWind.Entities;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ILogOperations
    {
        List<Log> GetAll();
    }
}
