using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Data.Entity;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;

namespace Repository.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Delete(Category entity)
        {
            _context.Categories.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public Task DeleteBulk(List<Category> entities)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public Task<List<Category>> GetAllByCriteriaAsync(Expression<Func<Category, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetByCriteriaAsync(Expression<Func<Category, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task Insert(Category entity)
        {
            try
            {
                await _context.Categories.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task InsertBulk(List<Category> entities)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Category entity)
        {
            try
            {
                _context.Categories.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task UpdateBulk(List<Category> entities)
        {
            throw new NotImplementedException();
        }
    }
}
