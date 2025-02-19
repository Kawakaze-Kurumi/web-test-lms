using Microsoft.AspNetCore.Mvc;
using web_test_lms.Models;

namespace web_test_lms.Controllers
{
    public class LoginController : Controller
    {
        Test1Context db = new Test1Context();

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = db.TblTaiKhoans.FirstOrDefault(u => u.Username == username);

            if (user != null)
            {
                if (user.Username == "admin")
                    return RedirectToAction("Index", "Admin");
                else if (user.Username == "user")
                    return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Sai tài khoản hoặc mật khẩu!";
            return View("Index");
        }

    }
}
