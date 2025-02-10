using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Rocky_1.Models.ViewModels;
using Rocky_1.Models;
using Rocky_1.Name;
using System.Net.NetworkInformation;
using Microsoft.EntityFrameworkCore;


namespace Rocky_1.Controllers
{
    public class Product_1Controller : Controller
    {

        private readonly ApplicationDbContext_1 _ob_prod;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public Product_1Controller(ApplicationDbContext_1 ob_prod, IWebHostEnvironment webHostEnvironment)
        {
            _ob_prod = ob_prod;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            IEnumerable<Product_1> obj_pr = _ob_prod.Product_1.Include(x => x.Category_1).Include(x => x.ApplicationType_1);

            //foreach(var obj in obj_pr)
            //{
            //    obj.Category_1 = _ob_prod.Category_1.FirstOrDefault();
            //    obj.ApplicationType_1 = _ob_prod.ApplicationType_1.FirstOrDefault();
            //}

            //foreach (var obj in obj_pr)
            //{
            //    obj.Category_1 = _ob_prod.Category_1.FirstOrDefault(i => i.Id == obj.Category_1_Id);
            //    obj.ApplicationType_1 = _ob_prod.ApplicationType_1.FirstOrDefault((s) => s.Id == obj.ApplicationType_1_Id);
            //}

            return View(obj_pr);
        }

        //Get - Upsert
        public IActionResult Upsert(int? id)
        {
            //IEnumerable<SelectListItem> Category_1DropDown = _ob_prod.Category_1.Select(i => new SelectListItem
            //{
            //    Text = i.Name,
            //    Value = i.Id.ToString()
            //});

            //ViewBag.Category_1DropDown = Category_1DropDown;
            //ViewData["Category_1DropDown"] = Category_1DropDown;
            //Product_1 product_1 = new Product_1();

            ProductVM_1 productVM_1 = new ProductVM_1()
            {
                Product_1 = new Product_1(),
                CategorySelectList_1 = _ob_prod.Category_1.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                ApplicationTypeSelectList_1 = _ob_prod.ApplicationType_1.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };

            if (id == null)
            {
                // this is create
                return View(productVM_1);
            }

            else
            {
                productVM_1.Product_1 = _ob_prod.Product_1.Find(id);
                if (productVM_1 == null)
                {
                    return NotFound();
                }

                return View(productVM_1);
            }

        }

        //POST - Upsert////////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ProductVM_1 prodVM_1)
        {
            if (ModelState.IsValid)
            {
                var files_1 = HttpContext.Request.Form.Files;
                string webRootPath_1 = _webHostEnvironment.WebRootPath;

                if (prodVM_1.Product_1.Id == 0)
                {
                    string upload_1 = webRootPath_1 + WC.ImagePath;
                    string fileName_1 = Guid.NewGuid().ToString();
                    string extension = Path.GetExtension(files_1[0].FileName);

                    using (var fileStream = new FileStream(Path.Combine(upload_1, fileName_1 + extension), FileMode.Create))
                    {
                        files_1[0].CopyTo(fileStream);
                    }

                    prodVM_1.Product_1.Image = fileName_1 + extension;
                    _ob_prod.Product_1.Add(prodVM_1.Product_1);
                }

                else
                {
                    var objFromDB_1 = _ob_prod.Product_1.AsNoTracking().FirstOrDefault(x => x.Id == prodVM_1.Product_1.Id);

                    if (files_1.Count > 0)
                    {
                        string upload_1 = webRootPath_1 + WC.ImagePath;
                        string fileName_1 = Guid.NewGuid().ToString();
                        string extension = Path.GetExtension(files_1[0].FileName);

                        var oldFile_1 = Path.Combine(upload_1, objFromDB_1.Image);

                        if (System.IO.File.Exists(oldFile_1))
                        {
                            System.IO.File.Delete(oldFile_1);
                        }

                        using (var fileStream = new FileStream(Path.Combine(upload_1, fileName_1 + extension), FileMode.Create))
                        {
                            files_1[0].CopyTo(fileStream);
                        }
                        prodVM_1.Product_1.Image = fileName_1 + extension;

                    }

                    else
                    {
                        prodVM_1.Product_1.Image = objFromDB_1.Image;
                    }
                    _ob_prod.Product_1.Update(prodVM_1.Product_1);
                }
                _ob_prod.SaveChanges();

                return RedirectToAction("Index");
            }

            prodVM_1.CategorySelectList_1 = _ob_prod.Category_1.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString(),
            });
            prodVM_1.ApplicationTypeSelectList_1 = _ob_prod.ApplicationType_1.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });


            return View(prodVM_1);
        }

        //GET - Delete////////////////////////////////////////////////////////////////////////////////////////////

        //public IActionResult Delete2(int id)
        //{
        //    ProductVM_1 productVM_1 = new ProductVM_1();
        //    {
        //        productVM_1.Product_1 = new Product_1();

        //        productVM_1.CategorySelectList_1 = _ob_prod.Category_1.Select(i => new SelectListItem
        //        {
        //            Text = i.Name,
        //            Value = i.Id.ToString(),
        //        });
        //        productVM_1.ApplicationTypeSelectList_1 = _ob_prod.ApplicationType_1.Select(i => new SelectListItem
        //        {
        //            Text = i.Name,
        //            Value = i.Id.ToString()
        //        });
        //    }

        //    productVM_1.Product_1 = _ob_prod.Product_1.Find(id);

        //    if (productVM_1 != null)
        //    {
        //        return View(productVM_1);
        //    }
        //    return View();
        //}



        //POST - Delete///////////////////////////////////////////////////////////////////////////////////////////
        public IActionResult Delete(int? id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            Product_1 product_1 = _ob_prod.Product_1.Include(x => x.Category_1).Include(x => x.ApplicationType_1).FirstOrDefault(x => x.Id == id);

            //Product_1 product_1 = _ob_prod.Product_1.FirstOrDefault(x => x.Id == id);
           // Product_1 product_1 = _ob_prod.Product_1.Find(id);

            //product_1.Category_1 = _ob_prod.Category_1.Find(product_1.Category_1_Id);
            if(product_1 == null)
            {
                return NotFound();
            }
            return View(product_1);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Delete1(ProductVM_1 vM_1)
        //{
        //    int id = vM_1.Product_1.Id;
        //    Product_1 ob_del_prod = _ob_prod.Product_1.Find(id);

        //    var upload_del = _webHostEnvironment.WebRootPath + WC.ImagePath;

        //    var oldDelFile = Path.Combine(upload_del, ob_del_prod.Image);

        //    if (System.IO.File.Exists(oldDelFile))
        //    {
        //        System.IO.File.Delete(oldDelFile);
        //    }

        //    _ob_prod.Remove(ob_del_prod);
        //    _ob_prod.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete1(int id)
        {
            //int id = vM_1.Product_1.Id;
            Product_1 ob_del_prod = _ob_prod.Product_1.Find(id);

            var upload_del = _webHostEnvironment.WebRootPath + WC.ImagePath;

            var oldDelFile = Path.Combine(upload_del, ob_del_prod.Image);

            if (System.IO.File.Exists(oldDelFile))
            {
                System.IO.File.Delete(oldDelFile);
            }

            _ob_prod.Remove(ob_del_prod);
            _ob_prod.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
