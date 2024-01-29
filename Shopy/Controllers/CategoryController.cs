using Microsoft.EntityFrameworkCore;
using Shopy.Models;

namespace Shopy.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDBContext _dbContext;
        public CategoryController(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public IActionResult Index()
        {
            List<Category> category = _dbContext.categories.ToList();
            return View(category);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            for (int i = 0; i < category.Name.Length; i++)
            {
                if (category.Name[i] >= '0' && category.Name[i] <= '9')
                {
                    ModelState.AddModelError("", "Name mustnt contian digits");
                    break;
                }
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            _dbContext.categories.Add(category);
            _dbContext.SaveChanges();
            TempData["success"] = "The employee was created successfully";
            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            Category? category = _dbContext.categories.FirstOrDefault(c=>c.Id== id);
            if(category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            for (int i = 0; i < category.Name.Length; i++)
            {
                if (category.Name[i] >= '0' && category.Name[i] <= '9')
                {
                    ModelState.AddModelError("", "Name mustnt contian digits");
                    break;
                }
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            _dbContext.categories.Update(category);
            _dbContext.SaveChanges();
            TempData["success"] = "The employee was updated successfully";
            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            Category? category = _dbContext.categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            Category? category = _dbContext.categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _dbContext.categories.Remove(category);
            _dbContext.SaveChanges();
            TempData["success"] = "The employee was deleted successfully";
            return RedirectToAction("index");
        }
    }
}
