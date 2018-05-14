namespace Endurance.Services.Trial.Contracts.Account
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Data.Trial.Models.Account;
    using Microsoft.AspNetCore.Identity;

    using global::Data.Common.Contracts;
    
    public interface IUserBusinessService : IService
    {
        Task<IdentityResult> Register(User user, string password);

        Task<User> GetUserAsync(ClaimsPrincipal userPrincipal);

        Task<bool> UpdateProfileInfo(ClaimsPrincipal userPrincipal, string newEmail, string newPhoneNumber);

        Task<bool> DoesUserHavePassword(ClaimsPrincipal userPrincipal);

        Task<IdentityResult> ChangePasswordAsync(ClaimsPrincipal userPrincipal, string oldPassword, string newPassword);

        Task<IdentityResult> SetPasswordAsync(ClaimsPrincipal userPrincipal, string password);

        Task<SignInResult> SignInAsync(string email, string password, bool rememberMe);

        Task<bool> SignOutAsync();
    }
}
