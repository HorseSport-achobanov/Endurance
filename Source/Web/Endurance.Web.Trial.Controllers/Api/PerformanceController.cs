namespace Endurance.Web.Trial.Controllers.Api
{
    using Data.Trial.Models;
    using Microsoft.AspNetCore.Mvc;

    
    [Route("api/[controller]/{id}/[action]")]
    public class PerformancesController : Controller
    {
        public PerformancesController()
        {
            
        }

        [HttpPost]
        public IActionResult Finished(int id)
        {
            return new JsonResult(true);
        }
    }
}
