namespace Endurance.Web.Trial.Controllers
{
    using System.Linq;
    using Data.Trial.Models;
    using Microsoft.AspNetCore.Mvc;

    using global::Services.Common.Contracts;
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

            var trial = this.trialsData.Create(this.mapper.Map<Trial>(viewModel));

            return RedirectToAction("Manage", new { id = trial.Id });
        }

        [HttpGet]
        public IActionResult List()
        {
            var viewModel = mapper
                .MapQueryable<TrialShortViewModel>(this.trialsData.GetQueryableAll())
                .ToList();

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Manage(int id)
        {
            var trial = this.trialsData.GetById(id);
            if (trial == null)
            {
                ViewData["Error"] = "No such Trial";
                return RedirectToAction("Index", "Home");
            }

            var viewModel = this.mapper.Map<ManageTrialViewModel>(trial);

            return View(viewModel);
        }
    }
}
