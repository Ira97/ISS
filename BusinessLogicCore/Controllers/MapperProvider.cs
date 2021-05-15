using System.Collections.Generic;
using AutoMapper;
using BusinessLogicCore.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BusinessLogicCore.Controllers
{
    /// <inheritdoc cref="IMapperProvider"/>/>
    public class MapperProvider :  IMapperProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MapperProvider"/> class.
        /// </summary>
        public MapperProvider() : base()
        {

        }

        /// <inheritdoc/>
        public TResult CreateMap<TSource, TResult>(TSource source)
        {
            var mapper = GetMapper<TSource, TResult>();
            return mapper.Map<TResult>(source);
        }

        /// <inheritdoc/>
        public List<TResult> CreateMapForList<TSource, TResult>(List<TSource> source)
        {
            var mapper = GetMapper<TSource, TResult>();
            return mapper.Map<List<TResult>>(source);
        }

        /// <inheritdoc />
        public TResult CreateMapByProfile<TSource, TResult, TProfile>(TSource source) where TProfile : Profile, new()
        {
            var config = new MapperConfiguration(cfg => { cfg.AddProfile<TProfile>(); });
            var mapper =  new Mapper(config);
            return mapper.Map<TResult>(source);
        }

        /// <summary>
        /// Для сложных сущьностей 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TU"></typeparam>
        /// <returns></returns>
        private Mapper GetMapper<T, TU>()
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<T, TU>(); });
            return new Mapper(config);
        }
    }
}
