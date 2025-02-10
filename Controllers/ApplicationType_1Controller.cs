using Microsoft.AspNetCore.Mvc;
using Rocky_1.Models;
using Rocky_1.Name;

namespace Rocky_1.Controllers
{
    public class ApplicationType_1Controller : Controller
    {
        private readonly ApplicationDbContext_1 _db_at_1;

        public ApplicationType_1Controller(ApplicationDbContext_1 db_at_1)
        {
            _db_at_1 = db_at_1;
        }

        public IActionResult Index()
        {
            IEnumerable<ApplicationType_1> ob_at = _db_at_1.ApplicationType_1;
            return View(ob_at);
        }

        //GET - Create
        public IActionResult Create()
        {
            return View();
        }

        //POST - Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ApplicationType_1 type_1)
        {
            _db_at_1.ApplicationType_1.Add(type_1);
            _db_at_1.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET - Edit
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var ob_ed = _db_at_1.ApplicationType_1.Find(id);
            return View(ob_ed);
        }

        //POST - Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ApplicationType_1 ob_ed)
        {
            if (ModelState.IsValid)
            {
                _db_at_1.ApplicationType_1.Update(ob_ed);
                _db_at_1.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        //GET - Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var ob_del = _db_at_1.ApplicationType_1.Find(id);
            return View(ob_del);
        }

        //POST - Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete_AT(int? id)
        {
            if(ModelState.IsValid)
            {
                var ob_del = _db_at_1.ApplicationType_1.Find(id);
                _db_at_1.ApplicationType_1.Remove(ob_del);
                _db_at_1.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        

    }
}
