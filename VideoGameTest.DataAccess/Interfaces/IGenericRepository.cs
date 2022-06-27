using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameTest.DataAccess.Entities;

namespace VideoGameTest.DataAccess.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntities
    {
        /// <summary>
        /// Шаблонная функция добавления новых записей
        /// </summary>
        /// <param name="entity">Приниемая сущность</param>
        Task InsertAsync(T entity);

        /// <summary>
        /// Шаблонная функция удаления записи(шаблон для сущности)
        /// </summary>
        Task DeleteAsync(int? id);

        /// <summary>
        /// Получение сущности с помощью AsQueryable
        /// </summary>
        IQueryable<T> AsQueryable();

        /// <summary>
        /// Запрос на Update
        /// </summary>
        Task SaveChangesAsync();

        /// <summary>
        /// 123
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(int? id);
    }
}
