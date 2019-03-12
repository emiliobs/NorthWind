namespace NordhWind.BLL
{
    using NorthWind.DAL;
    using NorthWind.Entities;
    using NorthWind.Services.Repositories;
    using System;
    using System.Collections.Generic;

    public class LogOperations : ILogOperations
    {
        public List<Log> GetAll()
        {
            return NorthWindRepositoryFactory.GetNorthWindRepository().GetLogs();
        }
    }
}
