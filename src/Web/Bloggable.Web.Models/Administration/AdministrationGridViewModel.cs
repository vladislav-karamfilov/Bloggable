namespace Bloggable.Web.Models.Administration
{
    using System;
    using System.Web.Mvc;

    public abstract class AdministrationGridViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public DateTime CreatedOn { get; set; }

        [HiddenInput(DisplayValue = false)]
        public DateTime? ModifiedOn { get; set; }
    }
}
