namespace Bloggable.Web.Controllers
{
    using System.Web.Mvc;

    using Bloggable.Web.Infrastructure.Attributes;

    [PopulateSystemSettingsViewData]
    public abstract class BaseController : Controller
    {
    }
}