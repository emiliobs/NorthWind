namespace NordhWind.BLL
{
    using System.Collections.Generic;
    using NorthWind.DAL;
    using NorthWind.Entities;
    using NorthWind.Services.Repositories;
    public class CategoryOperations : ICategoryOperations
    {
        public Category Create(Category category)
        {
            if (!string.IsNullOrEmpty(category.CategoryName))
            {
                using (var repository = NorthWindRepositoryFactory.GetNorthWindRepository())
                {
                    category = repository.CreateCategory(category);
                }
            }
            else
            {
                category = null;
            }

            return category;
        }

        public bool Delete(int categoryId)
        {
            var result = false;
            using (var repository = NorthWindRepositoryFactory.GetNorthWindRepository())
            {
                result = repository.DeleteCategory(categoryId);
            }

            return result;
        }

        public bool DeleteWithLog(int categoryId)
        {
            var result = false;
            using (var repository = NorthWindRepositoryFactory.GetNorthWindRepository())
            {
                result = repository.DeleteCategory(categoryId);
                var log = new Log()
                {
                    Type = LogType.DeleteCategory,
                    Message = $"ID: {categoryId}",
                };
                repository.CreateLog(log);
                result = repository.SaveChanges() == 2; //2 opciones esperadas
            }

            return result;
        }

        public List<Category> GetAll()
        {
            return NorthWindRepositoryFactory.GetNorthWindRepository().GetCategories();
        }

        public Category RetrieveById(int categoryId)
        {
            Category result = null;

            if (categoryId > 0)
            {
                using (var repository = NorthWindRepositoryFactory.GetNorthWindRepository())
                {
                    result = repository.RetrieveCategoryById(categoryId);
                }
            }

            return result;
        }

        public bool Update(Category category)
        {
            var result = false;
            using (var repository = NorthWindRepositoryFactory.GetNorthWindRepository())
            {
                result = repository.UpdateCategory(category);
            }

            return result;
        }
    }
}
