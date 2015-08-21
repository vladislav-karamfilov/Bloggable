namespace Bloggable.Services.Data.Contracts
{
    using Bloggable.Services.Common;

    public interface IUsersDataService : IService
    {
        bool IsAvailableUserName(string username, bool includeDeleted = false);

        bool IsAvailableEmail(string email, bool includeDeleted = false);
    }
}
