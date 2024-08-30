using Microsoft.AspNetCore.Mvc;
using Store.Data.Interfaces;
using Store.Models;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace Store.Controllers
{
    public class ImageController : Controller
    {
        private readonly IAppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly ILogger<ImageController> _logger;

        public ImageController(IAppDbContext context, IConfiguration configuration, ILogger<ImageController> logger)
        {
            _context = context;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<IActionResult> GetImage(Guid id)
        {
            var localStorage = _configuration.GetValue<string>("LocalStorage");
            var itemImage = await _context.Images.FindAsync(id);

            var pathToFile = Path.Combine(localStorage, id.ToString() + $".{itemImage.Extenstion}");

            if (!System.IO.File.Exists(pathToFile))
                return NotFound();

            var image = await System.IO.File.ReadAllBytesAsync(pathToFile);

            return File(image, "image/jpeg");
        }

        [HttpPost]
        public async Task<Guid> UploadImageAsync(IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                var itemImage = new ItemImage
                {
                    Id = Guid.NewGuid(),
                    Extenstion = imageFile.FileName.Split('.').Last()
                };

                await _context.Images.AddAsync(itemImage);
                await _context.SaveChangesAsync();
                await SaveImageToLocalStorage(imageFile, itemImage);
                return itemImage.Id;
            }

            throw new Exception("Invalid image upload");
        }

        public async Task<Guid> UploadImageAsync()
        {
            var itemImage = new ItemImage
            {
                Id = Guid.NewGuid(),
                Extenstion = "jpg"
            };

            await _context.Images.AddAsync(itemImage);
            await _context.SaveChangesAsync();

            var localStorage = _configuration.GetValue<string>("LocalStorage");
            var defaultImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/default.jpg");

            System.IO.File.Copy(defaultImagePath, Path.Combine(localStorage, $"{itemImage.Id}.jpg"));

            return itemImage.Id;

        }

        private async Task SaveImageToLocalStorage(IFormFile file, ItemImage image)
        {
            var localStorage = _configuration.GetValue<string>("LocalStorage");

            var filePath = Path.Combine(localStorage, $"{image.Id}.{image.Extenstion}");
            var stream = new FileStream(filePath, FileMode.Create);

            await file.CopyToAsync(stream);
            stream.Close();
        }
    }
}
