using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Service.Interfaces
{
    public interface IMenuService :IDisposable
    {
        public IEnumerable<Menu> GetAllMenus();
        public Task<Menu> GetMenuById(Guid id);
        Task<bool> InsertMenu(Menu menu);
        bool UpdateMenu(Menu menu);
        bool DeleteMenu(Menu menu);
        Task<bool> DeleteMenu(Guid id);
        Task Save();
    }
}