namespace Bloggable.Web.Controllers
{
    using System.Web.Mvc;

    using Bloggable.Web.Infrastructure.Attributes;

    [PopulateSystemSettings]
    public abstract class BaseController : Controller
    {
    }
}