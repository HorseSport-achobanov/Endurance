namespace Endurance.Web.Trial.Controllers
{
    using System.Text.Encodings.Web;
    using System.Threading.Tasks;
    using global::Services.Common.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    using Services.Trial.Contracts.Account;
    using ViewModels.Manage;

    [Authorize]
    [Route("[controller]/[action]")]
    public class ManageController : BaseController
    {
        private readonly IUserBusinessService userBusiness;

        public ManageController(
            IUserBusinessService userBusiness,
            ILogger<ManageController> logger,
            UrlEncoder urlEncoder
        ) {
            this.userBusiness = userBusiness;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await userBusiness.GetUserAsync(User);
            var model = new IndexViewModel
            {
                Username = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                IsEmailConfirmed = user.EmailConfirmed,
                StatusMessage = StatusMessage
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(IndexViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await userBusiness.UpdateProfileInfo(User, model.Email, model.PhoneNumber);

            StatusMessage = "Your profile has been updated";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> ChangePassword()
        {
            var hasPassword = await userBusiness.DoesUserHavePassword(User);
            if (!hasPassword)
                return RedirectToAction(nameof(SetPassword));

            var model = new ChangePasswordViewModel { StatusMessage = StatusMessage };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var changePasswordResult = await userBusiness.ChangePasswordAsync(User, model.OldPassword, model.NewPassword);
            if (!changePasswordResult.Succeeded)
            {
                AddErrors(changePasswordResult);
                return View(model);
            }

            StatusMessage = "Your password has been changed.";
            return RedirectToAction(nameof(ChangePassword));
        }

        [HttpGet]
        public async Task<IActionResult> SetPassword()
        {
            var hasPassword = await userBusiness.DoesUserHavePassword(User);
            if (hasPassword)
                return RedirectToAction(nameof(ChangePassword));

            var model = new SetPasswordViewModel { StatusMessage = StatusMessage };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SetPassword(SetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var addPasswordResult = await userBusiness.SetPasswordAsync(User, model.NewPassword);
            if (!addPasswordResult.Succeeded)
            {
                AddErrors(addPasswordResult);
                return View(model);
            }

            StatusMessage = "Your password has been set.";
            
            return RedirectToAction(nameof(SetPassword));
        }
    }
}
