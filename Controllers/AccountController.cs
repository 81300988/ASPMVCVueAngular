
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace vue_blog.Controllers
{
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private SignInManager<IdentityUser> _signInManager;
        public AccountController(SignInManager<IdentityUser> SignInManager)
        {
            _signInManager = SignInManager;
        }
        [HttpGet]
        public IActionResult Login() => View();
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, false, false);
            if(result.Succeeded){
                return RedirectToAction("Index", "BlogAdmin");
            }
            return RedirectToAction("Login", "Account");

        }
    }
}