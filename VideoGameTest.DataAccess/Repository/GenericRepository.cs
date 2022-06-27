using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameTest.DataAccess.Entities;
using VideoGameTest.DataAccess.Interfaces;

namespace VideoGameTest.DataAccess.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntities
    {
        private readonly DbVideoGameTestContext _checkContext;

        public GenericRepository(DbVideoGameTestContext checkContext)
        {
            _checkContext = checkContext;
        }

        /// <summary>
        /// Получение сущности через AsQueryable
        /// </summary>
        public IQueryable<T> AsQueryable()  //?
        {
            return _checkContext.Set<T>().AsQueryable();
        }

        /// <summary>
        /// Запрос на удаление выбранной записи по ID
        /// </summary>
        public async Task DeleteAsync(int? id)
        {
            T entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _checkContext.Set<T>().Remove(entity);
                await _checkContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Запрос на добавление новой записи
        /// </summary>
        public async Task InsertAsync(T entity)
        {
            await _checkContext.AddAsync(entity);
        }

        /// <summary>
        /// Обновление БД
        /// </summary>
        public async Task SaveChangesAsync()
        {
            await _checkContext.SaveChangesAsync();
        }

        /// <summary>
        /// Получение выбранной записи по ключевому полю
        /// </summary>
        public async Task<T> GetByIdAsync(int? id)
        {
            return await _checkContext.Set<T>().FindAsync(id);
        }
    }
}
