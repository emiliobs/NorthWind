namespace NordhWind.BLL
{
    using NorthWind.Services.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public static class OperationsFactory
    {
         public static ICategoryOperations GetCategoryOperations()
        {
            return new CategoryOperations();
        }

        public static ILogOperations GetLogOperations()
        {
            return new LogOperations();
        }
    }
}
