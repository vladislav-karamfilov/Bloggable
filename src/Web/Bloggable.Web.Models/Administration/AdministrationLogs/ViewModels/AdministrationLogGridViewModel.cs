namespace Bloggable.Web.Models.Administration.AdministrationLogs.ViewModels
{
    using AutoMapper;

    using Bloggable.Common.Mapping;
    using Bloggable.Data.Models;

    public class AdministrationLogGridViewModel :
        AdministrationGridViewModel,
        IMapFrom<AdministrationLog>,
        IHaveCustomMappings
    {
        public long Id { get; set; }

        public string UserName { get; set; }

        public string IpAddress { get; set; }

        public string RequestType { get; set; }

        public string Url { get; set; }

        public string PostParams { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<AdministrationLog, AdministrationLogGridViewModel>()
                .ForMember(m => m.UserName, opt => opt.MapFrom(e => e.User.UserName));
        }
    }
}
