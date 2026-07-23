using Microsoft.AspNetCore.Mvc;
using ISMSPortal.Services.Interfaces;
using ISMSPortal.ViewModels.Announcement;

namespace ISMSPortal.Controllers
{
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _service;

        public AnnouncementController(IAnnouncementService service)
        {
            _service = service;
        }

        #region List

        public async Task<IActionResult> Index(string? searchText)
        {
            var model = await _service.GetAllAsync(searchText);

            ViewBag.SearchText = searchText;

            return View(model);
        }

        #endregion

        #region Details

        public async Task<IActionResult> Details(int id)
        {
            var model = await _service.GetByIdAsync(id);

            if (model == null)
                return NotFound();

            return View(model);
        }

        #endregion

        #region Create

        [HttpGet]
        public IActionResult Create()
        {
            return View(new AnnouncementCreateViewModel
            {
                PublishDate = DateTime.Today,
                IsPublished = true,
                DisplayOrder = 1
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AnnouncementCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                await _service.CreateAsync(model);

                TempData["Success"] = "Announcement created successfully.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);

                return View(model);
            }
        }

        #endregion

        #region Edit

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _service.GetByIdAsync(id);

            if (model == null)
                return NotFound();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AnnouncementEditViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                await _service.UpdateAsync(model);

                TempData["Success"] = "Announcement updated successfully.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);

                return View(model);
            }
        }

        #endregion

        #region Delete

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _service.GetByIdAsync(id);

            if (model == null)
                return NotFound();

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _service.DeleteAsync(id);

                TempData["Success"] = "Announcement deleted successfully.";
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }

            return RedirectToAction(nameof(Index));
        }

        #endregion
    }
}