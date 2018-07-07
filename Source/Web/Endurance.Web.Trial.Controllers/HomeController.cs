namespace Endurance.Web.Trial.Controllers
{
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using global::Services.Common.Contracts;
    using Services.Trial.Contracts.Trial;
    using ViewModels.Trial;

    [Route("/")]
    public class HomeController : BaseController
    {
        private readonly IAutomapperService mapper;
        private readonly ITrialsDataService trialsData;

        public HomeController(
            IAutomapperService mapper,
            ITrialsDataService trialsData)
        {
            this.mapper = mapper;
            this.trialsData = trialsData;
        }

        [Route("/")]
        public IActionResult Dashboard()
        {   
            var viewModel = mapper
                .MapQueryable<TrialShortViewModel>(this.trialsData.GetAllQueryable())
                .ToList();

            return View(viewModel);
        }

//        public IActionResult Error()
//        {
//            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//        }
    }
}
