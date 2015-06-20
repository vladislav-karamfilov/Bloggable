namespace Bloggable.Web.Infrastructure.Attributes
{
    using System;
    using System.Web.Mvc;

    public class PlaceholderAttribute : Attribute, IMetadataAware
    {
        private readonly string placeholder;

        public PlaceholderAttribute(string placeholder)
        {
            this.placeholder = placeholder;
        }

        void IMetadataAware.OnMetadataCreated(ModelMetadata metadata)
        {
            this.OnMetadataCreated(metadata);
        }

        public void OnMetadataCreated(ModelMetadata metadata)
        {
            metadata.AdditionalValues["placeholder"] = this.placeholder;
        }
    }
}
