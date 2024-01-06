using System.Configuration;
using App.ExtendMethods;
using App.Models;
using App.Services;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Nó thêm các dịch vụ cần thiết để hỗ trợ Razor Pages như quản lý route, tạo view, 
// xử lý request, và nhiều chức năng khác liên quan đến Razor Pages.
builder.Services.AddRazorPages();

// nó sẽ tìm tất cả các views kể cả thêm cấu trúc riêng như MyView
builder.Services.Configure<RazorViewEngineOptions>(option => {
    // /View/Controller/Action.cshtml
    // /MyView/Controller/Action.cshtml

    // {0} ten actions
    // {1} ten controller
    // {2} ten areas
    // RazorViewEngine.ViewExtension vd như .cshtml
    option.ViewLocationFormats.Add("/MyView/{1}/{0}" + RazorViewEngine.ViewExtension);
});

// 
// builder.Services.AddSingleton<ProductService>();  //khi sd chỉ lấy ra 1 đối tượng dịch vụ
// builder.Services.AddSingleton<ProductService, ProductService>(); 
// builder.Services.AddSingleton(typeof(ProductService));  
builder.Services.AddSingleton(typeof(ProductService), typeof(ProductService));  
builder.Services.AddSingleton(typeof(PlanetService), typeof(PlanetService));
// builder.Services.AddTransient(); mỗi truy vấn lấy ra dịch vụ thì 1 đối tượng mới được tạo ra, Nếu dịch vụ của bạn không giữ trạng thái, và mỗi yêu cầu yêu cầu một instance mới,
// AddTransient là lựa chọn phù hợp

// builder.Services.AddScoped(); mỗi phiên lấy dịch vụ sẽ tạo ra 1 đối tượng mới đc tạo ra, nếu bạn muốn chia sẻ cùng một instance giữa các thành phần trong cùng một yêu cầu, 
// bạn nên sử dụng AddScoped.


// Add configuration services to the container.
builder.Configuration.AddJsonFile("appsettings.json");

// Add services to the container.
builder.Services.AddControllersWithViews();

// ... Other service registrations
builder.Services.AddDbContext<AppDbContext>(options => {
    var connectionString = builder.Configuration.GetConnectionString("AppMvcConnectionString");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();


app.AddStatusCodePage(); // code 400 - 599

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages(); // dùng cái này để có thể file razor pages


// 1. Tạo Route, ánh xạ Url
// app.MapControllers();
// URL = xemsanpham/Home/Index
// xemsanpham/First/Hello
// app.MapControllerRoute(
//     name: "default",
//     pattern: "xemsanpham/{controller=Home}/{action=Index}/{id?}"
// );


// https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.routing.irouteconstraint?view=aspnetcore-8.0
// IRouteConstraint

// https://learn.microsoft.com/en-us/aspnet/core/fundamentals/routing?view=aspnetcore-8.0#route-constraint-reference
// app.MapControllerRoute(
//     name: "default",
//     pattern: "{url:regex(^((xemsanpham)|(viewproduct))$)}/{id:range(2, 4)}", // xemsanpham/1
//     defaults: new {
//         controller = "First",
//         action = "ViewProduct"
//     }, 
//     constraints: new {
//         // url = new RegexRouteConstraint(@"^((xemsanpham)|(viewproduct))$"), // RegexRouteConstraint theo quy tắc của regex
//         // url = new StringRouteConstraint("xemsanpham"), // StringRouteConstraint đã thêm ràng buộc: phải tên xemsanpham/{id?} mới truy cập đc
//         // id = new RangeRouteConstraint(2, 4) // RangeRouteConstraint chỉ cho phép id từ 2 đến 4
//     }
// );
app.MapAreaControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}",
    areaName: "ProductManage"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// app.MapDefaultControllerRoute();
// app.MapAreaControllerRoute();

// Attribute:
// [AcceptVerbs]
// [HttpGet]
// [HttpPost]
// [HttpPut]
// [HttpDelete]
// [HttpHead]
// [HttpPatch]


app.Run();
