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

## github
1. dotnet new gitignore
2. git init
3. git add .
4. git commit -m"Creat App MVC"
5. git status
6. git branch B1
7. git branch
8. git remote add origin https://github.com/anhquan0401/APPMVC.git lấy chỗ khi tạo tên trên github
9. git push --all

## clone 
1. git clone https://github.com/Gunnar50/SliddingPuzzlePygame2.0.git
2. cd cloning into '...'/
3. code ./

## 
- b1: dotnet tool install -g dotnet-aspnet-codegenerator
- dotnet tool update -g dotnet-aspnet-codegenerator
--> lệnh này sẽ giúp tạo file controller nhanh hơn

- b2: dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design

- b3: dotnet aspnet-codegenerator -h  để xem hướng dẫn

- b4: dotnet aspnet-codegenerator controller -name PlanetController -namespace App.Controllers -outDir Controllers
- b4: dotnet aspnet-codegenerator controller -name ProductController -namespace App.Controllers -outDir Controllers

- dotnet aspnet-codegenerator area ProductManage




## Areas
- là tên dùng để routing
- là cấu trúc thư mục chưa M.V.C
- Thiết lập Area cho controller bằng '[Area("AreaName")]'
- Tạo cấu trúc thư mục


## Route
app.MapController
app.MapControllerRoute()
app.MapDefaultControllerRoute();
app.MapAreaControllerRoute();

Attribute:
[AcceptVerbs]
[HttpGet]
[HttpPost]
[HttpPut]
[HttpDelete]
[HttpHead]
[HttpPatch]

## URL generator
## UrlHelper: Action, Actionlink, RouterUrl, Link
## HtmlTagHelper <a> <button> <Form>
sử dụng thuộc tính:
asp-action=""
asp-area=""
asp-controller=""
asp-route-id...=""
asp-route="

