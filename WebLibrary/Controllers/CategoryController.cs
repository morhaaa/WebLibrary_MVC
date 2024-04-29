using Microsoft.AspNetCore.Mvc;
using WebLibrary.Data;
using WebLibrary.Models;

namespace WebLibrary.Controllers{

public class CategoryController : Controller
    {

        private readonly ApplicationDBContext _db;
        public CategoryController(ApplicationDBContext db){
            _db = db;
        }
        public IActionResult Index()    {
            List<Category> categoryList = _db.Categories.ToList();
            return View(categoryList); 
        }
    }
}
