using ISMSPortal.Services.Interfaces;
using ISMSPortal.ViewModels.Awareness;
using Microsoft.AspNetCore.Mvc;

namespace ISMSPortal.Controllers
{
    public class AwarenessProgressController : Controller
    {
        private readonly IAwarenessProgressService _service;

        public AwarenessProgressController(IAwarenessProgressService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Edit()
        {
            var model = await _service.GetAsync();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AwarenessProgressViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _service.UpdateAsync(model);

            TempData["Success"] = "Awareness Progress updated successfully.";

            return RedirectToAction(nameof(Edit));
        }
    }
}