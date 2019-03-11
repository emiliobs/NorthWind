namespace NorthWind.Services.Repositories
{
    using NorthWind.Entities;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public interface INorthWindRepository :IDisposable
    {
        //CAtegory Domini0:
        Category CreateCategory(Category category);
        Category RetrieveCategoryById(int categpryId);
        bool UpdateCategory(Category category);
        bool DeleteCategory(int categoryId);
        List<Category> GetCategories();

        //Log:
        List<Log> GetLogs();
        Log CreateLog(Log log);

        //Patrón UnitOfWork
        int SaveChanges();
    }
}
