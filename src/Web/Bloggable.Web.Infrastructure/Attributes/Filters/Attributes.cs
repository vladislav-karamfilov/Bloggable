namespace Bloggable.Web.Infrastructure.Attributes.Filters
{
    using System;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AdministrationLogAttribute : Attribute
    {
    }
}
