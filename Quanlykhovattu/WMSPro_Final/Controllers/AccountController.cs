using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WMSPro.Models;
using WMSPro.ViewModels;

namespace WMSPro.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signIn;
        private readonly UserManager<ApplicationUser> _userMgr;

        public AccountController(SignInManager<ApplicationUser> signIn, UserManager<ApplicationUser> userMgr)
        {
            _signIn = signIn;
            _userMgr = userMgr;
        }

        // ── Đăng nhập ──
        [AllowAnonymous]
        public IActionResult Login()
        {
            if (User.Identity?.IsAuthenticated == true)
                return RedirectToAction("Index", "Home");
            return View(new LoginViewModel());
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var result = await _signIn.PasswordSignInAsync(
                model.TenDangNhap, model.MatKhau,
                isPersistent: false, lockoutOnFailure: true);

            if (result.Succeeded)
                return RedirectToAction("Index", "Home");

            if (result.IsLockedOut)
                model.ErrorMessage = "Tài khoản bị khóa tạm thời do đăng nhập sai nhiều lần. Thử lại sau 5 phút.";
            else
                model.ErrorMessage = "Tên đăng nhập hoặc mật khẩu không đúng!";

            return View(model);
        }

        // ── Đăng xuất ──
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signIn.SignOutAsync();
            return RedirectToAction("Login");
        }

        // ── Trang từ chối truy cập ──
        [AllowAnonymous]
        public IActionResult AccessDenied() => View();

        // ── Đổi mật khẩu (bản thân) ──
        [Authorize]
        public IActionResult DoiMatKhau() => View(new DoiMatKhauViewModel());

        [HttpPost, Authorize]
        public async Task<IActionResult> DoiMatKhau(DoiMatKhauViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = await _userMgr.GetUserAsync(User);
            if (user == null) return RedirectToAction("Login");

            var result = await _userMgr.ChangePasswordAsync(user, model.MatKhauCu, model.MatKhauMoi);
            if (result.Succeeded)
            {
                TempData["Success"] = "Đổi mật khẩu thành công!";
                return RedirectToAction("Index", "Home");
            }

            foreach (var err in result.Errors)
                ModelState.AddModelError("", err.Description);
            return View(model);
        }
    }
}
