using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Service.Interfaces
{
    public interface IItemService : IDisposable
    {
        public IEnumerable<Item> GetAllItems();
        public Task<Item> GetItemById(Guid id);
        Task<bool> InsertItem(Item item);
        bool UpdateItem(Item item);
        bool DeleteItem(Item item);
        Task<bool> DeleteItem(Guid id);
        Task Save();
    }
}
