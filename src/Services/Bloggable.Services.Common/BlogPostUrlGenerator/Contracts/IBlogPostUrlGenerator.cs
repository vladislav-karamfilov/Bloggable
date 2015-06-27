namespace Bloggable.Services.Common.BlogPostUrlGenerator.Contracts
{
    using System;

    public interface IBlogPostUrlGenerator
    {
        string GenerateUrl(int id, string title, DateTime createdOn);
    }
}
