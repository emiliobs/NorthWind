namespace NorthWind.DAL
{
    using NorthWind.Entities;
    using NorthWind.Services.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class NorthWindRepository : INorthWindRepository, IDisposable
    {

        #region Atributtes
        private readonly NorthWindContext context;
        private readonly bool isUnitOfWork;

        #endregion

        #region Constructor

        public NorthWindRepository(bool isUnitOfWork = false)
        {
            context = new NorthWindContext();
            this.isUnitOfWork = isUnitOfWork;
        }

        #endregion

        #region Methods
        public Category CreateCategory(Category category)
        {
            category = context.Add<Category>(category).Entity;
            Save();

            return category;
        }


        public bool DeleteCategory(int categoryId)
        {
            context.Remove(new Category { CategoryId = categoryId });
            return Save();
        }

        public List<Category> GetCategories()
        {
            return context.Categories.ToList();
        }
        public Log CreateLog(Log log)
        {
            log = context.Add(log).Entity;
            Save();

            return log;
        }

        public List<Log> GetLogs()
        {
            return context.Logs.ToList();
        }

        public Category RetrieveCategoryById(int categpryId)
        {
            return context.Find<Category>(categpryId);
        }
        public bool UpdateCategory(Category category)
        {
            context.Update(category);
            return Save();
        }
        public int SaveChanges()
        {
            var result = 0;
            if (context != null)
            {
                try
                {
                    result = context.SaveChanges();
                }
                catch (Exception)
                {

                    //Aqui podemos manajar excepciones, por ejemmplo cuando no se puede eliminar una entidad
                    //o por conflictos de concurrencia:
                }

            }

            return result;
        }

        private bool Save()
        {
            var changes = 0;
            if (!isUnitOfWork)
            {
                changes = SaveChanges();
            }

            return changes == 1;
        }

        public void Dispose()
        {
            context.Dispose();
        }
        #endregion
    }
}
