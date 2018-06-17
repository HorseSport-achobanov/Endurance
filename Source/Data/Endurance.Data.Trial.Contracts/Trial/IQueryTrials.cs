namespace Endurance.Data.Trial.Contracts.Trial
{
    using Models;

    public interface IQueryTrials
    {
        Trial GetById(int id);
    }
}
