using CodeSense.Domain.Abstractions;

namespace CodeSense.Application.Abstractions
{
    public interface IRepository<T> where T : EntityBase
    {
        /// <summary>
        /// Creates an entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>
        /// An entity with a Db Id or an empty entity if not found
        /// </returns>
        Task<T> CreateAsync(T entity);

        /// <summary>
        /// Gets all entities
        /// </summary>
        /// <returns>
        /// An Enumerable of entities or an empty entity if not found
        /// </returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Gets an entity by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// An entity with a Db Id or an empty entity if not found
        /// </returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// Gets an entity by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns>
        /// An entity with a Db Id or an empty entity if not found
        /// </returns>
        Task<T> GetByEmailAsync(string email);

        /// <summary>
        /// Updates an entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>
        /// An updated entity
        /// </returns>
        Task<T> UpdateAsync(T entity);

        /// <summary>
        /// Logically Deletes an entity
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// True if the entity was deleted, false if the entity was not found
        /// </returns>
        Task<bool> DeleteAsync(int id);
    }
}