namespace Endurance.Services.Trial.Account
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Contracts.Account;
    using Data.Trial.Models.Account;
    using Microsoft.AspNetCore.Identity;

    public class UsersDataService : IUsersDataService
    {
        private readonly UserManager<User> userManager;

        public UsersDataService(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IdentityResult> CreateAsync(User user, string password) =>
            await userManager.CreateAsync(user, password);

        public async Task<User> GetUserAsync(ClaimsPrincipal userPrincipal) =>
            await userManager.GetUserAsync(userPrincipal);

        public string GetUserId(ClaimsPrincipal userPrincipal) =>
            userManager.GetUserId(userPrincipal);

        public Task<IdentityResult> SetEmailAsync(User user, string email) =>
            userManager.SetEmailAsync(user, email);

        public Task<IdentityResult> SetPhoneNumbmerAsync(User user, string phoneNumber) =>
            userManager.SetPhoneNumberAsync(user, phoneNumber);

        public Task<bool> DoesUserHavePasswordAsync(User user) =>
            userManager.HasPasswordAsync(user);

        public Task<IdentityResult> ChangePasswordAsync(User user, string oldPassword, string newPassword) =>
            userManager.ChangePasswordAsync(user, oldPassword, newPassword);

        public Task<IdentityResult> SetPasswordAsync(User user, string password) =>
            userManager.AddPasswordAsync(user, password);
    }
}
