namespace Bloggable.Data.Models
{
    using System.Collections.Generic;

    public class Post : ContentHolder
    {
        private ICollection<Comment> comments;

        public Post()
        {
            this.comments = new HashSet<Comment>();
        }
        
        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}