using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Service.Interfaces
{
    public interface ICategoryService : IDisposable
    {
        public IEnumerable<Category> GetAllCategories();
        public Task<Category> GetCategoryById(Guid id);
        Task<bool> InsertCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(Category category);
        Task<bool> DeleteCategory(Guid id);
        Task Save();
    }
}