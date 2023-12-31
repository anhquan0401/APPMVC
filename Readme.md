## Controller
- Là một lớp kế thừa lớp Controller : Microsoft.AspNetCore.Mvc.Controller
- Action trong Controller là một phương thức public (Không được static)
- Action trả về bất kì kiểu dữ liệu nào, thường là IActionResult
- Các dịch vụ inject vào controller qua hàm tạo

## View 
- Là file .cshtml
- View cho Action lưu tại: /View/ControllerName/ActionName.cshtml
- Thêm thư mục lưu trữ view 

````
// {0} ten actions
// {1} ten controller
// {2} ten areas
// RazorViewEngine.ViewExtension vd như .cshtml
````
## truyền dữ liệu sang View
- Model
- ViewBag
- ViewData
- TemData