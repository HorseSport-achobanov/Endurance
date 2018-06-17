namespace Endurance.Web.Trial.Controllers
{
    using AutoMapper;
    using global::Services.Common.Contracts;
    using Microsoft.AspNetCore.Mvc;
    using Services.Trial.Contracts.Trial;
    using ViewModels.Trial;

    public class TrialsController : BaseController
    {
        private readonly ITrialsDataService trialsData;
        private readonly IAutomapperService mapper;

        public TrialsController(
            ITrialsDataService trialsData,
            IAutomapperService mapper
        ) {
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

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Manage(int trialId)
        {
            var trial = this.trialsData.GetById(trialId);
            if (trial == null)
            {
                ViewData["Error"] = "No such Trial";
                return RedirectToAction("Index", "Home");
            }

            var viewModel = this.mapper.Map<ManageTrialViewModel>(trial);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Manager(ManageTrialViewModel model)
        {
            return new EmptyResult();
        }
    }
}
