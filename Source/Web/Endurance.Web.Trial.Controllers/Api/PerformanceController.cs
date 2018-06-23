namespace Endurance.Web.Trial.Controllers.Api
{
    using Data.Trial.Models;
    using Microsoft.AspNetCore.Mvc;

    
    [Route("api/[controller]/[action]")]
    public class CompetitorsController : Controller
    {

        [HttpPost]
        public IActionResult Update(TrialRoundPerformance performance)
        {
            return new JsonResult(true);
        }
    }
}
