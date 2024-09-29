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
            IEnumerable<Category_1> objList = _db1.Category_1;
            return View(objList);
        }

        //GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category_1 obj)
        {
            if (ModelState.IsValid)
            {
                _db1.Category_1.Add(obj);
                _db1.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET - EDIT
        public IActionResult Edit(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            var obj = _db1.Category_1.Find(id);
            if(obj==null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category_1 ob)
        {
            if(ModelState.IsValid)
            {
                _db1.Category_1.Update(ob);
                _db1.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        //GET - DELETE
        public ActionResult Delete(int? id)
        {
            if (id==0 || id==null)
            {  
                return NotFound(); 
            }
            var obj = _db1.Category_1.Find(id);
            if(obj==null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST - DELETE

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id)
        {
            var obj = _db1.Category_1.Find(id);
            if(obj==null)
            {
                return NotFound();
            }
           
                _db1.Category_1.Remove(obj);
                _db1.SaveChanges();
                return RedirectToAction("Index");
           
            
        }



    }
}
