using Database.Contexts;
using Database.Entities.Concretes;
using Database.Repositories.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductDB_EF.ViewModels;

namespace ProductDB_EF.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IGenericRepository<Category> _categoryRepository;

        public CategoryController(IGenericRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public IActionResult AddCategory()
        {

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryVM categoryVM)
        {
            bool exist = false;
            foreach (var item in await _categoryRepository.GetAllAsync())
            {
                if (item.Name == categoryVM.Name)
                {
                    exist = true;
                }
            }
            if (!exist)
            {
                var category = new Category() { Name=categoryVM.Name};
                await _categoryRepository.AddAsync(category);
            }
            return RedirectToAction("GetAllCategory");
        }


        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return View(categories);
        }


        [HttpGet]
        public IActionResult RemoveCategory()
        {
            return RedirectToAction("GetAllCategory");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveCategory(int productId)
        {
            await _categoryRepository.DeleteAsync(productId);
            return RedirectToAction("GetAllCategory");
        }

    }
}
