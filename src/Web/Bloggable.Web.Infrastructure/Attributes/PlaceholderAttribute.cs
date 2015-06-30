namespace Bloggable.Web.Infrastructure.Attributes
{
    using System;
    using System.Web.Mvc;

    public class PlaceholderAttribute : Attribute, IMetadataAware
    {
        public const string AdditionalValueKey = "_placeholder";

        private readonly string placeholder;

        public PlaceholderAttribute(string placeholder)
        {
            this.placeholder = placeholder;
        }

        public void OnMetadataCreated(ModelMetadata metadata)
        {
            metadata.AdditionalValues[AdditionalValueKey] = this.placeholder;
        }
    }
}
