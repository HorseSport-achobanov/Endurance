namespace Endurance.Data.Trial.Queries.Account
{
    using System.Threading.Tasks;
    using Contracts.Account;
    using Microsoft.AspNetCore.Identity;

    using Models.Account;

    public class QueryUsers : IQueryUsers
    {
        private readonly UserManager<User> userManager;

        public QueryUsers(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IdentityResult> Create(User user, string password)
        {
            return await userManager.CreateAsync(user, password);
        }
    }
}
