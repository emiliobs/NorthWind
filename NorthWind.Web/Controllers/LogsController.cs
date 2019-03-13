namespace NorthWind.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using NorthWind.Services.Repositories;

    public class LogsController : Controller
    {
        private readonly ILogOperations logOperations;

        public LogsController(ILogOperations logOperations)
        {
            this.logOperations = logOperations;
        }

        public IActionResult AllLogs() => View(this.logOperations.GetAll());



    }
}