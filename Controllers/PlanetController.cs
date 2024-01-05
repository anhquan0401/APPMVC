using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [Route("He-mat-troi")]
    public class PlanetController : Controller
    {
        // GET: PlanetController
        private readonly PlanetService _planetSevice; // inject

        private readonly ILogger<PlanetController> _logger;

        public PlanetController(PlanetService planetSevice, ILogger<PlanetController> logger)
        {
            _planetSevice = planetSevice;
            _logger = logger;
        }

        [Route("/Danh-sach-cac-hanh-tinh.html")]

        public IActionResult Index() // /Danh-sach-cac-hanh-tinh.html
        {
            return View();
        }


        [BindProperty(SupportsGet = true, Name = "action")] 
        public string Name {set; get;} // Action = Name
        public IActionResult Mercury() {
            var planet = _planetSevice.Where(p => p.Name == Name).FirstOrDefault();
            return View("Details", planet);
        } 

        public IActionResult Venus() {
            var planet = _planetSevice.Where(p => p.Name == Name).FirstOrDefault();
            return View("Details", planet);
        } 

        public IActionResult Earth() {
            var planet = _planetSevice.Where(p => p.Name == Name).FirstOrDefault();
            return View("Details", planet);
        } 

        public IActionResult Mars() {
        var planet = _planetSevice.Where(p => p.Name == Name).FirstOrDefault();
            return View("Details", planet);
        } 

        public IActionResult Jupiter() {
        var planet = _planetSevice.Where(p => p.Name == Name).FirstOrDefault();
            return View("Details", planet);
        } 

        public IActionResult Saturn() {
        var planet = _planetSevice.Where(p => p.Name == Name).FirstOrDefault();
            return View("Details", planet);
        } 

        public IActionResult Uranus() {
        var planet = _planetSevice.Where(p => p.Name == Name).FirstOrDefault();
            return View("Details", planet);
        } 

        [Route("sao/[controller]/[action]", Order = 1, Name = "Neptune1")]  // sao/Planet/Neptune
        [Route("[controller]/[action].html", Order = 2, Name = "Neptune2")] // Planet/Neptune.html
        public IActionResult Neptune() {
            var planet = _planetSevice.Where(p => p.Name == Name).FirstOrDefault();
            return View("Details", planet);
        } 


        [Route("hanh-tinh/{Id?}")]
        public IActionResult PlanetInfor(int Id) {
            var planet = _planetSevice.Where(p => p.Id == Id).FirstOrDefault();
            return View("Details", planet);
        }

    }
}
