using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Store.Data.Interfaces;
using Store.Models;
using System.Diagnostics;

namespace Store.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAppDbContext _context;

        public HomeController(ILogger<HomeController> logger, IAppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index(ItemFilterViewModel model)
        {
            // Получаем все категории для выпадающего списка
            var allCategories = await _context.Categories.ToListAsync();
            ViewBag.Categories = new MultiSelectList(allCategories, "Id", "Name", model.SelectedCategoryIds);

            // Получаем все товары и включаем категории
            var query = _context.Items.Include(x => x.Categories).AsQueryable();

            // Если выбраны категории, фильтруем товары по ним
            if (model.SelectedCategoryIds != null && model.SelectedCategoryIds.Any())
            {
                query = query.Where(item => item.Categories.Any(c => model.SelectedCategoryIds.Contains(c.Id)));
            }

            model.Items = await query.ToListAsync();

            _logger.LogInformation("Fetched {count} of items", model.Items.Count);
            return View(model);
        }


        public async Task<IActionResult> Item(Guid id)
        {
            var item = await _context.Items
                .Include(x => x.Image)
                .Include(x => x.Categories).FirstOrDefaultAsync(x => x.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
