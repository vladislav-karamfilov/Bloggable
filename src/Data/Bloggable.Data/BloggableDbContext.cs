namespace Bloggable.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Linq;

    using Bloggable.Data.Contracts;
    using Bloggable.Data.Contracts.CodeFirstConventions;
    using Bloggable.Data.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class BloggableDbContext : IdentityDbContext<User>, IBloggableDbContext
    {
        public BloggableDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString, false)
        {
        }

        public virtual IDbSet<Post> Posts { get; set; }

        public virtual IDbSet<Page> Pages { get; set; }

        public virtual IDbSet<Tag> Tags { get; set; }

        public virtual IDbSet<Comment> Comments { get; set; }

        public virtual IDbSet<Rating> Ratings { get; set; }

        public virtual IDbSet<SearchTerm> SearchTerms { get; set; }

        public virtual IDbSet<Feedback> Feedback { get; set; }

        public virtual IDbSet<Referral> Referrals { get; set; }

        public virtual IDbSet<AdministrationLog> AdministrationLogs { get; set; }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();

#if DEBUG
            return this.SaveChangesWithTracingDbExceptions();
#else
            return base.SaveChanges();
#endif
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Without this call EntityFramework won't be able to configure the identity model
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Add<IsUnicodeAttributeConvention>();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            var auditInfoEntries = this.ChangeTracker.Entries()
                .Where(e => e.Entity is IAuditInfo && (e.State == EntityState.Added || e.State == EntityState.Modified));
            foreach (var entry in auditInfoEntries)
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (!entity.PreserveCreatedOn)
                    {
                        entity.CreatedOn = DateTime.Now;
                    }
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }

        private int SaveChangesWithTracingDbExceptions()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Exception currentException = ex;
                while (currentException != null)
                {
                    Trace.TraceInformation(currentException.Message);
                    currentException = currentException.InnerException;
                }

                throw;
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {1}{0} Error: {2}", Environment.NewLine, validationError.PropertyName, validationError.ErrorMessage);
                    }
                }

                throw;
            }
        }
    }
}
