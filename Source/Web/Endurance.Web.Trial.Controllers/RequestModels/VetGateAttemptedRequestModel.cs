namespace Endurance.Web.Trial.Controllers.RequestModels
{
    using Resources.Endurance.Enums;

    public class VetGateAttemptedRequestModel
    {
        public int Id { get; set; }

        public VetGateStatus VetGateStatus { get; set; }
    }
}
