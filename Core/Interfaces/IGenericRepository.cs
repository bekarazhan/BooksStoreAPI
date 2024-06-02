using BooksStoreAPI.Core.Models.Entities;

namespace Core.Interfaces {
    public interface IGenericRepository<T> where T: BaseEntity {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);

    }
}
