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
    public class ItemsController : Controller
    {
        private readonly ParsaDbContext _context = new ParsaDbContext();
        IItemService _itemService;
        ICategoryService _categoryService;

        public ItemsController()
        {
            _itemService = new ItemService(_context);
            _categoryService = new CategoryService(_context);
        }

        // GET: Admin/Items
        public IActionResult Index()
        {
            return View(_itemService.GetAllItems());
        }

        // GET: Admin/Items/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _itemService.GetItemById(id.Value);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: Admin/Items/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_categoryService.GetAllCategories(), "Id", "Title");
            return View();
        }

        // POST: Admin/Items/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CategoryId,Title,Description,Price,Image")] Item item)
        {
            if (ModelState.IsValid)
            {
                item.Id = Guid.NewGuid();
                await _itemService.InsertItem(item);
                await _itemService.Save();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_categoryService.GetAllCategories(), "Id", "Title", item.CategoryId);
            return View(item);
        }

        // GET: Admin/Items/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _itemService.GetItemById(id.Value);
            if (item == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_categoryService.GetAllCategories(), "Id", "Title", item.CategoryId);
            return View(item);
        }

        // POST: Admin/Items/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,CategoryId,Title,Description,Price,Image")] Item item)
        {
            if (id != item.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _itemService.UpdateItem(item);
                await _itemService.Save();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_categoryService.GetAllCategories(), "Id", "Title", item.CategoryId);
            return View(item);
        }

        // GET: Admin/Items/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _itemService.GetItemById(id.Value);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Admin/Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _itemService.DeleteItem(id);
            await _itemService.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
