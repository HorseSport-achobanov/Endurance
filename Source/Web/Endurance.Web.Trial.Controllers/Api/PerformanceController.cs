namespace Endurance.Web.Trial.Controllers.Api
{
    using System;
    using Data.Trial.Models;
    using global::Services.Common.Contracts;
    using global::Web.Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Trial.Contracts.Performance;
    
    [Authorize]
    [Route("api/[controller]/{id}/[action]")]
    public class PerformancesController : Controller
    {
        private readonly IDataService<TrialRoundPerformance> performacesData;
        private readonly IPerformanceBusinessService performancesBusiness;

        public PerformancesController(
            IDataService<TrialRoundPerformance> performacesData,
            IPerformanceBusinessService performancesBusiness)
        {
            this.performacesData = performacesData;
            this.performancesBusiness = performancesBusiness;
        }

        [HttpPost]
        public AjaxResult Finished(int id, string value)
        {
            var performance = this.performacesData.GetById(id);
            if (performance == null)
            {
                return new AjaxResult(false, "No such performance");
            }

            var vetGateEntryDeatlineTime = performancesBusiness.Finish(performance, value);

            return new AjaxResult(data: vetGateEntryDeatlineTime);
        }
    }
}
