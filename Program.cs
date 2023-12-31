using App.Services;
using Microsoft.AspNetCore.Mvc.Razor;

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


// builder.Services.AddTransient(); mỗi truy vấn lấy ra dịch vụ thì 1 đối tượng mới được tạo ra, Nếu dịch vụ của bạn không giữ trạng thái, và mỗi yêu cầu yêu cầu một instance mới,
// AddTransient là lựa chọn phù hợp

// builder.Services.AddScoped(); mỗi phiên lấy dịch vụ sẽ tạo ra 1 đối tượng mới đc tạo ra, nếu bạn muốn chia sẻ cùng một instance giữa các thành phần trong cùng một yêu cầu, 
// bạn nên sử dụng AddScoped.



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

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
