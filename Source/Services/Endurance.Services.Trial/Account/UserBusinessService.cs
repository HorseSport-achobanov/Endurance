namespace Endurance.Services.Trial.Account
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Contracts.Account;
    using Data.Trial.Models.Account;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Logging;

    public class UserBusinessService : IUserBusinessService
    {
        private readonly IUserDataService userData;
        private readonly SignInManager<User> signInManager;

        public UserBusinessService(
            IUserDataService userData,
            SignInManager<User> signInManager
        ) {
            this.userData = userData;
            this.signInManager = signInManager;
        }

        public async Task<IdentityResult> Register(User user, string password)
        {
            var registration = await userData.CreateAsync(user, password);

            return registration;
        }

        public async Task<User> GetUserAsync(ClaimsPrincipal userPrincipal)
        {
            var user = await userData.GetUserAsync(userPrincipal);
            if (user == null)
                throw new ApplicationException($"Unable to load user with ID '{userData.GetUserId(userPrincipal)}'.");

            return user;
        }

        public async Task<bool> UpdateProfileInfo(ClaimsPrincipal userPrincipal, string newEmail, string newPhoneNumber)
        {
            var user = await userData.GetUserAsync(userPrincipal);
            var email = user.Email;
            var phoneNumber = user.PhoneNumber;

            if (newEmail != email)
            {
                var result = await userData.SetEmailAsync(user, email);
                if (!result.Succeeded)
                    throw new ApplicationException($"Unexpected error occurred setting email for user with ID '{user.Id}'.");
            }
            if (newPhoneNumber != phoneNumber)
            {
                var result = await userData.SetPhoneNumbmerAsync(user, phoneNumber);
                if (!result.Succeeded)
                    throw new ApplicationException($"Unexpected error occurred setting phone number for user with ID '{user.Id}'.");
            }

            return true;
        }

        public async Task<bool> DoesUserHavePassword(ClaimsPrincipal userPrincipal)
        {
            var user = await userData.GetUserAsync(userPrincipal);
            if (user == null)
                throw new ApplicationException($"Unable to load user with ID '{userData.GetUserId(userPrincipal)}'.");

            return await userData.DoesUserHavePasswordAsync(user);
        }

        public async Task<IdentityResult> ChangePasswordAsync(ClaimsPrincipal userPrincipal, string oldPassword, string newPassword)
        {
            var user = await userData.GetUserAsync(userPrincipal);
            if (user == null)
                throw new ApplicationException($"Unable to load user with ID '{userData.GetUserId(userPrincipal)}'.");

            var result = await userData.ChangePasswordAsync(user, oldPassword, newPassword);
            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: false);
            }

            return result;
        }

        public async Task<IdentityResult> SetPasswordAsync(ClaimsPrincipal userPrincipal, string password)
        {
            var user = await userData.GetUserAsync(userPrincipal);
            if (user == null)
                throw new ApplicationException($"Unable to load user with ID '{userData.GetUserId(userPrincipal)}'.");

            var result = await userData.SetPasswordAsync(user, password);
            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: false);
            }

            return result;
        }

        public async Task<SignInResult> SignInAsync(string email, string password, bool rememberMe)
        {
            return await signInManager.PasswordSignInAsync(email, password, rememberMe, lockoutOnFailure: false);
        }

        public async Task<bool> SignOutAsync()
        {
            await signInManager.SignOutAsync();

            return true;
        }
    }
}
