using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
    
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken] //what is validate AntiForgryToken
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.Age.ToString())//add custom server side validation
            {
                ModelState.AddModelError("name", "the DisplayOrder Cannot match the Name ");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index"); //you could put a name of controller in second paramter
            }
           return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) 
                return NotFound();
            
            var categoryFromDb = _db.Categories.Find(id);
            //var categoryFromDb = _db.Categories.FirstOrDefault(c => c.Id == id);
            //var categoryFromDb = _db.Categories.SingleOrDefault(c => c.Id == id);
            return View(categoryFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken] //what is validate AntiForgryToken
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.Age.ToString())//add custom server side validation
            {
                ModelState.AddModelError("name", "the DisplayOrder Cannot match the Name ");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index"); //you could put a name of controller in second paramter
            }
            return View(obj);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            var categoryFromDb = _db.Categories.Find(id);
            return View(categoryFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken] //what is validate AntiForgryToken
        public IActionResult Delete(Category obj)
        {
                _db.Categories.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index"); //you could put a name of controller in second paramter
        }
    }
}
