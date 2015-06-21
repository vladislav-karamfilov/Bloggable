namespace Bloggable.Web.Areas.Administration.Controllers.Base
{
    using System.Web.Mvc;

    using Bloggable.Common.Constants;
    using Bloggable.Web.Controllers;
    using Bloggable.Web.Infrastructure.Attributes;

    [Authorize(Roles = RoleConstants.Administrator)]
    [AdministrationLog]
    public abstract class AdministrationController : BaseController
    {
    }
}