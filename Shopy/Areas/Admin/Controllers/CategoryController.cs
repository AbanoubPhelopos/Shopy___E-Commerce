﻿using Microsoft.AspNetCore.Authorization;
using Shopy.Models;
using Shopy.Utilities;

namespace Shopy.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = StaticDetails.RoleAdmin)]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork dBContext)
        {
            _unitOfWork = dBContext;
        }
        public IActionResult Index()
        {
            List<Category> category = _unitOfWork.Category.GetAll().ToList();
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
            _unitOfWork.Category.Add(category);
            _unitOfWork.Save();
            TempData["success"] = "The employee was created successfully";
            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            Category? category = _unitOfWork.Category.Get(c => c.Id == id);
            if (category == null)
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
            _unitOfWork.Category.Update(category);
            _unitOfWork.Save();
            TempData["success"] = "The employee was updated successfully";
            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            Category? category = _unitOfWork.Category.Get(c => c.Id == id); //FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            Category? category = _unitOfWork.Category.Get(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(category);
            _unitOfWork.Save();
            TempData["success"] = "The employee was deleted successfully";
            return RedirectToAction("index");
        }
    }
}
