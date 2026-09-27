using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Career_Growth_App_2._0.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IWebHostEnvironment _env;

        public ProfileController(IWebHostEnvironment env)
        {
            _env = env;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadAvatar(IFormFile avatar)
        {
            if (avatar == null || avatar.Length == 0)
            {
                ModelState.AddModelError("avatar", "Please select an image file.");
                return View("Index");
            }

            var username = User.Identity.Name ?? "anonymous";
            var uploads = Path.Combine(_env.WebRootPath, "uploads");
            if (!Directory.Exists(uploads)) Directory.CreateDirectory(uploads);

            var ext = Path.GetExtension(avatar.FileName);
            var fileName = username + ext;
            var filePath = Path.Combine(uploads, fileName);

            using (var fs = new FileStream(filePath, FileMode.Create))
            {
                await avatar.CopyToAsync(fs);
            }

            TempData["Message"] = "Avatar uploaded.";
            return RedirectToAction("Index");
        }
    }
}
