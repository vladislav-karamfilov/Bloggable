namespace Bloggable.Services.Data
{
    using System.Linq;

    using Bloggable.Data.Contracts.Repositories;
    using Bloggable.Data.Models;
    using Bloggable.Services.Data.Contracts;

    public class UsersDataService : IUsersDataService
    {
        private readonly IDeletableEntityRepository<User> users;

        public UsersDataService(IDeletableEntityRepository<User> users)
        {
            this.users = users;
        }

        public bool IsAvailableUserName(string username, bool includeDeleted = false)
        {
            var allUsers = includeDeleted ? this.users.AllWithDeleted() : this.users.All();

            var isAvailableUserName = allUsers.All(u => u.UserName != username);
            return isAvailableUserName;
        }

        public bool IsAvailableEmail(string email, bool includeDeleted = false)
        {
            var allUsers = includeDeleted ? this.users.AllWithDeleted() : this.users.All();

            var isAvailableEmail = allUsers.All(u => u.Email != email);
            return isAvailableEmail;
        }
    }
}
