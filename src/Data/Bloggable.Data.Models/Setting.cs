namespace Bloggable.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Bloggable.Data.Contracts;

    public class Setting : IIdentifiable<string>
    {
        [Key]
        public string Id { get; set; }

        public string Value { get; set; }
    }
}
