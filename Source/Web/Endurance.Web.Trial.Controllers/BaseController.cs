namespace Endurance.Web.Trial.Controllers
{
    using System.Security.Claims;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class BaseController : Controller
    {
        protected ClaimsPrincipal UserPrincipal;

        [TempData]
        public string StatusMessage { get; set; }

        [TempData]
        public string ErrorMessage { get;set; }
        
        public BaseController()
        {
            UserPrincipal = User;
        }

        #region Helpers

        protected void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        #endregion
    }
}
