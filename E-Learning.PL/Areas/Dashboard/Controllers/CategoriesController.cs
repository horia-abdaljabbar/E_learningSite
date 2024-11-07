using AutoMapper;
using E_Learning.DAL.Data;
using E_Learning.DAL.Models;
using E_Learning.PL.Areas.Dashboard.ViewModels;
using E_Learning.PL.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning.PL.Areas.Dashboard.Controllers
{
    [Authorize(Roles = "Admin,superAdmin")]
    [Area("Dashboard")]
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public CategoriesController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var categories = context.Categories.ToList();
            var showCategoriesVM = mapper.Map<IEnumerable<ShowCategoriesVM>>(categories);
            return View(showCategoriesVM);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryFormVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            viewModel.ImageName = FilesSettings.UploadFile(viewModel.Image, "images");

            var category = mapper.Map<Category>(viewModel);
            context.Add(category);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var category = context.Categories.Find(id);
            if (category is null)
            {
                return NotFound();
            }

            var categoryM = mapper.Map<CategoryDetailsVM>(category);
            return View(categoryM);
        }

        public IActionResult Edit(int id)
        {
            var category = context.Categories.Find(id);
            if (category is null)
            {
                return NotFound();
            }
            var categoryM = mapper.Map<CategoryFormVM>(category);
            return View(categoryM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(CategoryFormVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var category = context.Categories.Find(viewModel.Id);
            if (category is null)
            {
                return NotFound();
            }
            viewModel.ImageName = FilesSettings.UploadFile(viewModel.Image, "images");
            var categoryM = mapper.Map(viewModel, category);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var category = context.Categories.Find(id);
            if (category is null)
            {
                return NotFound();
            }
            FilesSettings.DeleteFile(category.ImageName, "images");
            var categoryM = mapper.Map<ShowCategoriesVM>(category);
            return View(categoryM);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var category = context.Categories.Find(id);
            if (category is null)
            {
                return RedirectToAction(nameof(Index));
            }

            context.Categories.Remove(category);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
