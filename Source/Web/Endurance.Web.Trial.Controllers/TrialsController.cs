namespace Endurance.Web.Trial.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Trial;

    public class TrialsController : BaseController
    {
        public TrialsController()
        {

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateTrialViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
