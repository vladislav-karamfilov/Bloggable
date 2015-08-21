namespace Bloggable.Web.Controllers
{
    using System.Web.Mvc;

    using Bloggable.Services.Data.Contracts;

    public class UserValidationController : BaseController
    {
        private readonly IUsersDataService usersData;

        public UserValidationController(IUsersDataService usersData)
        {
            this.usersData = usersData;
        }

        public ActionResult IsAvailableUserName(string username)
        {
            var isAvailableUserName = this.usersData.IsAvailableUserName(username);
            return this.Json(isAvailableUserName, JsonRequestBehavior.AllowGet);
        }

        public ActionResult IsAvailableEmail(string email)
        {
            var isAvailableEmail = this.usersData.IsAvailableEmail(email);
            return this.Json(isAvailableEmail, JsonRequestBehavior.AllowGet);
        }
    }
}