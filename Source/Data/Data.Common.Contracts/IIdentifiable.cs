namespace Data.Common.Contracts
{
    public interface IIdentifiable<TKey>
    {
        TKey Id { get; set; }
    }
}
