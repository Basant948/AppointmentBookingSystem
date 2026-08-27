using BookingSystem.Application.DTOs;
using BookingSystem.Application.DTOs.Service;
using BookingSystem.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookingSystem.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        // GET: /Service
        public async Task<IActionResult> Index()
        {
            var services = await _serviceService.GetAllAsync();
            return View(services);
        }

        // GET: /Service/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var service = await _serviceService.GetByIdAsync(id);
            if (service is null)
                return NotFound();

            return View(service);
        }

        // GET: /Service/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Service/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateServiceDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            await _serviceService.CreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Service/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var service = await _serviceService.GetByIdAsync(id);
            if (service is null)
                return NotFound();

            var dto = new UpdateServiceDto
            {
                Name = service.Name,
                Price = service.Price,
                Duration = service.Duration,
                Description = service.Description,
                IsActive = service.IsActive
            };

            ViewBag.Id = service.Id;
            return View(dto);
        }

        // POST: /Service/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateServiceDto dto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Id = id;
                return View(dto);
            }

            var updated = await _serviceService.UpdateAsync(id, dto);
            if (!updated)
                return NotFound();

            return RedirectToAction(nameof(Index));
        }

        // GET: /Service/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var service = await _serviceService.GetByIdAsync(id);
            if (service is null)
                return NotFound();

            return View(service);
        }

        // POST: /Service/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deleted = await _serviceService.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return RedirectToAction(nameof(Index));
        }
    }
}