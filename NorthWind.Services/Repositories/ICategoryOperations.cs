namespace NorthWind.Services.Repositories
{
    using NorthWind.Entities;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public interface ICategoryOperations
    {
        Category Create(Category category);
        Category RetrieveById(int categoryId);
        bool Update(Category category);
        bool Delete(int CategoryId);
        List<Category> GetAll();
        bool DeleteWithLog(int categoryId);
    }
}
