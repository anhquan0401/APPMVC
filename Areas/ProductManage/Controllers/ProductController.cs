using App.Models;
using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [Area("ProductManage")]
    public class ProductController : Controller
    {
        // GET: ProductController
        private readonly ProductService _productService;

        private readonly ILogger<ProductController> _logger;

        public ProductController(ProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            // var product = _productService.OrderBy(p => p.Name).ToList();
            return View();
        }


        [Route("Cac-San-Pham/{Id?}")]
        public IActionResult ProductInfor(int Id) {
            // Areas/AreasName/Views/Controller/Action/Id
            var product = _productService.Where(p => p.Id == Id).FirstOrDefault();
            return View("Details", product); // Areas/ProductManage/Views/Product/ProductInfor/Id
        }
    }
}
