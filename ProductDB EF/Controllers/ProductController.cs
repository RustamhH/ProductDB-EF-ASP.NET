using Database.Entities.Concretes;
using Database.Repositories.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace ProductDB_EF.Controllers
{
    public class ProductController : Controller
    {

        private readonly IGenericRepository<Product> _productRepository;

        public ProductController(IGenericRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            await _productRepository.AddAsync(product);
            return View(product);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var categories = await _productRepository.GetAllAsync();
            return View(categories);
        }


        public IActionResult Index()
        {
            return View();
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

    }
}
