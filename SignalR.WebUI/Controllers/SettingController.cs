using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.Entity.Entities;
using SignalR.WebUI.Dtos.IdentityDtos;

namespace SignalR.WebUI.Controllers
{
    public class SettingController(UserManager<AppUser> _userManager) : Controller
    {

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userEditDto = new UserEditDto()
            {
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                UserName = user.UserName
            };
            return View(userEditDto);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditDto userEditDto)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                var passwordCheck = await _userManager.CheckPasswordAsync(user, userEditDto.OldPassword);
                if (passwordCheck == false)
                {
                    ModelState.AddModelError("", "Şu Anki Şifrenizi Yanlış Girdiniz!");
                    return View();

                }
                user.Name = userEditDto.Name;
                user.Surname = userEditDto.Surname;
                user.Email = userEditDto.Email;
                user.UserName = userEditDto.UserName;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userEditDto.Password);

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    TempData["userEditInfo"] = "Bilgileriniz Güncellendi Lütfen Tekrar Giriş Yapın";
                    return RedirectToAction("Logout", "Login");
                }

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                    return View(item);
                }
            }


            return View();
        }
    }
}
