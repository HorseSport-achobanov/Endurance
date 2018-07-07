namespace Endurance.Services.Trial.Contracts.Trial
{
    using Data.Trial.Models;
    using global::Services.Common.Contracts;

    public interface ITrialsBusinessService : IService
    {
        bool Activate(int Id);
    }
}
