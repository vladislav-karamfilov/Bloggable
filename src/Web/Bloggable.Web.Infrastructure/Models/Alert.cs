namespace Bloggable.Web.Infrastructure.Models
{
    public class Alert
    {
        public Alert(string cssClass, string message)
        {
            this.CssClass = cssClass;
            this.Message = message;
        }

        public string CssClass { get; set; }

        public string Message { get; set; }
    }
}
