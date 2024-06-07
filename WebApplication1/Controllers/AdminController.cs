using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

         
        public IActionResult Index()
        {
            return View();
        }

         
        public async Task<IActionResult> Products()
        {
            var products = _context.Products.Include(p => p.Category);
            return View(await products.ToListAsync());
        }

         
        public async Task<IActionResult> Categories()
        {
            return View(await _context.Categories.ToListAsync());
        }

         
        public async Task<IActionResult> ProductImages()
        {
            var productImages = _context.ProductImages.Include(p => p.Product);
            return View(await productImages.ToListAsync());
        }
    }
}
