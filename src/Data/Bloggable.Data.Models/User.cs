﻿namespace Bloggable.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Bloggable.Common.Constants;
    using Bloggable.Data.Contracts;
    using Bloggable.Data.Contracts.DataAnnotations;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser, IIdentifiable<string>, IAuditInfo, IDeletableEntity
    {
        private ICollection<Post> posts;
        private ICollection<Comment> comments;
        private ICollection<Rating> ratings;

        public User()
        {
            this.posts = new HashSet<Post>();
            this.comments = new HashSet<Comment>();
            this.ratings = new HashSet<Rating>();
            this.CreatedOn = DateTime.Now;
        }

        [Required]
        [IsUnicode(false)]
        [MinLength(UserValidationConstants.EmailMinLength)]
        [MaxLength(UserValidationConstants.EmailMaxLength)]
        public override string Email { get; set; }

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

        public virtual ICollection<Rating> Ratings
        {
            get { return this.ratings; }
            set { this.ratings = value; }
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

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }
    }
}
