using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using singinAndUp.Areas.Identity.Data;
using singinAndUp.Models;
using System.Diagnostics;

namespace singinAndUp.Controllers
{
    public class HomeController : Controller
    {

        private readonly UserManager<appUser> _userManager;



        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, UserManager<appUser> userManager)
        {
            _logger = logger;
            this._userManager = userManager;
        }


        public IActionResult Index()
        {

            ViewData["UserID"] = _userManager.GetUserId(this.User);


            ViewData["EMAIL"] = _userManager.GetUserName(this.User);

         


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}