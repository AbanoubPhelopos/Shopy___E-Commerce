using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shopy.Models;
using Shopy.Models.ViewModels;
using Shopy.Utilities;

namespace Shopy.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = StaticDetails.RoleAdmin)]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;   
        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;

        }
        public IActionResult Index()
        {
            List<Product> products = _unitOfWork.Product.GetAll(includeProparties: "Category").ToList();
            return View(products);
        }
        public IActionResult Upsert(int? Id)
        {
            ProductVM productVM = new()
            {
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                product = new Product()
            };
            if (Id == 0 || Id == null)
            {
                return View(productVM);
            }
            else
            {
                productVM.product=_unitOfWork.Product.Get(p=>p.Id == Id);
                return View(productVM);
            }
            
        }
        [HttpPost]
        public IActionResult Upsert(ProductVM productVM,IFormFile? formFile)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if(formFile != null)
                {
                    string FileName=Guid.NewGuid().ToString() + Path.GetExtension(formFile.FileName);
                    string ProductPath=Path.Combine(wwwRootPath, @"Images\Products");

                    if (!string.IsNullOrEmpty(productVM.product.ImageURL))
                    {
                        var oldPath = Path.Combine(wwwRootPath, productVM.product.ImageURL.Trim('\\'));

                        if (System.IO.File.Exists(oldPath))
                        {
                            System.IO.File.Delete(oldPath);
                        }
                    }

                    using ( var fileStream = new FileStream(Path.Combine(ProductPath, FileName),FileMode.Create))
                    {
                        formFile.CopyTo(fileStream);
                    }

                    productVM.product.ImageURL = @"\Images\Products\" + FileName;
                }
                if (productVM.product.Id == 0)
                {
                    _unitOfWork.Product.Add(productVM.product);
                }
                else
                {
                    _unitOfWork.Product.Update(productVM.product);
                }
                
                _unitOfWork.Save();
                TempData["success"] = "The product was created successfully";
                return RedirectToAction("index");
            }
            else
            {
                productVM.CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
                return View(productVM);
            }
            
        }
        
        #region API CALLs
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Product> products = _unitOfWork.Product.GetAll(includeProparties: "Category").ToList();
            return Json(new { data = products });
        }
        [HttpDelete]
        public IActionResult Delete(int? Id)
        {
            var productToBeDeleted=_unitOfWork.Product.Get(p=>p.Id == Id);
            if(productToBeDeleted == null)
            {
                return Json(new {success = false , message="Error while deleting"});
            }
            var oldImagePath= Path.Combine(_webHostEnvironment.WebRootPath, productToBeDeleted.ImageURL.Trim('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
            _unitOfWork.Product.Remove(productToBeDeleted); _unitOfWork.Save();
            return Json(new { success = true, message = "Deleted successfuly" });
        }
        #endregion 
    }
}


