using App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Areas.Database.Controllers
{
    [Area("Database")]
    [Route("/database-manage/[action]")]
    public class DbManageController : Controller
    {
        // GET: DbManage
        private readonly AppDbContext _dbContext;

        public DbManageController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult DeleteDb() {
            return View();
        }


        [TempData]

        public string StatusMessage {set; get;}
        [HttpPost]
        public async Task<IActionResult> DeleteDbAsync() {
            var success = await _dbContext.Database.EnsureCreatedAsync();
            StatusMessage = success ? "Xóa DB thành công" : "Không xóa được";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Migrate() {
            await _dbContext.Database.MigrateAsync();
            StatusMessage = "Đã cập nhật DB thành công";
            return RedirectToAction(nameof(Index));
        }

    }
}
