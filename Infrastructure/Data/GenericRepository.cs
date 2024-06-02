using BooksStoreAPI.Core.Interfaces.Models;
using BooksStoreAPI.Core.Models.Entities;
using BookStoreAPI.Infrastructure.Data;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data {
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity {
        private readonly BookContext _context;

        public GenericRepository(BookContext context) {
            _context = context;
        }

        public async Task<T> AddAsync(T entity) {
            if (entity is ITrackable trackableEntity) {
                trackableEntity.CreatedAt = DateTime.Now;
            }
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id) {
            var entity = await GetByIdAsync(id);
            if (entity is IRecoverable recoverableEntity) {
                recoverableEntity.IsDeleted = true;
                recoverableEntity.DeletedAt = DateTime.Now;
            } else {
                _context.Set<T>().Remove(entity);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(int id) {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task UpdateAsync(T entity) {
            if (entity is ITrackable trackableEntity) {
                trackableEntity.UpdatedAt = DateTime.Now;
            }
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> ListAllAsync() {
            return await _context.Set<T>().ToListAsync();
        }
    }

}
