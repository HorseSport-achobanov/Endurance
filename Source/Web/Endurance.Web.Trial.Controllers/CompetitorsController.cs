namespace Endurance.Web.Trial.Controllers
{
    using Data.Trial.Models;
    using global::Services.Common.Contracts;
    using global::Web.Common.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using Services.Trial.Contracts.Competitor;
    using ViewModels.Competitor;

    public class CompetitorsController : BaseController
    {
        private readonly ITrialCompetitorBusinessService competitorBusiness;
        private readonly IDataService<TrialHorse> horsesData;
        private readonly IDataService<TrialRider> ridersData;
        private readonly IDataService<Trial> trialsData;
        private readonly IAutomapperService mapper;

        public CompetitorsController(
            ITrialCompetitorBusinessService competitorBusiness,
            IDataService<TrialHorse> horsesData,
            IDataService<TrialRider> ridersData,
            IDataService<Trial> trialsData,
            IAutomapperService mapper)
        {
            this.competitorBusiness = competitorBusiness;
            this.horsesData = horsesData;
            this.ridersData = ridersData;
            this.trialsData = trialsData;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = PrepareSelectOptions(new CreateTrialCompetitorViewModel());
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(CreateTrialCompetitorViewModel viewModel)
        {
            var competitor = this.mapper.Map<TrialCompetitor>(viewModel);
            var (success, field, message) = this.competitorBusiness.Create(competitor);

            if (!success)
            {
                ModelState.AddModelError(field, message);
            }

            if (!ModelState.IsValid)
            {
                return View(PrepareSelectOptions(viewModel));
            }

            return RedirectToAction("Create");
        }

        private CreateTrialCompetitorViewModel PrepareSelectOptions(CreateTrialCompetitorViewModel viewModel)
        {
            viewModel.RiderOptions = this.mapper.MapCollection<TrialRider, SelectOption>(this.ridersData.GetAll());
            viewModel.HorseOptions = this.mapper.MapCollection<TrialHorse, SelectOption>(this.horsesData.GetAll());
            viewModel.TrialOptions = this.mapper.MapCollection<Trial, SelectOption>(this.trialsData.GetAll());

            return viewModel;
        }
    }
}
