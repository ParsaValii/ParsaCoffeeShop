using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Service.Interfaces;

namespace Service.Services
{
    public class ItemService : IItemService
    {
        private ParsaDbContext _context;
        public ItemService(ParsaDbContext parsaDbContext)
        {
            _context = parsaDbContext;
        }


        public IEnumerable<Item> GetAllItems()
        {
            return _context.Items.ToList();
        }

        public async Task<Item> GetItemById(Guid id)
        {
            var item = await _context.Items.FindAsync(id);
            return item;
        }

        public async Task<bool> InsertItem(Item item)
        {
            try
            {
                await _context.Items.AddAsync(item);
                return true;
            }
            catch (System.Exception)
            {
                return false;   
            }
        }

        public bool UpdateItem(Item item)
        {
            try
            {
                _context.Entry(item).State = EntityState.Modified;
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public bool DeleteItem(Item item)
        {
            try
            {
                _context.Entry(item).State = EntityState.Deleted;
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteItem(Guid id)
        {
            try
            {
                var item = await GetItemById(id);
                DeleteItem(item);
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async void Dispose()
        {
            await _context.DisposeAsync();
        }
    }
}