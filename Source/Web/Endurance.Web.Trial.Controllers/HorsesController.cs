namespace Endurance.Web.Trial.Controllers
{
    using Data.Trial.Models;
    using global::Data.Common.Models;
    using global::Services.Common.Contracts;
    using global::Web.Common.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Horse;

    public class HorsesController : BaseController
    {
        private readonly IDataService<TrialHorse> horsesData;
        private readonly IDataService<BaseClub> clubsData;
        private readonly IAutomapperService mapper;

        public HorsesController(
            IDataService<TrialHorse> horsesData,
            IDataService<BaseClub> clubsData,
            IAutomapperService mapper)
        {
            this.horsesData = horsesData;
            this.clubsData = clubsData;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = PrepareClubs(new TrialHorseViewModel());
            return View(viewModel);
        }

        public IActionResult Create(TrialHorseViewModel viewModel)
        {
            var club = this.clubsData.GetById(viewModel.ClubId);
            if (club == null)
            {
                ModelState.AddModelError(nameof(TrialHorseViewModel.ClubId), "Club does not exist");
            }

            if (!ModelState.IsValid)
            {
                return View(PrepareClubs(viewModel));
            }

            this.horsesData.Add(this.mapper.Map<TrialHorse>(viewModel));

            return RedirectToAction("Create");
        }

        private TrialHorseViewModel PrepareClubs(TrialHorseViewModel viewModel)
        {
            viewModel.ClubOptions = this.mapper.MapCollection<BaseClub, SelectOption>(this.clubsData.GetAll());

            return viewModel;
        }
    }
}
