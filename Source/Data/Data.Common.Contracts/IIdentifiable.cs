namespace Data.Common.Contracts
{
    public interface IIdentifiable<T>
    {
        T Id { get; set; }
    }
}
