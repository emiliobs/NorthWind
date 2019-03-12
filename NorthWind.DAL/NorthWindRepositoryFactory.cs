namespace NorthWind.DAL
{
    using NorthWind.Services.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public static class NorthWindRepositoryFactory
    {
        public static INorthWindRepository GetNorthWindRepository(bool isUnitOfWork = false)
        {
            return new NorthWindRepository(isUnitOfWork);
        }
    }
}
