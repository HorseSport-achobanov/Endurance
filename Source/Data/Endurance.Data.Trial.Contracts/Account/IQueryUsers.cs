namespace Endurance.Data.Trial.Contracts.Account
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Models.Account;

    public interface IQueryUsers
    {
        Task<IdentityResult> Create(User user, string password);
    }
}
