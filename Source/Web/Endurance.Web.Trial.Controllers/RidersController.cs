namespace Endurance.Web.Trial.Controllers
{
    using Data.Trial.Models;
    using global::Data.Common.Models;
    using global::Services.Common.Contracts;
    using global::Web.Common.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels;

    public class RidersController : BaseController
    {
        private readonly IDataService<BaseClub> clubsData;
        private readonly IDataService<TrialRider> ridersData;
        private readonly IAutomapperService mapper;

        public RidersController(
            IDataService<TrialRider> ridersData,
            IDataService<BaseClub> clubsData,
            IAutomapperService mapper)
        {
            this.ridersData = ridersData;
            this.clubsData = clubsData;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = PrepareClubs(new TrialRiderViewModel());
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(TrialRiderViewModel viewModel)
        {
            var club = this.clubsData.GetById(viewModel.ClubId);
            if (club == null)
            {
                ModelState.AddModelError(nameof(TrialRiderViewModel.ClubId), "Club does not exist");
            }

            if (!ModelState.IsValid)
            {
                return View(PrepareClubs(viewModel));
            }

            this.ridersData.Add(this.mapper.Map<TrialRider>(viewModel));

            return RedirectToAction("Create");
        }

        private TrialRiderViewModel PrepareClubs(TrialRiderViewModel viewModel)
        {
            viewModel.ClubOptions = this.mapper.MapCollection<BaseClub, SelectOption>(this.clubsData.GetAll());

            return viewModel;
        }
    }
}
