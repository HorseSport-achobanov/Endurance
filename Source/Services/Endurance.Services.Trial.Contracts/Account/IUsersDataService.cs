namespace Endurance.Services.Trial.Contracts.Account
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Data.Trial.Models.Account;
    using Microsoft.AspNetCore.Identity;

    using global::Services.Common.Contracts;

    public interface IUsersDataService : IService
    {
        Task<IdentityResult> CreateAsync(User user, string password);

        Task<User> GetUserAsync(ClaimsPrincipal userPrincipal);

        string GetUserId(ClaimsPrincipal userPrincipal);

        Task<IdentityResult> SetEmailAsync(User user, string email);

        Task<IdentityResult> SetPhoneNumbmerAsync(User user, string phoneNumber);

        Task<bool> DoesUserHavePasswordAsync(User user);

        Task<IdentityResult> ChangePasswordAsync(User user, string oldPassword, string newPassword);

        Task<IdentityResult> SetPasswordAsync(User user, string password);
    }
}
