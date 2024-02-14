using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Service.Interfaces;

namespace Service.Services
{
    public class CategoryService : ICategoryService
    {
        private ParsaDbContext _context;
        public CategoryService(ParsaDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public async Task<Category> GetCategoryById(Guid id)
        {
            var category = await _context.Categories.FindAsync(id);
            return category;
        }

        public async Task<bool> InsertCategory(Category category)
        {
            try
            {
                await _context.Categories.AddAsync(category);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool UpdateCategory(Category category)
        {
            try
            {
                _context.Entry(category).State = EntityState.Modified;
                return true;
            }
            catch (System.Exception)
            {
                return false;
                throw;
            }
        }

        public bool DeleteCategory(Category category)
        {
            try
            {
                _context.Entry(category).State = EntityState.Deleted;
                return true;
            }
            catch (System.Exception)
            {
                return false;
                throw;
            }
        }

        public async Task<bool> DeleteCategory(Guid id)
        {
            try
            {
                var category = await GetCategoryById(id);
                DeleteCategory(category);
                return true;
            }
            catch (System.Exception)
            {
                return false;
                throw;
            }
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.DisposeAsync();
        }
    }
}