namespace Bloggable.Services.Common.Mapping
{
    using System.Linq;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Bloggable.Services.Common.Mapping.Contracts;

    public class AutoMapperMappingService : IMappingService
    {
        public TDestination Map<TDestination>(object source) => Mapper.Map<TDestination>(source);

        public void Map<TSource, TDestination>(TSource source, TDestination destination) =>
            Mapper.Map(source, destination);

        public IQueryable<TDestination> MapCollection<TDestination>(IQueryable source, object parameters = null) =>
            source.ProjectTo<TDestination>(parameters);
    }
}
