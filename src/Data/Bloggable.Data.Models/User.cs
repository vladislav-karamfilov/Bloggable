﻿namespace Bloggable.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    using Bloggable.Data.Contracts;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser, IAuditInfo, IDeletableEntity
    {
        private ICollection<Post> posts;
        private ICollection<Comment> comments;

        public User()
        {
            this.posts = new HashSet<Post>();
            this.comments = new HashSet<Comment>();
        }

        public virtual ICollection<Post> Posts
        {
            get { return this.posts; }
            set { this.posts = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        #region IAuditInfo Members

        public DateTime CreatedOn { get; set; }

        [NotMapped]
        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        #endregion

        #region IDeletableEntity Members

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        #endregion
    }
}
