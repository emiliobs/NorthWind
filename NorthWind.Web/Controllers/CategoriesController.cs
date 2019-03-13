namespace NorthWind.Web.Controllers
{
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using NorthWind.Entities;
    using NorthWind.Services.Repositories;

    public class CategoriesController : Controller
    {
        private readonly ICategoryOperations categoryOperations;

        public CategoriesController(ICategoryOperations categoryOperations)
        {
            this.categoryOperations = categoryOperations;
        }


        public IActionResult Create(string name, string description)
        {

            IActionResult result;

            Category category = new Category()
            {
                CategoryName = name,
                Description = description,
            };

            category = this.categoryOperations.Create(category);

            if (category != null)
            {
                result = Content($"Etidad insertada { category.CategoryId }");
            }
            else
            {
                result = Content("No se pudo insertar la categoría");
            }

            return result;
        }

        public IActionResult Retrieve(int id)
        {
            IActionResult Result;
            var category = this.categoryOperations.RetrieveById(id);
            if (category != null)
            {
                Result = Content($"Entidad encontrada {category.CategoryId} , {category.CategoryName}");
            }
            else
            {
                Result = Content("No se pudo insertar la categoría");
            }

            return Result;
        }

        public IActionResult Update(int id, string name, string description)
        {
            IActionResult result;
            var category = new Category()
            {
                CategoryId = id,
                CategoryName = name,
                Description = description,
            };

            var updateResult = this.categoryOperations.Update(category);
            if (updateResult)
            {
                result = Content("Categoría modificada.");
            }
            else
            {
                result = Content("No se pudo actualizar la categoría.");
            }

            return result;

        }

        public IActionResult Delete(int id, bool withLog = false)
        {
            IActionResult result;

            var deleteResult = withLog ? this.categoryOperations.DeleteWithLog(id) : this.categoryOperations.Delete(id);

            if (deleteResult)
            {
                result = Content("Categoría eliminada.");
            }
            else
            {
                result = Content("No se pudo eliminar la categoría.");
            }

            return result;

        }

        public IActionResult GetAll() => View(this.categoryOperations.GetAll().OrderBy(c => c.CategoryName).ToList());

    }
}