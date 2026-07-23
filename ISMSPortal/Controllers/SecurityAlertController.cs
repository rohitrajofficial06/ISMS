using ISMSPortal.Services.Interfaces;
using ISMSPortal.ViewModels.SecurityAlert;
using Microsoft.AspNetCore.Mvc;

namespace ISMSPortal.Controllers
{
    public class SecurityAlertController : Controller
    {
        private readonly ISecurityAlertService _service;

        public SecurityAlertController(ISecurityAlertService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index(string? searchText)
        {
            ViewBag.SearchText = searchText;
            return View(await _service.GetAllAsync(searchText));
        }

        public IActionResult Create()
        {
            return View(new SecurityAlertCreateViewModel
            {
                PublishDate = DateTime.Today,
                Severity = "Medium",
                IsPublished = true,
                DisplayOrder = 1
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SecurityAlertCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _service.CreateAsync(model);

            TempData["Success"] = "Security Alert added successfully.";

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await _service.GetByIdAsync(id);

            if (model == null)
                return NotFound();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SecurityAlertEditViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _service.UpdateAsync(model);

            TempData["Success"] = "Security Alert updated successfully.";

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await _service.GetByIdAsync(id);

            if (model == null)
                return NotFound();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);

            TempData["Success"] = "Security Alert deleted successfully.";

            return RedirectToAction(nameof(Index));
        }
    }
}