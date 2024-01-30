using Shopy.Models;

namespace Shopy.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork dBContext)
        {
            _unitOfWork = dBContext;
        }
        public IActionResult Index()
        {
            List<Product> products = _unitOfWork.Product.GetAll().ToList();
            return View(products);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _unitOfWork.Product.Add(product);
            _unitOfWork.Save();
            TempData["success"] = "The product was created successfully";
            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            Product product = _unitOfWork.Product.Get(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            _unitOfWork.Product.Update(product);
            _unitOfWork.Save();
            TempData["success"] = "The product was updated successfully";
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Product? product = _unitOfWork.Product.Get(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            Product? product = _unitOfWork.Product.Get(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            _unitOfWork.Product.Remove(product);
            _unitOfWork.Save();
            TempData["success"] = "The product was deleted successfully";
            return RedirectToAction("index");
        }
    }
}
