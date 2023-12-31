using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers {
    public class FirstController : Controller {
        public readonly ILogger<FirstController> _logger;
        public readonly ProductService _productService;


        public FirstController(ILogger<FirstController> logger, ProductService productService){
            _logger = logger;
            _productService = productService;
        }   
        public string Index() { 
            // this.HttpContext
            // this.Request
            // this.Response
            // this.RouteData

            // this.User
            // this.ModelState
            // this.ViewData
            // this.ViewBag
            // this.Url
            // this.TempData
            return "Toi la index first";
        }

    //     Kiểu trả về                 | Phương thức
    // ------------------------------------------------
    //     ContentResult               | Content()
    //     EmptyResult                 | new EmptyResult()
    //     FileResult                  | File()
    //     ForbidResult                | Forbid()
    //     JsonResult                  | Json()
    //     LocalRedirectResult         | LocalRedirect()
    //     RedirectResult              | Redirect()
    //     RedirectToActionResult      | RedirectToAction()
    //     RedirectToPageResult        | RedirectToRoute()
    //     RedirectToRouteResult       | RedirectToPage()
    //     PartialViewResult           | PartialView()
    //     ViewComponentResult         | ViewComponent()
    //     StatusCodeResult            | StatusCode()
    //     ViewResult                  | View()

        public IActionResult Img() {
            string fileBath = Path.Combine("Files", "IMG_6797.JPG");
            var bytes = System.IO.File.ReadAllBytes(fileBath);
            return File(bytes, "image/jpg");
        }

        public IActionResult IphonePrice() {
            return Json(new {
                productName = "IPX",
                price = "1000"
            });
        }

        public IActionResult Privacy() {
            var url = Url.Action("Privacy", "Home");
            return LocalRedirect(url);
        }

        public IActionResult Google() {
            var url = "https://www.google.com";
            return Redirect(url);
        }

        public IActionResult Hello(string username) {
            if(string.IsNullOrEmpty(username)){
                username = "Khach";
            }
            // View(template) - template la duong dan tuyet doi
            // view(template, model)

            // return View("/MyView/xinchao1.cshtml", username);

            // xinchao2.cshtml -> Views/First/xinchao2.cshtml
            // return View("xinchao2", username);

            // Hello.cshtml -> Views/First/Hello.cshtml
            // return View((object)username); vì sao phải để thêm (object) để nó biết đó là model chứ ko phải template


            return View("xinchao3", username);

            // return View()
            // return view(model)

        }

        [TempData]

        public string StatusMessage {set; get;}

        public IActionResult ViewProduct(int? id){
            var product = _productService.Where(p => p.Id == id).FirstOrDefault();
            if(product == null){
                // TempData["StatusMessage"] = "Khong Tim Thay San Pham";
                StatusMessage = "Khong Tim Thay San Pham";
                return Redirect(Url.Action("Index", "Home"));
            }
            // View/First/ViewProduct.cshtml
            // MyView/First/ViewProduct.cshtml

            // model
            // return View(product);


            // ViewData
            this.ViewData["product"] = product;
            ViewData["Title"] = product.Name;
            return View("ViewProduct2");

            // ViewBag: dynamic
            // ViewBag.product = product;
            // return View("ViewProduct3");

        }
    }
}