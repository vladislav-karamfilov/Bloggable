namespace Bloggable.Web.Models.Administration
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using Bloggable.Common.Constants;
    using Bloggable.Data.Models;
    using Bloggable.Web.Infrastructure.Models;

    using Newtonsoft.Json;

    public abstract class TaggableAdministrationGridViewModel : AdministrationGridViewModel, ITaggableModel
    {
        private string mergedTags;

        protected TaggableAdministrationGridViewModel()
        {
            this.Tags = new List<Tag>();
        }
        
        [Display(Name = "Tags")]
        [RegularExpression(
            TagValidationConstants.MergedTagsRegEx, 
            ErrorMessage = "{0} should be strings with length between 2 and 30 characters separated by comma.")]
        public string MergedTags
        {
            get
            {
                if (this.Tags != null && this.Tags.Any())
                {
                    this.mergedTags = string.Join(", ", this.Tags.Select(t => t.Name));
                }

                return this.mergedTags;
            }

            set
            {
                this.mergedTags = value;
            }
        }

        [JsonIgnore]
        [ScaffoldColumn(false)]
        public ICollection<Tag> Tags { get; set; }
    }
}
