using ISMSPortal.Services.Interfaces;
using ISMSPortal.ViewModels.Awareness;
using Microsoft.AspNetCore.Mvc;

namespace ISMSPortal.Controllers
{
    public class AwarenessSessionController : Controller
    {
        private readonly IAwarenessSessionService _service;

        public AwarenessSessionController(IAwarenessSessionService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index(string? searchText)
        {
            ViewBag.SearchText = searchText;

            var model = await _service.GetAllAsync(searchText);

            return View(model);
        }

        public IActionResult Create()
        {
            return View(new AwarenessSessionCreateViewModel
            {
                SessionDate = DateTime.Today,
                IsPublished = true,
                DisplayOrder = 1
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AwarenessSessionCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _service.CreateAsync(model);

            TempData["Success"] = "Awareness session created successfully.";

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
        public async Task<IActionResult> Edit(AwarenessSessionEditViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _service.UpdateAsync(model);

            TempData["Success"] = "Awareness session updated successfully.";

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

            TempData["Success"] = "Awareness session deleted successfully.";

            return RedirectToAction(nameof(Index));
        }
    }
}