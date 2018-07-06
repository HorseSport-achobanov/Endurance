namespace Endurance.Web.Trial.Controllers
{
    using global::Data.Common.Models;
    using global::Services.Common.Contracts;
    using global::Web.Common;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Club;

    public class ClubsController : BaseController
    {
        private readonly IDataService<BaseClub> clubsData;
        private readonly IAutomapperService mapper;

        public ClubsController(
            IDataService<BaseClub> clubsData,
            IAutomapperService mapper)
        {
            this.clubsData = clubsData;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BaseClubViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            this.clubsData.Add(this.mapper.Map<BaseClub>(viewModel));

            return RedirectToAction("Create");
        }
    }
}
