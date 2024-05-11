using Database.Entities.Concretes;
using Database.Repositories.Abstracts;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> AddCategory(Category category)
        {
            bool exist = false;
            foreach (var item in await _categoryRepository.GetAllAsync())
            {
                if (item.Name == category.Name)
                {
                    exist = true;
                }
            }
            if (!exist)
            {
                await _categoryRepository.AddAsync(category);
            }
            return View();
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
