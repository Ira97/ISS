using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CacheManager.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ScientificDatabase.Interfaces;
using ScientificDatabase.Models;

namespace ScientificDatabase.Repositories
{
    /// <summary>
    /// Базовый репозиторий
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IBaseEntity, new()
    {
        /// <summary>
        /// Контекст
        /// </summary>
        public readonly ScientificContext ScientificContext;
        /// <summary>
        /// Кэш менеджер
        /// </summary>
        private readonly ICacheManager<object> _cacheManager;
        /// <summary>
        /// Логирование
        /// </summary>
        private readonly ILogger<BaseRepository<T>> _logger;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="cacheManager"></param>
        /// <param name="logger"></param>
        protected BaseRepository(ScientificContext dbContext, ICacheManager<object> cacheManager, ILogger<BaseRepository<T>> logger)
        {
            ScientificContext = dbContext;
            _cacheManager = cacheManager;
            _logger = logger;
        }

        /// <summary>
        /// Получение коллекции сущностей по предикату
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate)
        {

            var result = ScientificContext.Set<T>().Where(predicate);
            return result.ToList();
        }
        /// <summary>
        /// Получение полной коллекции сущностей
        /// </summary>
        /// <returns></returns>
        public async Task<List<T>> GetItemsAsync()
        {

            var result = ScientificContext.Set<T>();
            return result.ToList();
        }

        /// <summary>
        /// Получение сущности по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> GetItemAsync(int id)
        {

            var result = ScientificContext.Set<T>();
            return result.SingleOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Получение сущности по предикату
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<T> GetItemAsync(Expression<Func<T, bool>> predicate)
        {

            var list = await GetListAsync(predicate);
            return list?.FirstOrDefault();
        }

        /// <summary>
        /// Обновление сущности
        /// </summary>
        /// <param name="entity"></param>
        public async Task<long> UpdateItemAsync(T entity)
        {

            if (entity == null) throw new Exception();
            if (entity.Id == 0)
            {
                return await InsertItemAsync(entity);
            }
            ScientificContext.Entry(entity).State = EntityState.Modified;
            await ScientificContext.SaveChangesAsync();
            return entity.Id;
        }

        /// <summary>
        /// Открепление сущности
        /// </summary>
        /// <param name="entity"></param>
        public async Task DetachItemAsync(T entity)
        {


            if (entity.Id == 0) return;
            ScientificContext.Entry(entity).State = EntityState.Detached;

        }

        /// <summary>
        /// Удаление элемента по идентификатору
        /// </summary>
        /// <param name="id"></param>
        public async Task DeleteItemAsync(int id)
        {


            var objectToDelete = new T { Id = id };
            ScientificContext.Set<T>().Remove(objectToDelete);
            await ScientificContext.SaveChangesAsync();

        }

        /// <summary>
        /// Удаление элемента
        /// </summary>
        /// <param name="entity"></param>
        public async Task DeleteItemAsync(T entity)
        {


            ScientificContext.Set<T>().Remove(entity);
            await ScientificContext.SaveChangesAsync();

        }

        /// <summary>
        /// Добавление элемента
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<long> InsertItemAsync(T entity)
        {
            var context = ScientificContext.Set<T>();
            context.AttachRange(entity);
            await ScientificContext.SaveChangesAsync();
            return entity.Id;
        }
        /// <summary>
        /// Получение полной коллекции без исполнения
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetItemsWithoutExecution()
        {
            var result = ScientificContext.Set<T>();
            return result;
        }
    }
}
