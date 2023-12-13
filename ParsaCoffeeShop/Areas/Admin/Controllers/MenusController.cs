using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain;
using Domain.Entities;
using Service.Interfaces;
using Service.Services;

namespace ParsaCoffeeShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenusController : Controller
    {
        private readonly ParsaDbContext _context = new ParsaDbContext();
        private IMenuService _menuService;

        public MenusController()
        {
            _menuService = new MenuService(_context);
        }

        // GET: Admin/Menus
        public IActionResult Index()
        {
            return View(_menuService.GetAllMenus());
        }

        // GET: Admin/Menus/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _menuService.GetMenuById(id.Value);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        // GET: Admin/Menus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Menus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                menu.Id = Guid.NewGuid();
                await _menuService.InsertMenu(menu);
                await _menuService.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(menu);
        }

        // GET: Admin/Menus/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _menuService.GetMenuById(id.Value);
            if (menu == null)
            {
                return NotFound();
            }
            return View(menu);
        }

        // POST: Admin/Menus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Title")] Menu menu)
        {
            if (id != menu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _menuService.UpdateMenu(menu);
                await _menuService.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(menu);
        }

        // GET: Admin/Menus/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _menuService.GetMenuById(id.Value);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        // POST: Admin/Menus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var menu = await _menuService.GetMenuById(id);
            if (menu != null)
            {
                _menuService.DeleteMenu(menu);
            }

            await _menuService.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
