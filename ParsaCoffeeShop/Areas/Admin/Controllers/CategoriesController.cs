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
    public class CategoriesController : Controller
    {
        private readonly ParsaDbContext _context = new ParsaDbContext();
        ICategoryService _categoryService;
        IMenuService _menuService;

        public CategoriesController()
        {
            _categoryService = new CategoryService(_context);
            _menuService = new MenuService(_context);
        }

        // GET: Admin/Categories
        public IActionResult Index()
        {
            return View(_categoryService.GetAllCategories());
        }

        // GET: Admin/Categories/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _categoryService.GetCategoryById(id.Value);
            if (category == null)
            {
                return NotFound();
            }

            return PartialView(category);
        }

        // GET: Admin/Categories/Create
        public IActionResult Create()
        {
            ViewData["MenuId"] = new SelectList(_menuService.GetAllMenus(), "Id", "Title");
            return PartialView();
        }

        // POST: Admin/Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MenuId,Title,Image")] Category category)
        {
            if (ModelState.IsValid)
            {
                category.Id = Guid.NewGuid();
                await _categoryService.InsertCategory(category);
                await _categoryService.Save();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MenuId"] = new SelectList(_menuService.GetAllMenus(), "Id", "Title", category.MenuId);
            return View(category);
        }

        // GET: Admin/Categories/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _categoryService.GetCategoryById(id.Value);
            if (category == null)
            {
                return NotFound();
            }
            ViewData["MenuId"] = new SelectList(_menuService.GetAllMenus(), "Id", "Title", category.MenuId);
            return PartialView(category);
        }

        // POST: Admin/Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,MenuId,Title,Image")] Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _categoryService.UpdateCategory(category);
                await _categoryService.Save();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MenuId"] = new SelectList(_menuService.GetAllMenus(), "Id", "Title", category.MenuId);
            return View(category);
        }

        // GET: Admin/Categories/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _categoryService.GetCategoryById(id.Value);
            if (category == null)
            {
                return NotFound();
            }

            return PartialView(category);
        }

        // POST: Admin/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var category = await _categoryService.GetCategoryById(id);
            if (category != null)
            {
                _categoryService.DeleteCategory(category);
            }

            await _categoryService.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
