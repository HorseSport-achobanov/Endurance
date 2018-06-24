namespace Endurance.Web.Trial.Controllers.ResponseModels
{
    public class VetGateAttemptResponseModel
    {
        public VetGateAttemptResponseModel(
            bool disqualified = false, 
            bool passedStatus = false, 
            string nextPerformanceStartsAt = null)
        {
            Disqualified = disqualified;
            PassedStatus = passedStatus;
            NextPerformanceStartAt = nextPerformanceStartsAt;
        }

        public bool Disqualified { get; }

        public bool PassedStatus { get; }

        public string NextPerformanceStartAt { get; }
    }
}
