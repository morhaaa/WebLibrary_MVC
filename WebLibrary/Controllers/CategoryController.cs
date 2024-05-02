using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebLibrary.Data;
using WebLibrary.Models;

namespace WebLibrary.Controllers{

public class CategoryController : Controller
    {

        private readonly ApplicationDBContext _db;
        public CategoryController(ApplicationDBContext db){
            _db = db;
        }
        public IActionResult Index()    
        {
            List<Category> categoryList = _db.Categories.ToList();
            return View(categoryList); 
        }
        [HttpPost]


        // ------------ CREATE -----------
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj) {

            if(obj.Name.Length > 0) {
                ModelState.AddModelError("Name","The field is required");
            }

            if (ModelState.IsValid) {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");   
            }
            return View();
        }

        // ------------ EDIT -----------
        public IActionResult Edit(int? id)
        {
            if( id == 0 || id == null )
            {
                return NotFound();
            }
            Category? categoryFromDB = _db.Categories.Find(id); // method to take element by  Primary Key
            // Category? categoryFromDB = _db.Categories.FirstOrDefault(u=> u.Id == id); Other Method to getValue from DB
            if (categoryFromDB == null )
            {
                return NotFound();
            }

            return View(categoryFromDB);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {

            if(obj.Name.Length == 0) {
                ModelState.AddModelError("Name","The field is required");
            }

            if (ModelState.IsValid) {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");   
            }
            return View();
        }

    }
}
