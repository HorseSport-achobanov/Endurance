namespace Endurance.Web.Trial.Controllers
{
    using Data.Trial.Models;
    using Microsoft.AspNetCore.Mvc;

    using global::Services.Common.Contracts;
    using Services.Trial.Contracts.Trial;
    using ViewModels.Trial;

    public class TrialsController : BaseController
    {
        private readonly ITrialsBusinessService trialsBusiness;
        private readonly ITrialsDataService trialsData;
        private readonly IAutomapperService mapper;

        public TrialsController(
            ITrialsBusinessService trialsBusiness,
            ITrialsDataService trialsData,
            IAutomapperService mapper
        ) {
            this.trialsBusiness = trialsBusiness;
            this.trialsData = trialsData;
            this.mapper = mapper;
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

            var trial = this.trialsData.Add(this.mapper.Map<Trial>(viewModel));

            return RedirectToAction("Manage", new { id = trial.Id });
        }

        [HttpPost]
        public IActionResult Activate(int id)
        {
            var success = this.trialsBusiness.Activate(id);
            if (!success)
            {
                return RedirectToAction("Dashboard", "Home");
            }

            return RedirectToAction("Manage", new { id });
        }

        [HttpGet]
        public IActionResult Manage(int id)
        {
            var trial = this.trialsData.GetTrialToManage(id);
            if (trial == null)
            {
                ViewData["Error"] = "No such Trial";
                return RedirectToAction("Dashboard", "Home");
            }

            var viewModel = this.mapper.Map<ManageTrialViewModel>(trial);

            return View(viewModel);
        }
    }
}
