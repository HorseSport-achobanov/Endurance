namespace Data.Common.Contracts.Queries
{
    public interface IQuery<T> : IBaseQuery<T>
        where T : class
    {
        T GetById(int id);
    }
}
