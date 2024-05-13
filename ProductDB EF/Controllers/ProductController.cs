using Database.Entities.Concretes;
using Database.Repositories.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductDB_EF.ViewModels;

namespace ProductDB_EF.Controllers
{
    public class ProductController : Controller
    {

        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<Category> _categoryRepository;

        public ProductController(IGenericRepository<Product> productRepository, IGenericRepository<Category> categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            ViewBag.Categories = _categoryRepository.GetAllAsync().Result;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductVM productVM)
        {
            
            var product=new Product() { Name = productVM.Name,ImageUrl=productVM.ImageUrl,Price=productVM.Price,CategoryId=productVM.CategoryId };
            await _productRepository.AddAsync(product);
            return RedirectToAction("GetAllProducts");
        }


        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productRepository.GetAllAsync();
            for (int i = 0; i < products.Count; i++)
            {
                foreach (var category in _categoryRepository.GetAllAsync().Result)
                {
                    if (category.Id == products[i].CategoryId)
                    {
                        products[i].Category = category;
                    }
                }
            }

            return View(products);
        }

        [HttpGet]
        public IActionResult RemoveProduct()
        {
            return RedirectToAction("GetAllProducts");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveProduct(int productId)
        {
            await _productRepository.DeleteAsync(productId);
            return RedirectToAction("GetAllProducts");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            ViewBag.Categories = _categoryRepository.GetAllAsync().Result;
            var item = await _productRepository.GetByIdAsync(id);
            return View(item);
        }

        [HttpPost]

        public async Task<IActionResult> UpdateProduct(Product product)
        {
            await Console.Out.WriteLineAsync(product.CategoryId.ToString());
            await _productRepository.Update(product);
            return RedirectToAction("GetAllProducts");
        }




    }
}
