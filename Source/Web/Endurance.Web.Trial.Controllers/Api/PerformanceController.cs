namespace Endurance.Web.Trial.Controllers.Api
{
    using System;
    using Data.Trial.Models;
    using global::Services.Common.Contracts;
    using global::Web.Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using RequestModels;
    using Services.Trial.Contracts.Performance;
    
    [Authorize]
    [Route("/api/[controller]/[action]")]
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
        public AjaxResult Finished([FromBody] PerformanceFinishedRequestModel request)
        {
            var performance = this.performacesData.GetById(request.Id);
            if (performance == null)
            {
                return new AjaxResult(false, "No such performance");
            }

            var vetGateEntryDeatlineTimeString = performancesBusiness.Finish(performance, request.FinishedAtString);

            return new AjaxResult(data: vetGateEntryDeatlineTimeString);
        }

        [HttpPost]
        public AjaxResult VetGateAttempted([FromBody] VetGateAttemptedRequestModel request)
        {
            var performance = this.performacesData.GetById(request.Id);
            if (performance == null)
            {
                return new AjaxResult(false, "No such performance");
            }

            var (disqualified, nextPerformanceStartsAt) = performancesBusiness.VetGateAttempt(performance, request.VetGateStatus);

            if (disqualified)
            {
                return new AjaxResult(message: "Disqualified", data: new
                {
                    disqualified = true
                });
            }

            return new AjaxResult(data: nextPerformanceStartsAt);
        }

    }
}
