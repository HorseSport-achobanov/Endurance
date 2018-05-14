namespace Data.Common.Contracts.Queries
{
    public interface IUserQuery<T> : IBaseQuery<T>
        where T : class
    {
        T GetById(string id);
    }
}
