using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Store.Data.Interfaces;
using Store.Models;

namespace Store.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IAppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AdminController> _logger;


        public AdminController(IAppDbContext context, IConfiguration configuration, ILogger<AdminController> logger)
        {
            _context = context;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<IActionResult> Index(string activeTab = "Items")
        {
            var model = new AdminPanelViewModel
            {
                Items = await _context.Items.ToListAsync(),
                Categories = await _context.Categories.ToListAsync(),
                ActiveTab = activeTab
            };

            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            var categories = await _context.Categories.ToListAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View();
        }


        public async Task<IActionResult> Delete(Guid id)
        {
            var item = await _context.Items.FindAsync(id);

            if (item is null)
                return NotFound();

            _context.Items.Remove(item);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var item = await _context.Items.Include(i => i.Categories).FirstOrDefaultAsync(i => i.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            // Получаем список категорий и выделяем те, которые уже связаны с товаром
            ViewBag.Categories = new MultiSelectList(_context.Categories, "Id", "Name", item.Categories.Select(c => c.Id));
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Item model, IFormFile Image)
        {

            var item = await _context.Items.Include(i => i.Categories).FirstOrDefaultAsync(i => i.Id == model.Id);
            if (item == null)
            {
                return NotFound();
            }

            var loggerFactory = new LoggerFactory();
            var imageController = new ImageController(_context, _configuration, loggerFactory.CreateLogger<ImageController>());
            if (Image != null)
            {
                var imageId = await imageController.UploadImageAsync(Image);
                item.ImageId = imageId;
            }
            else
            {
                // Проверяем, есть ли у товара изображение
                if (item.ImageId == null)
                {
                    item.ImageId = await imageController.UploadImageAsync();
                }
            }

            item.Name = model.Name;
            item.Description = model.Description;
            item.Summary = model.Summary;
            item.Price = model.Price > 0 ? model.Price : 0;

            // Привязка категорий
            item.Categories = await _context.Categories.Where(c => model.CategoryIds.Contains(c.Id)).ToListAsync();
            ViewBag.Categories = new MultiSelectList(_context.Categories.ToList(), "Id", "Name", model.CategoryIds);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Create(Item model, IFormFile Image)
        {

            var logger = new LoggerFactory();
            var imageController = new ImageController(_context, _configuration, logger.CreateLogger<ImageController>());
            if (Image != null)
            {
                model.ImageId = await imageController.UploadImageAsync(Image);
            }
            else
            {
                model.ImageId = await imageController.UploadImageAsync();
            }
            if(model.Price <= 0)
                model.Price = 0;
            // Получаем выбранные категории по их идентификаторам
            var selectedCategories = await _context.Categories.Where(c => model.CategoryIds.Contains(c.Id)).ToListAsync();
            model.Categories = selectedCategories;

            await _context.Items.AddAsync(model);
            await _context.SaveChangesAsync();
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name", model.CategoryIds);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                var category = new Category { Name = name };
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
            }
            return Json(new { success = true });
        }

        [HttpPost]
        public async Task<IActionResult> EditCategory(Guid id, string newName)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null && !string.IsNullOrWhiteSpace(newName))
            {
                category.Name = newName;
                _context.Categories.Update(category);
                await _context.SaveChangesAsync();
            }
            return Json(new { success = true });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index", new { activeTab = "Categories" });
        }
    }
}
