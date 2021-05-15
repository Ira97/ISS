using System.Collections.Generic;
using AutoMapper;

namespace BusinessLogicCore.Interfaces
{
    /// <summary>
    /// Провайдер для работы с AutoMapper
    /// </summary>
    public interface IMapperProvider
    {
        /// <summary>
        /// Маппинг
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        TResult CreateMap<TSource, TResult>(TSource source);
        /// <summary>
        /// Маппинг списка
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        List<TResult> CreateMapForList<TSource, TResult>(List<TSource> source);

        /// <summary>
        /// Маппинг
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        TResult CreateMapByProfile<TSource, TResult, TProfile>(TSource source) where TProfile : Profile, new();
    }
}
