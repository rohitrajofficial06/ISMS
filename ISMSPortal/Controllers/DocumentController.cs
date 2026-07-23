using Microsoft.AspNetCore.Mvc;
using ISMSPortal.Services.Interfaces;
using ISMSPortal.ViewModels.Document;

namespace ISMSPortal.Controllers
{
    public class DocumentController : Controller
    {
        private readonly IDocumentService _service;

        public DocumentController(IDocumentService service)
        {
            _service = service;
        }

        #region Index

        public async Task<IActionResult> Index(string? searchText)
        {
            var documents = await _service.GetAllAsync(searchText);

            ViewBag.SearchText = searchText;

            return View(documents);
        }

        #endregion

        #region Details

        public async Task<IActionResult> Details(int id)
        {
            var document = await _service.GetByIdAsync(id);

            if (document == null)
                return NotFound();

            return View(document);
        }

        #endregion

        #region Create

        [HttpGet]
        public IActionResult Create()
        {
            var model = new DocumentCreateViewModel
            {
                EffectiveDate = DateTime.Today,
                Version = "1.0",
                IsPublished = true,
                DisplayOrder = 1
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DocumentCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                await _service.CreateAsync(model);

                TempData["Success"] = "Document created successfully.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
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
        public async Task<IActionResult> Edit(DocumentEditViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                await _service.UpdateAsync(model);

                TempData["Success"] = "Document updated successfully.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }

        #endregion

        #region Delete

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteAsync(id);

                TempData["Success"] = "Document deleted successfully.";
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