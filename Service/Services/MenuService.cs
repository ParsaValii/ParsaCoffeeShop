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
    public class MenuService : IMenuService
    {
        private ParsaDbContext _context;
        public MenuService(ParsaDbContext context)
        {
            _context = context;
        }


        public IEnumerable<Menu> GetAllMenus()
        {
            return _context.Menus;
        }

        public async Task<Menu> GetMenuById(Guid id)
        {
            var menu = await _context.Menus.FindAsync(id);
            return menu;
        }

        public async Task<bool> InsertMenu(Menu menu)
        {
            try
            {
                await _context.Menus.AddAsync(menu);
                return true;
            }
            catch (Exception)
            {
                return false;   
            }
        }

        public bool UpdateMenu(Menu menu)
        {
            try
            {
                _context.Entry(menu).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;   
            }
        }

        public bool DeleteMenu(Menu menu)
        {
            try
            {
                _context.Entry(menu).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;   
            }
        }

        public async Task<bool> DeleteMenu(Guid id)
        {
            try
            {
                var menu = await GetMenuById(id);
                DeleteMenu(menu);
                return true;
            }
            catch (Exception)
            {
                return false;   
            }
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}