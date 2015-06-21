namespace Bloggable.Data.Models
{
    using Bloggable.Data.Contracts;

    public class Setting : IdentifiableAuditInfo<string>
    {
        public string Value { get; set; }
    }
}
