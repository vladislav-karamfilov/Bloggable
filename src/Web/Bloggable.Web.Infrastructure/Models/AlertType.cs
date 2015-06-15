namespace Bloggable.Web.Infrastructure.Models
{
    using System.ComponentModel;

    public enum AlertType
    {
        [Description("alert-success")]
        Success,

        [Description("alert-info")]
        Info,

        [Description("alert-warning")]
        Warning,

        [Description("alert-danger")]
        Error
    }
}
