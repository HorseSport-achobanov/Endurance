namespace Endurance.Web.Trial.Controllers.Api
{
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class CompetitorsController : ControllerBase
    {
        [HttpPost("/{id}/update")]
        public IActionResult Update(int id)
        {
            return new JsonResult(true);
        }
    }
}
