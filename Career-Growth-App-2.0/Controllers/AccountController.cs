using Career_Growth_App_2._0.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace Career_Growth_App_2._0.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            if(User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login","Account");
        }
        [HttpPost]
        public async Task<IActionResult> Login(AuthRequest authRequest)
        {
            if(authRequest.UserName=="admin" && authRequest.Password=="1234")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, authRequest.UserName),
                    new Claim(ClaimTypes.Role, "Admin")
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                // 2. Issue the authentication cookie
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(claimsIdentity));

                // 3. Redirect to home or dashboard
                return RedirectToAction("Index", "Dashboard");
            }
            return View();
        }
    }
}
