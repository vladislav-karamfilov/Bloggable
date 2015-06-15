﻿namespace Bloggable.Web.Infrastructure.Models
{
    public class Alert
    {
        public Alert(AlertType type, string message)
        {
            this.Type = type;
            this.Message = message;
        }

        public AlertType Type { get; set; }

        public string Message { get; set; }
    }
}
