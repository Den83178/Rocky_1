using Microsoft.AspNetCore.Mvc;
using Rocky_1.Models;
using Rocky_1.Name;

namespace Rocky_1.Controllers
{
    public class Category_1Controller : Controller
    {
        private readonly ApplicationDbContext_1 _db1;

        public Category_1Controller(ApplicationDbContext_1 db)
        {
            _db1 = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category_1 > objList = _db1.Category_1;
            return View(objList);
        }
    }
}
